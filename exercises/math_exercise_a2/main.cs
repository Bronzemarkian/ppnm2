using static System.Math;
using static System.Console;
//using static sfuns;

public class main{

    public static double sqrt2 = System.Math.Sqrt(2.0);

    public static void Main(){
        Write($"The value of the square root of 2 is {sqrt2} \n");
        Write("The value of 2 to the power of 1/5 is {0}\n",
        Pow(2,(double)1/5)
        );
            // can also do 2.0 and 0.2 instead of the (double)
        Write("The value of e to the power of pi is {0}\n",
            Pow(E,PI)
            );
        Write("The value of pi to the power of e is {0}\n",
            Pow(PI, E)
            );
        
        gamma_func(1);
        gamma_func(2);
        gamma_func(3);
        gamma_func(10);

        ln_gamma_func(1);
        ln_gamma_func(2);
        ln_gamma_func(3);
        ln_gamma_func(10);

    }

    public static void gamma_func(double x){
        Write($"Gamme of 1 is {gamma(x)}\n");
    }

    public static void ln_gamma_func(double x){
        Write($"Gamme of 1 is {Log(gamma(x))}\n");
    }

}