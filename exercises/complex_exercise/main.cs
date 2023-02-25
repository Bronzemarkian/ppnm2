using System;
using static System.Console;
using static System.Math;

public class main{
    
    
    public static void Main(){

        complex x = new complex(-1,0);
        WriteLine($"sqrt of -1: {cmath.sqrt(x)}"); // ugly solution!

        complex y = cmath.sqrt(complex.I);
        WriteLine($"sqrt of i: {y}");  

        complex z = cmath.exp(complex.I);
        WriteLine($"exp(i): {z}");  

        complex a = cmath.exp(complex.I*PI);
        WriteLine($"exp(i*PI): {a}");  

        complex b = cmath.pow(complex.I,complex.I);
        WriteLine($"i^i: {b}");

        complex c = cmath.log(complex.I);
        WriteLine($"ln(i): {c}");

        complex d = cmath.sin(complex.I*PI);
        WriteLine($"sin(i*PI): {d}");      

        complex e = cmath.cosh(complex.I);
        WriteLine($"cosh(i): {e}");  

        complex f = cmath.sinh(complex.I);
        WriteLine($"sinh(i): {f}");  

    }

    
}