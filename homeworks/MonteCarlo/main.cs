using System;
using static System.Console;
using static System.Math;

/*
Right now my problem is that both my actual error and the estimated error just seem wrong on the plot?

*/

public class main{

    public static void Main(){

        WriteLine("To calculate the unit circle with the monto carlo approach, I make a function that");
        WriteLine("returns 1 if the length of the vector is below 1, else it returns 0.");
        Func<vector,double> UnitCircle = delegate(vector z){
            if (z.norm()<=1) return 1;
            else return 0;
        };
        vector a = new vector(-1,-1); // starting point of each dimension
        vector b = new vector(1,1);   // endpoint of each dimension
        int N = (int)10e6;

        (double integral, double error) = mc.plainmc(UnitCircle,a,b,N);

        WriteLine($"MC integral of the unit circle is {integral} with estimated error {error} \n");

        var outfile = new System.IO.StreamWriter("error.data");
        var outfile2 = new System.IO.StreamWriter("estimated_error.data");
        //outfile.WriteLine("Error Estimated error");
        for(int i=(int)1;i<10e5;i*=2){
        (double integral2, double error2) = mc.plainmc(UnitCircle,a,b,i);
        outfile.WriteLine($"{Log10(i)} {Abs(PI-integral2)}");
        outfile2.WriteLine($"{Log10(i)} {error2}");
        }
        outfile.Close();
        outfile2.Close();
        var outfile3 = new System.IO.StreamWriter("one_over_n.data");
        for(double i=1;i<10e5;i*=1.5) outfile3.WriteLine($"{Log10(i)} {1/Sqrt(i)}");
        outfile3.Close();

        WriteLine("I also tested the monto carlo approach on the unit circle with different values of N.");
        WriteLine("A plot of the actual errors and estimated errors, aswell as the line 1/Sqrt(N) can be seen on mc.svg \n");

        // now to try calculating the given integral.

        Func<vector,double> func2 = delegate(vector z){return 1/PI/PI/PI/(1-Cos(z[0])*Cos(z[1])*Cos(z[2]));};
        vector a2 = new vector(0,0,0);
        vector b2 = new vector(PI, PI, PI);

        (double integral3, double error3) = mc.plainmc(func2,a2,b2,N);

        WriteLine($"MC integral of the given integral is {integral3} with estimated error {error3} \n");

        WriteLine("Now for part B) \n"); // ---------------    b)

        WriteLine("I've implemented the quasi-random one, and will now do another convergence test.");
        WriteLine("The test is again of the unit circle, and can be seen on mcq.svg");
        
        var outfile4 = new System.IO.StreamWriter("error2.data");
        var outfile5 = new System.IO.StreamWriter("estimated_error2.data");
        //outfile.WriteLine("Error Estimated error");
        for(int i=(int)1;i<10e5;i*=2){
        (double integral4, double error4) = mc.quasimc(UnitCircle,a,b,i);
        outfile4.WriteLine($"{Log10(i)} {Abs(PI-integral4)}");
        outfile5.WriteLine($"{Log10(i)} {error4}");
        }
        outfile4.Close();
        outfile5.Close();

        WriteLine("Furthermore, a comparrison between convergence of the plain and quasi can be seen on compare.svg");


    }

}