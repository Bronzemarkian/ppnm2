using static System.Console;
using static System.Math;

public class main{

    static void Main(){
        for(double x=0;x<2.5;x+=0.02){
            WriteLine($"{x} {erf.Main(x)}");
        }
    }

}