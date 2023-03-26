using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public class main{

    public static void Main(string[] args){

        List<string> inputs = new List<string>();

        for(string line = ReadLine(); line!=null;line=ReadLine()){
            inputs.Add(line);
        }

        int n = inputs.Count;
        vector x = new vector(n);
        vector y = new vector(n);
        vector dy = new vector(n);

        for(int i=0; i<n; i++){
            string[] numbers = inputs[i].Split(' ');
            x[i] = double.Parse(numbers[0]);
            y[i] = double.Parse(numbers[1]);
            dy[i] = double.Parse(numbers[2]);
        }

        // we want to plot with log, so:
        vector logy = new vector(n);
        vector dlogy = new vector(n);
        for(int i=0; i<n; i++){
            logy[i] = Log(y[i]);
            // and error propagation:
            dlogy[i] = dy[i]/y[i];
        }
        // we give to functions, 1 and -z, so we will get back c1 - c2*z, and when exp is
        // taken, exp(c1-c2*z) = exp(c1)*exp(-c2*z), on form a*exp(-lambda*z)
        var fs = new System.Func<double,double>[] { z => 1.0, z=> -z};

        vector c = leastsq.lsfit(fs, x, logy, dlogy);
    
        // now we try to plot, with exp of course.

        var fexp = new System.Func<double,double>[] {z => Exp(c[0]-z*c[1])};
        // WriteLine("constants c is");
        // for(int i=0;i<c.size;i++) WriteLine($"{c[i]}");
        Plot(fexp);
    }

    public static void Plot(Func<double,double>[] f){
        for(double x=1;x<16;x+=0.2){
            WriteLine($"{x} {f[0](x)}");
        }
    }

}
