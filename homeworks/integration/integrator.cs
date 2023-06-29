using System;
using static System.Console;
using static System.Math;

public class integrator{

    public static (double,int) integrate(
        Func<double,double> f, 
        double a, double b, 
        int n = 1,
        double delta = 0.001, // absolute accuracy
        double epsilon = 0.001, // relative accuracy
        double f2 = double.NaN, double f3 = double.NaN
    )
    {
        double h = b-a;
        if(Double.IsNaN(f2)){f2 = f(a+2*h/6); f3 = f(a+4*h/6); } // make arbitrary n, here 4
        double f1 = f(a+h/6), f4 = f(a+5*h/6);
        double Q = (2*f1+f2+f3+2*f4)/6*h; // sum of weight*points. Trapezium rule
        double q = (  f1+f2+f3+  f4)/4*h; // rectangle rule
        double err = Abs(Q-q); double tol = delta + epsilon*Abs(Q);

        if(err <= tol) return (Q,n);
        else {
            (double Q1, int n1) = integrate(f,a,(a+b)/2,n+1,delta/Sqrt(2),epsilon,f1,f2);
            (double Q2, int n2) = integrate(f,(a+b)/2,b,n+1,delta/Sqrt(2),epsilon,f3,f4);
            // if region halfed, the old f1 is 'twice as far' over, so the new f2.
            // likewise, old f2 is the new f3, and same argument for the second half.
            return (Q1 + Q2, n1 + n2);
        }
    }

    public static (double, int) Clenshaw( Func<double,double> func, double a, double b)
        {
        Func<double,double> f = delegate(double x){return func((a+b)/2+(b-a)/2*Cos(x))*Sin(x)*(b-a)/2;};
        return integrate(f,0,PI);
    }
}
