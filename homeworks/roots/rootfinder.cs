using System;
using static System.Console;
using static System.Math;

public class rootfinder{

    public static vector newton(Func<vector,vector> f, vector x, double eps = 1e-2, int maxIt = 10000){

        int n = f(x).size;
        int m = x.size;
        matrix J = new matrix(n,m);
        int it = 0;
        do{
            it++;
            for(int i=0;i<n;i++){
                for(int j=0;j<m;j++){
                    double dx = Abs(x[j])*Pow(2,-26);
                    vector x2 = x.copy();
                    x2[j] += dx;
                    J[i,j] = (f(x2)[i]-f(x)[i])/dx;
                }
            }
	    x.print("x=");
	    J.print("J=");
	    WriteLine($"deriv(1-x^2) = {-2*x[0]}");

            (matrix Q, matrix R) = qrgs.decomp(J);
            // Q*R*dx = -f(x) => R*dx = -Q^T*f(x)
            vector b = Q.T*f(x);
            vector xs = qrgs.solve(Q, R, b);
            xs.print("newtons step=");
            vector Jx = J*xs;
            Jx.print("Jx= ");
            b.print("b= ");
            WriteLine($"Is A * x = b? Using approx: {Jx.approx(b)}");

            // linesearch to find l
            double l = 2;
            do{
                l /= 2;
            }
            while( f(x+l*xs).norm() > (double)(1-l/2)*f(x).norm() && l >= 1.0/1024 );
            x += l*xs;
            WriteLine($"x: {x[0]}, xs {xs[0]} and l: {l}, should at least be {1.0/1024}");
        }
        while(f(x).norm() > eps && it <= maxIt);

        if(it>maxIt) throw new ArgumentException($"Maximum allowed number of iterations {maxIt} exceeded");

        return x;
    }

}

