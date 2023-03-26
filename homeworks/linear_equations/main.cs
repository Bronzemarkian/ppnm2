using System;
using static System.Console;

public class main{

    public static void Main(){
        
        //Test();
        // ------------- check decomp -------------------------------

        Random rnd = new Random();
        int m = rnd.Next(10,20);
        int n = rnd.Next(m+1,40);
        matrix A = new matrix(n, m);
        for(int i=0;i<A.size1;i++){
            for(int k=0;k<A.size2;k++){
                A[i,k] = rnd.Next(0,30);
            }
        }
        
        (matrix Q, matrix R) = qrgs.decomp(A);

        WriteLine($"matrix R is given as:");
        R.print();

        

        matrix QTQ = Q.T * Q;
        WriteLine($"Is Q^T * Q = 1? {QTQ.approx(matrix.id(Q.size2))}");
        // (Q.T * Q).print(); // why does this not work???
        matrix QR = Q*R;
        WriteLine($"Is Q * R = A? {A.approx(QR)}");

        // --------------- check solve ----------------------

        int n2 = rnd.Next(4,40);
        matrix A2 = new matrix(n2, n2);
        for(int i=0;i<n2;i++){
            for(int k=0;k<n2;k++){
                A2[i,k] = rnd.Next(0,30);
            }
        }

        vector b = new vector(n2);
        for(int i=0;i<n2;i++) b[i] = rnd.Next(0,30);

        (matrix Q2, matrix R2) = qrgs.decomp(A2);
        vector x = qrgs.solve(Q2, R2, b);
        vector Ax = A2*x;
        WriteLine($"Is A * x = b? {Ax.approx(b)}");

        // -------------- check inverse ---------------------

        // might as well just use same values as above

        WriteLine("Now check inverse function");
        matrix A2inv = qrgs.inverse(Q2, R2);
        
        matrix A2A2inv = A2 * A2inv;

        WriteLine($"Is A2 * A2inv same as I? {matrix.id(n2).approx(A2A2inv)}");
    }
}
