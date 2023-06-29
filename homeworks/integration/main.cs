using System;
using static System.Console;
using static System.Math;

public class main{

    public static void Main(){

        WriteLine("The integrator is made, and will now be tested on various integrals.");
        double delta = 0.001;
        Func<double,double> f1 = delegate(double x){return Sqrt(x);};
        (double sum1, int n1) = integrator.integrate(f1,0,1);
        WriteLine($"The value of the integral of Sqrt(x) from 0 to 1 is {sum1}, with {n1} integrals calculated,");
        WriteLine($"exact solution being 2/3 and using delta = {delta}");
        WriteLine($"Is it within delta? {approx(sum1,(double)2/3,delta)} \n");

        WriteLine("Next integral is 1/Sqrt(x) from 0 to 1. There is a singularity at 0, so");
        WriteLine("to calculate it I adjust the total accuracy to be less strict, delta = 0.01");
        Func<double,double> f2 = delegate(double x){return 1/Sqrt(x);};
	    double delta2=0.01;
        (double sum2, int n2) = integrator.integrate(f2,0,1,delta:0.01); 
        WriteLine($"The value of the integral of 1/Sqrt(x) from 0 to 1 is {sum2} with {n2} integrals calculated,");
        WriteLine($"exact solution being 2 and using delta={delta2}");
        WriteLine($"Is it within delta? {approx(sum2,2,delta2)} \n");

        Func<double,double> f3 = delegate(double x){return 4*Sqrt(1-x*x);};
        (double sum3, int n3) = integrator.integrate(f3,0,1); 
        WriteLine($"The value of the integral of 4*Sqrt(1-x^2) from 0 to 1 is {sum3} with {n3} integrals calculated,");
        WriteLine($"exact solution being {PI} and using delta={delta}");
        WriteLine($"Is it within delta? {approx(sum3,PI,delta)} \n");

        WriteLine("Now to look at the error function. The plot of it can be seen on erf.svg \n");

        var outfile = new System.IO.StreamWriter("erf.data");
        for(double i=-2;i<=2.01;i += 0.01) outfile.WriteLine($"{i} {erf(i)}");
        outfile.Close();

        // ------------ b) --------------------

        (double sum22, int n22) = integrator.Clenshaw(f2,0,1);
        WriteLine("The Clenshaw is added as a small modification to the input values before the regular integrator is called.");
        
        WriteLine($"The value of the integral of 1/sqrt(x) from 0 to 1 with Clenshaw is {sum22} with {n22} integrals");
        WriteLine($"calculated, and with an exact result of 2.");
        WriteLine($"So using Clenshaw we had to calculate {n22} integrals as compared to {n2}!");

    }


    public static bool approx(double a, double b, double acc = 0.001){
            if(Abs(b-a)<=acc) return true;
            else return false; 
    }

    public static double erf(double z){

        if(z<0) {
            return -erf(-z);
        }
        if(0<=z && z<=1){
            Func<double,double> g1 = delegate(double x){return Exp(-x*x);};
            return 2/Sqrt(PI) * ( integrator.integrate(g1,0,z) ).Item1;
        }

	else{
            Func<double,double> g2 = delegate(double t){return Exp(-Pow(z+((1-t)/t),2))/t/t;};
            return 1-2/Sqrt(PI) * ( integrator.integrate(g2,0,1,delta:0.001) ).Item1;

        }

    }

}
