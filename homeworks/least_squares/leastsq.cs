using System;
using static System.Math;
using static System.Console;
public class leastsq{

    public static (vector, vector, matrix) lsfit(Func<double,double>[] fs,
                                    vector x, vector y, vector dy){
        int n = x.size, m = fs.Length;
        matrix A = new matrix(n,m);
        vector b = new vector(n);
        for(int i=0;i<n;i++){  // make matrix A
            for(int k=0;k<m;k++){
                A[i,k] = fs[k](x[i])/dy[i];
            }
        }
        for(int i=0; i<n; i++) b[i] = y[i]/dy[i]; // make vector b
        // now solve the equation:
        (matrix Q, matrix R) = qrgs.decomp(A);
        vector c = qrgs.solve(Q, R, b);

        // Q.print();
        // R.print();

        // matrix Ainv = qrgs.inverse(Q,R);
        // Ainv.print();
        
        (matrix QR, matrix RR) = qrgs.decomp(R);
        matrix Rinv = qrgs.inverse(QR,RR);
        matrix cov = Rinv*Rinv.T;

        // matrix covinv = R.T*R;
        // (matrix Qcov, matrix Rcov) = qrgs.decomp(covinv);
        // matrix cov = qrgs.inverse(Qcov, Rcov);

        vector dc = new vector(c.size);
        for(int i=0; i<c.size;i++) dc[i] = Sqrt(cov[i,i]);
        return (c,dc,cov);
    }
}