using System;
using static System.Console;
using static System.Math;

public class rootfinder{

    public static vector newton(Func<vector,vector> f, vector x, double eps = 1e-3, int maxIt = 10000){

        int n = f(x).size;
        int m = x.size;
        matrix J = new matrix(n,m);
        int it = 0;
        do{
            it++;
            vector fx = f(x);
            for(int i=0;i<n;i++){
                for(int j=0;j<m;j++){
                    double dx = Max(Abs(x[j])*Pow(2,-26),Pow(2,-26));
                    x[j] += dx;
                    J[i,j] = (f(x)[i]-fx[i])/dx;
                    x[j] -= dx;
                }
            }

            (matrix Q, matrix R) = qrgs.decomp(J);
            vector xs = qrgs.solve(Q, R, -f(x));

            // linesearch to find l
            double l = 2;
            do{
                l /= 2;
            }
            while( f(x+l*xs).norm() > (double)(1-l/2)*f(x).norm() && l >= 1.0/1024 );
            x += l*xs;
        }
        while(f(x).norm() > eps && it <= maxIt);

        if(it>maxIt) throw new ArgumentException($"Maximum allowed number of iterations {maxIt} exceeded");

        return x;
    }

}

