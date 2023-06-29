using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public class main{

    public static void Main(){

        double a = 1; double b = 4; // solution from a to b
        vector ya = new vector(0.0,1.0); // y(a) = (u(a),u'(a))

        List<double> xss = new List<double>();
        List<vector> yss = new List<vector>();
        (List<double> xs, List<vector> ys) = rkstep12.driver(fs, a, ya, b,xss,yss);

        WriteLine("The driver as well as the stepper is made, and it is used on the ODE u'' = -u.");
        WriteLine("From u'' = -u we get, with y = (y1,y2), that y' = M*y, where M = [[0,0],[-1,0]],");
        WriteLine("and we get the two equations y1' = y2 and y2' = -y1. So when we give y,");
        WriteLine("it should return (y2,-y1), so that is the function I use.");
        WriteLine("I use the starting conditions u=0 and u'=1, and the solution can be seen on test.svg");

        var outfile = new System.IO.StreamWriter("test.data");
        for(int i=0;i<xs.Count;i++) outfile.WriteLine($"{xs[i]} {ys[i][0]}");
        outfile.Close();

        WriteLine("\nFor the oscillator, I followed the example and the solution can be seen on oscillator.svg");
        oscillator();

        // ----------------    b)  -----------------------

        WriteLine("\nNow for b! I've implemented so that only the final value of y is returned if no list is given.");

        (double xsol, vector ysol) = rkstep12.driver(fs,a,ya,b);
        WriteLine($"So the solution for u''=-u at x = {xsol} is u = {ysol[0]} and u' = {ysol[1]}\n");
        WriteLine("Now for the problem of equatorial motion.");
        WriteLine("When I plot, I plot r and r', since r = 1/u and r' = u' * r^2 \n");

        a = 0; b = 4*PI;
        double etha = 0; 
        ya[0] = 1; ya[1] = 0;
        WriteLine($"I look at phi from {a} to {b}, with y1={ya[0]} and y2={ya[1]}, etha={etha}. Can be seen on b1.svg. \n");
        GenRel(etha, a, ya, b, "b1.data");

        ya[1] = -0.5;
        GenRel(etha, a, ya, b,"b2.data");
        WriteLine($"Setting u' = -0.5 we now get an elliptical motion, so y2={ya[1]}. Plot can be seen on b2.svg \n");

        etha = 0.1;
        GenRel(etha, a, ya, b, "b3.data");

        WriteLine($"For the third example of relativistic precession of a planetory orbit, the change is etha={etha}, and");
        WriteLine("it can be seen on b3.svg");

    }
    /* so from u'' = -u, we get, with y = (y1,y2) = (u, u'), that y' = M * y, where 
    M = [[0,0],[-1,0]], so two equations: y1'=y2 and y2' = -y1. So when we give it y, 
    it should return (y2, -y1). */
    public static System.Func<double,vector,vector> fs = delegate(double x, vector y){
            return new vector(y[1], -y[0]);
        };

    public static void oscillator(){

        double a = 0; double b = 10;
        vector ya = new vector(PI - 0.1, 0.0);
        List<double> xss = new List<double>();
        List<vector> yss = new List<vector>();
        (List<double> xs, List<vector> ys) = rkstep12.driver(fs2, a, ya, b, xss, yss);

        var outfile2 = new System.IO.StreamWriter("oscillator.data");
        for(int i=0;i<xs.Count;i++) outfile2.WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");
        outfile2.Close();
    }

    public static System.Func<double,vector,vector> fs2 = delegate(double x, vector y){
            double cb = 0.25; double cc = 5;
            return new vector(y[1], -cb * y[1] - cc * Sin(y[0]));
    };

    public static void GenRel(double etha, double a, vector ya, double b, string filename){

        List<double> xss = new List<double>();
        List<vector> yss = new List<vector>();
        (List<double> xs, List<vector> ys) = rkstep12.driver(equatorial(etha), a, ya, b, xss, yss);

        var outfile3 = new System.IO.StreamWriter(filename);
        // I turn u and u' into r and r'.
        for(int i=0;i<xs.Count;i++) outfile3.WriteLine($"{xs[i]} {1/ys[i][0]} {ys[i][1]*ys[i][0]*ys[i][0]}");
        outfile3.Close();

    }

// if I wanted to quickly be done, just make fs3 3 times with different etha. But how can I "give"
// it etha? 

    public static Func<double, vector, vector> equatorial(double etha){

        Func<double,vector,vector> f = delegate(double x, vector y){
            return new vector(y[1],1-y[0]+etha*y[0]*y[0]);};
        return f;
    }


    // public static System.Func<double, vector, vector> fs3 = delegate(double x, vector y){
    //     return new vector(y[1],1-y[0]+etha*y[0]*y[0]);
    // };

}