using System;
using static System.Console;
using System.Collections.Generic;

public class main{

    public static void Main(string[] args){

        double z = 0;
        foreach(string arg in args){
		    var words=arg.Split(':');
		    if(words[0]=="-z")z=double.Parse(words[1]);
	    }

        List<double> xlist = new List<double>(); // since unknown length of input
        List<double> ylist = new List<double>();

        for(string line = ReadLine(); line!=null; line=ReadLine()){
            var numbers=line.Split(' ');
            xlist.Add( double.Parse(numbers[0]) );
            ylist.Add( double.Parse(numbers[1]) );}

        vector xs = new vector(xlist.Count); // want to work with vectors
        vector ys = new vector(ylist.Count);

        Error.WriteLine("The first set of x and y values I work with are ones I gave on my Makefile.");

        for(int i=0;i<xs.size;i++){
            xs[i] = xlist[i];
            ys[i] = ylist[i];
            Error.WriteLine($"I used: x[{i}]: {xs[i]} and y[{i}]: {ys[i]}");
        }

        Error.WriteLine("The plot of this can be seen on lspline.svg together with the quadratic spline from b)");


        // Calculating the integral:
        Error.WriteLine($"The integral of the linear spline from {xs[0]} to {z} is {spline.linterpInteg(xs, ys, z)}");

        ///////////////////////  now for b) //////////////////////////

        Error.WriteLine("Now I start on the qspline, which I have made as a class. The plot of the qspline on");
        Error.WriteLine("the same points as my linear spline can be seen on lspline.svg");

        qspline myspline = new qspline(xs, ys);

        // now for plotting both a and b)

        for(double x = xs[0]; x < xs[xs.size-1];x += 0.1){
            WriteLine($"{x} {spline.linterp(xs,ys,x)} {myspline.evaluate(x)}");
        }

        Error.WriteLine("I also want to test it on the x-y tables given on the homework-page. The result can");
        Error.WriteLine("be seen on qspline_test.svg");
        // want to test with some different sets of x and y. Make datapoints
        vector xss = new vector(5), y1 = new vector(5), y2 = new vector(5), y3 = new vector(5);
        var outfile = new System.IO.StreamWriter("qspline_points.data");
        for(int j = 0; j <5; j++){
            xss[j] = j+1; 
            y1[j] = 1; y2[j] = j+1; y3[j] = (j+1)*(j+1);
            outfile.WriteLine($"{xss[j]} {y1[j]} {y2[j]} {y3[j]}");
        }
        outfile.Close();

        qspline myspline1 = new qspline(xss, y1);
        qspline myspline2 = new qspline(xss, y2);
        qspline myspline3 = new qspline(xss, y3);

        var outfile2 = new System.IO.StreamWriter("qspline_test.data");
        for(double k = xss[0]; k < xss[xss.size-1];k += 0.1){
            outfile2.WriteLine($"{k} {myspline1.evaluate(k)} {myspline2.evaluate(k)} {myspline3.evaluate(k)}");
        }
        outfile2.Close();

    }// Main

}