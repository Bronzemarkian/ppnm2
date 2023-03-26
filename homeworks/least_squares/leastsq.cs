using System;
public class leastsq{

    public static vector lsfit(Func<double,double>[] fs, vector x, vector y, vector dy){
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
        return c;
    }
}