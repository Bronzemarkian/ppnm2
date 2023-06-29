using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public class main{

    public static void Main(){

        WriteLine("I have written a program that searches through the objective function using the alloted");
        WriteLine("time, and then compares the new-found point with the best point found so far. If the new");
        WriteLine("point has a lower function-value than the previous best-point, the new point is updated");
        WriteLine("to be the current point. Once the time is up, minimization is then performed on the best point.");
        WriteLine("The points are found by using a low-discrepancy sequence, in particular the halton sequence,");
        WriteLine("as described in the Monte Carlo chapter.");

        WriteLine("First I will check it on a 1d and a 2d function I made.\n");

        Func<vector,double> f1 = delegate(vector z){
            double x = z[0];
            return Pow(x,4)-3*x*x*x+2*x;
        };

        vector start = new vector(-4.0), end = new vector(4.0);
        double t1 = 0.5;
        vector glob_min = optimize.global_optimize(f1,t1,start,end);

        WriteLine($"Global minimum of x^4-3x^3+2x is {glob_min[0]}");
        WriteLine($"Now to test a two-dimensional function.");

        Func<vector,double> f2 = delegate(vector z){
            double x = z[0], y = z[1];
            return x*Sin(x) + y*Sin(y);
        };
        double t2 = 0.5;
        vector start2 = new vector(-5,-5), end2 = new vector(5,5);
        vector glob_min2 = optimize.global_optimize(f2,t2,start2,end2);

        WriteLine($"Global minimum of 2x^3+6xy^2-3y^3-150x is {(glob_min2[0],glob_min2[1])}");

        // Now going through some of the test functions for optimization from wikipedia

        WriteLine("\nI will now go through some test functions for optimization found on wikipedia.");

        Func<vector,double> ackley = delegate(vector z){
            double x = z[0], y = z[1];
            return -20*Exp(-0.2*Sqrt(0.5*(x*x+y*y)))-Exp(0.5*(Cos(2*PI*x)+Cos(2*PI*y)))+Exp(1)+20;
        };
        vector start_ackley = new vector(-5,-5), end_ackley = new vector(5,5);
        double t_ackley = 0.5;
        vector ackley_min = optimize.global_optimize(ackley,t_ackley,start_ackley,end_ackley);
        WriteLine($"Global minimum of ackley function is {(ackley_min[0],ackley_min[1])} \n with f(x) = {ackley(ackley_min)}");

        Func<vector,double> Beale = delegate(vector z){
            double x = z[0],y = z[1];
            return Pow(1.5-x+x*y,2) + Pow(2.25 - x + x*y*y,2) + Pow(2.625-x+x*y*y*y,2);
        };
        vector start_Beale = new vector(-4.5,-4.5), end_Beale = new vector(4.5,4.5);
        double t_Beale = 1;
        vector Beale_min = optimize.global_optimize(Beale,t_Beale,start_Beale,end_Beale);
        WriteLine($"Global minimum of Beale function is {(Beale_min[0],Beale_min[1])} \n with f(x) = {Beale(Beale_min)}");

        WriteLine("\nThese results all match with the already-known global minimum of the functions,");
        WriteLine("where I have used an accuracy of 0.001.");
    }

}