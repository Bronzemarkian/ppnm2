using System;
using static System.Console;
using static System.Math;

public class main{

    public static void Main(){

        Func<vector,double> f1 = delegate(vector z){ return z[0]*z[0];};
        vector x0 = new vector(2.0);
        double acc = 0.0001;

        vector min1 = minimize.qnewton(f1,x0,acc);

        WriteLine($"The minimum of x^2 is {min1[0]}, with a starting guess of x = 2 \n");

        // RosenBrock Valley
        Func<vector, double> f2 = delegate(vector z) { return (1-z[0])*(1-z[0])+100*Pow((z[1]-z[0]*z[0]),2);};
        vector xy0 = new vector(2,2);
        vector min2 = minimize.qnewton(f2,xy0,acc);
        WriteLine($"The minimum of Rosenbrock Valley's function is {(min2[0],min2[1])}");
        WriteLine($"with a starting guess of (2,2) \n");

        // Himmelblau
        Func<vector,double> f3 = delegate(vector z) {
            double x = z[0], y = z[1];
            return Pow(x*x+y-11,2) + Pow(x+y*y-7,2);
        };
        vector xy02 = new vector(2,2);
        vector min3 = minimize.qnewton(f3,xy02,acc);
        WriteLine($"The minimum of Himmelblau Valley's function is {(min3[0],min3[1])}");
        WriteLine($"with a starting guess of (2,2). It also has 3 more minima, which I will find:");

        vector xy03 = new vector(-2, 2);
        vector xy04 = new vector(2, -2);
        vector xy05 = new vector(-4, -2);
        vector min32 = minimize.qnewton(f3,xy03,acc);
        vector min33 = minimize.qnewton(f3,xy04,acc);
        vector min34 = minimize.qnewton(f3,xy05,acc);
        WriteLine($"With guess of (-2,2) the minimum found is {(min32[0], min32[1])}");
        WriteLine($"With guess of (2,-2) the minimum found is {(min33[0], min33[1])}");
        WriteLine($"With guess of (-4,-2) the minimum found is {(min34[0], min34[1])}");
        


    }

}