using System;
using static System.Console;

public class qrgs{

    public static (matrix, matrix) decomp(matrix A){
            
            matrix Q = A.copy();
            int m = A.size2;
            matrix R = new matrix(m,m);

            for(int i = 0; i<m; i++){
                R[i,i] = Q[i].norm();
                Q[i]/=R[i,i];
                for(int j=i+1;j<m;j++){
                    R[i,j] = Q[i].dot(Q[j]);
                    Q[j] -= Q[i]*R[i,j];
                }
            }
            return (Q,R);
        } //decomp function

        public static vector solve(matrix Q, matrix R, vector b){

            // R x = Q^T b

            b = Q.T*b; // our new b


            for(int i=b.size-1;i>=0;i--){
                double sum = 0;
                for(int k=i+1;k<b.size;k++) sum += R[i,k]*b[k];
                b[i] = (b[i] - sum)/R[i,i];
                }
            return b;
        } // solve function

        public static double det(matrix R){
            double sum = 0;
            for(int i=0;i<R.size1;i++) sum += R[i,i];
            return sum;
        }

        public static matrix inverse(matrix Q, matrix R){
            int n = Q.size1;
            matrix Ainv = new matrix(n,n);
            for(int i=0;i<n;i++){
                vector e = new vector(n);
                e[i] = 1;
                vector xi = solve(Q, R, e);
                for(int j=0;j<n;j++){
                    Ainv[j,i] = xi[j]; // since row is first, then column
                }
            }
            return Ainv;

        } // inverse


    public static void Test(){
        var ma = new matrix("1 2 ; 5 4");
        ma.print();
        (ma+ma.T).print();
        (matrix.id(3)).print();
        WriteLine("rows:");
        ma.rows(1,1).print();
        WriteLine("cols:");
        ma.cols(1,1).print();

        WriteLine("multiplied");
        double ij = ma[0,1];
        WriteLine($"{ij}");

    }
}

