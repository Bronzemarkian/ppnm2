using System;
using static System.Console;
using static System.Math;

public class main{
    
    public static void Main(){

        vector x0 = new vector(15.0);
        vector x1 = rootfinder.newton(f1,x0);

        WriteLine("First I try to find the solution to 1-x^2, which is a simple 1d equation.");
        x1.print("One solution to 1-x^2 is:");

        vector x02 = new vector(-15.0);
        vector x1_2 = rootfinder.newton(f1,x02);
        x1_2.print("The other solution is:");
        WriteLine("And these are exactly the two solutions we already know.\n");

        // now for the Rosenbrock Valley function:

        Func<vector,vector> f2 = delegate(vector z) {
            double x = z[0], y = z[1];
            return new vector(2-2*x-400*x*Pow(y-x*x,2),200*Pow(y-x*x,2));
        };

        WriteLine("I now try to find the extrenums to the rosenbrock valley function. I do this by looking");
        WriteLine("at the roots of the gradient");

        vector x0_2 = new vector(2,2);
        vector x2 = rootfinder.newton(f2,x0_2);
        x2.print("Solution to rosenbrock with guess (2,2) is=");
        f2(x2).print("f(x_sol)=");

        WriteLine("\n This is also equal to the global minimum. No matter what else my starting-guess");
        WriteLine("is, this is the only root I get.");
    }

    public static System.Func<vector,vector> f1 = delegate(vector x){
        //return new vector(1-x[0]*x[0]);
        return new vector(1-x[0]*x[0]);
    };
}
