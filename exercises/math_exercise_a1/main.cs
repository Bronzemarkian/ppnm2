
using static System.Math;

public class main{

    public static double sqrt2 = System.Math.Sqrt(2.0);

    public static void Main(){
        System.Console.Write(
            $"The value of the square root of 2 is {sqrt2} \n");
        System.Console.Write(
            "The value of 2 to the power of 1/5 is {0}\n",
            System.Math.Pow(2,(double)1/5)
            );
            // can also do 2.0 and 0.2 instead of the (double)
        System.Console.Write(
            "The value of e to the power of pi is {0}\n",
            System.Math.Pow(System.Math.E,System.Math.PI)
            );
        System.Console.Write(
            "The value of pi to the power of e is {0}\n",
            System.Math.Pow(System.Math.PI, System.Math.E)
            );

        Main2();


    }

    static double gamma(double x){
            ///single precision gamma function (formula from Wikipedia)
            if(x<0)return PI/Sin(PI*x)/gamma(1-x); // Euler's reflection formula
            if(x<9)return gamma(x+1)/x; // Recurrence relation
            double lngamma=x*Log(x+1/(12*x-1/x/10))-x+Log(2*PI/x)/2;
            return Exp(lngamma);
        }



    public static void Main2(){
        System.Console.Write($"Gamma of 1 is {gamma(1.0)}\n");
        System.Console.Write($"Gamma of 2 is {gamma(2.0)}\n");
        System.Console.Write($"Gamma of 3 is {gamma(3.0)}\n");
        System.Console.Write($"Gamma of 10 is {gamma(10.0)}\n");
    }

}