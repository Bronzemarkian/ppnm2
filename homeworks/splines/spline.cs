using System;
using static System.Console;

public class spline{

    public static double linterp(vector x, vector y, double z){
        int i = binsearch(x,z);
        double dx = x[i+1]-x[i]; 
        double dy = y[i+1] - y[i];
        double pi = dy/dx;
        return y[i] + pi*(z - x[i]);
    }

    public static double linterpInteg(vector x, vector y, double z){
        
        int j = binsearch(x,z);

        double integral = 0;
        for(int i=0;i<j+1;i++){
            double dx = x[i+1]-x[i]; 
            double dy = y[i+1] - y[i]; 
            double pi = dy/dx;
            // if z is not in interval:
            if(z >= x[i+1]) integral += (y[i]-pi*x[i])*dx + pi/2*(x[i+1]*x[i+1]-x[i]*x[i]);
            // if z is in interval:
            else integral += (y[j]-pi*x[j])*(z-x[j]) + pi/2*(z*z-x[j]*x[j]);
        }
        return integral;
    }

    public static int binsearch(vector x, double z){
        // we find the interval wherein z lies
        if(x[0] > z || z > x[x.size-1]) throw new Exception("z not in interval of points");
        /* can make search by just going through x one by one, but more effective
        to move each edge towards the middle! */
        int i = 0; 
        int j = x.size-1;
        while(j-i>1){
            int mid = (i+j)/2;
            if(z>x[mid]) i = mid; else j = mid;
        }
        return i;
    } // binsearch

}

public class qspline{
    public vector x,y,b,c;
    public qspline(vector xs, vector ys){
        x = xs.copy(); // needed to "give" our xs to x. Initialize
        y = ys.copy(); // needed to "give" our ys to y. Initialize

        int n = xs.size-1;  // since there are more x's than corresponding c's and b's.

        c = new vector(n); // Again to initialize, to tell it that c above is a vector(n). Same for b.
        b = new vector(n);

        // first c[0] = 0.
        c[0] = 0;
        for(int i=0; i<n-1; i++){
            double dxi = xs[i+1] - xs[i];
            double dxip1 = xs[i+2] - xs[i+1]; // ip1 = i+1
            double dyi = ys[i+1] - ys[i];
            double dyip1 = ys[i+2] - ys[i+1];
            double pi = dyi/dxi;
            double pip1 = dyip1/dxip1;
            c[i+1] = 1/dxip1*(pip1-pi-c[i]*dxi);
        }
        // then for c[-1] = 0. Use b as placeholder, and also average c
        b[n-1] = 0;
        c[n-1] = c[n-1]/2.0;
        for(int j = n-2; j>-1; j--){
            double dxi = xs[j+1] - xs[j];
            double dxip1 = xs[j+2] - xs[j+1];
            double dyi = ys[j+1] - ys[j];
            double dyip1 = ys[j+2] - ys[j+1];
            double pi = dyi/dxi;
            double pip1 = dyip1/dxip1;
            b[j] = 1/dxi*(pip1-pi-b[j+1]*dxip1);
            c[j] = (c[j]+b[j])/2.0;
        }
        // now calculate b
        for(int k = 0; k < n; k++){
            double dxi = xs[k+1] - xs[k];
            double dyi = ys[k+1] - ys[k];
            double pi = dyi/dxi;
            b[k] = pi - c[k]*dxi;
        }
    } // qspline

    public double evaluate(double z){
        int ival = binsearch(z); // interval, ival
        return y[ival]+b[ival]*(z-x[ival]) + c[ival]*(z-x[ival])*(z-x[ival]);
    }

    public double derivative(double z){
        int ival = binsearch(z); // find interval
        return b[ival] + 2*c[ival]*(z-x[ival]);
    }

    public int binsearch(double z){
        // we find the interval wherein z lies
        if( x[0] > z || z > x[x.size-1] ) throw new Exception("z not in interval of points");
        /* can make search by just going through x one by one, but more effective
        to move each edge towards the middle! */
        int i = 0; 
        int j = x.size-1;
        while(j-i>1){
            int mid = (i+j)/2;
            if(z>x[mid]) i = mid; else j = mid;
        }
        return i;
    }

}
