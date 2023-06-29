using System;
using static System.Console;

public class main{

    public static void Main(){
        
        //Test();
        // ------------- check decomp -------------------------------

        Random rnd = new Random();
        int m = rnd.Next(5,10);
        int n = rnd.Next(m+1,20);
        matrix A = new matrix(n, m);
        for(int i=0;i<A.size1;i++){
            for(int k=0;k<A.size2;k++){
                A[i,k] = rnd.Next(0,30);
            }
        }

        WriteLine("The randomly generated tall matrix A is:");
        A.print();
        
        // I now utilize my decomp function in the qrgs class.
        (matrix Q, matrix R) = qrgs.decomp(A);

        WriteLine($"After performing decomp, the matrix R is given as:");
        R.print();

        WriteLine("It can be seen that R is indeed upper triangular");

        WriteLine("The matrix Q is:");
        Q.print();
        WriteLine("Now to check that Q * Q^T is indeed equal to the idendity matrix. Using approx from the matrix class:");
        matrix QTQ = Q.T * Q;
        WriteLine($"Is Q^T * Q = 1? {QTQ.approx(matrix.id(Q.size2))}");
        matrix QR = Q*R;
        WriteLine($"Now to check that Q * R = A");
        WriteLine($"Is Q * R = A? {A.approx(QR)}");

        // --------------- check solve ----------------------

        int n2 = rnd.Next(4,10);
        matrix A2 = new matrix(n2, n2);
        for(int i=0;i<n2;i++){
            for(int k=0;k<n2;k++){
                A2[i,k] = rnd.Next(0,30);
            }
        }

        WriteLine("Now for checking solve. The square matrix A2 is:");
        A2.print();

        vector b = new vector(n2);
        for(int i=0;i<n2;i++) b[i] = rnd.Next(0,30);
        WriteLine("And the corresponding randomly generated vector b is:");
        b.print();

        (matrix Q2, matrix R2) = qrgs.decomp(A2);
        vector x = qrgs.solve(Q2, R2, b);
        vector Ax = A2*x;
        WriteLine("After getting Q2 and R2, qrgs.solve is used, and the x we get is:");
        x.print();
        WriteLine($"Is A * x = b? Using approx: {Ax.approx(b)}");

        // -------------- check inverse ---------------------

        // might as well just use same values as above

        WriteLine("Now for part b, checking the inverse. I use the same matrix A2 from before.");
        matrix A2inv = qrgs.inverse(Q2, R2);
        
        WriteLine("The inverse matrix of A2 is:");
        A2inv.print();

        matrix A2A2inv = A2 * A2inv;

        WriteLine($"Is A2 * A2inv same as I? Using approx: {matrix.id(n2).approx(A2A2inv)}");
    }
}
