using System;
using static System.Console;
using System.Collections.Generic;
using static System.Math;

public class rkstep12{

    public static (vector, vector) Rkstep12(
        Func<double, vector, vector> f, // f from dy/dx = f(x,y)
        double x,
        vector y,
        double h
    ){

        vector k0 = f(x,y);
        vector k1 = f(x + h/2, y + k0*h/2);
        vector yh = y + k1*h;
        vector yerr = h*(k1-k0); // yh-y-h*k0 = y+k1*h-y-k0*h = h(k1-k0)
        return (yh, yerr);
    }

    public static (dynamic, dynamic) driver(
        Func<double, vector, vector> f,
        double a, vector ya, double b,
        List<double> xlist = null, List<vector> ylist = null,
        double h = 0.01, double acc = 0.01, double eps = 0.01
    ) {

        if(a>b) throw new ArgumentException("driver: a > b");
        
        double x=a; vector y=ya.copy();
        if( xlist != null) {xlist.Add(x); ylist.Add(y);}

        do{
            if(x>=b){
                if(xlist != null) return (xlist, ylist);
                else{ return (x, y);}
            } //already finished then
            if(x+h>b) h = b-x; //make last h fit

            var (yh, erv) = Rkstep12(f, x, y, h);

            var tol = new vector(y.size);
            for(int i=0;i<y.size;i++) tol[i] = (acc + eps*Abs(yh[i]))*Sqrt(h/(b-a));
            bool ok = true;
            for(int i=0;i<y.size;i++) if( erv[i] > tol[i]) ok = false;
            if(ok){
                x+=h;y=yh;
                if( xlist != null) {xlist.Add(x); ylist.Add(y);}
            }

            double factor = tol[0]/Abs(erv[0]);
            for(int i=1;i<y.size;i++) factor = Min(factor,tol[i]/Abs(erv[i])); // find minimum

            h *= Min( Pow(factor,0.25) * 0.95, 2); //readjust stepsize

        }while(true);
    } // driver

}


