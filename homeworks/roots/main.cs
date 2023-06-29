using System;
using static System.Console;

public class main{
    
    public static void Main(){

        vector x0 = new vector(15.0);
        

        WriteLine("hey");

        vector x1 = rootfinder.newton(f1,x0);

        WriteLine($"Solution to 1-x^2 is: {x1[0]}");

    }

    public static System.Func<vector,vector> f1 = delegate(vector x){
        //return new vector(1-x[0]*x[0]);
        return new vector(1-x[0]*x[0]);
    };
}
