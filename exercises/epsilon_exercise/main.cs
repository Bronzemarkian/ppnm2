using static System.Console;
using static System.Math;


public class main{
    public static int i=1; 
    public static void Main(){
        double ep = macheps();  // so use other func in class to get number

        Write("it is {0}\n",ep);

        double tiny = ep/2;
        int n=(int)1e6;
        double sumA=0,sumB=0;

        sumA += 1; for(int i=0;i<n;i++){sumA+=tiny;}
        for(int i=0;i<n;i++){sumB+=tiny;} sumB +=1;

        WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
        WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");

        // this gives two different outputs, because once 1 is added the
        // number of digits increases above what is memorized, and thus the
        // last few ones are cut out. But if we first add the tiny number
        // together a lot of times, it will get big enough such that once
        // one is added, not all decimals will be 'lost'.

        WriteLine($"{approx(sumA,sumB)}");

    }

    public static void max_int(){
        while(i + 1 > i){i++;}
        
        Write("my max int = {0}\n",i);

        Write("int.Maxvalue gives {0}\n",int.MaxValue);
    }

    public static void min_int(){
        while(i - 1 < i){i--;}
        
        Write("my max int = {0}\n",i);

        Write("int.Maxvalue gives {0}\n",int.MinValue);
    }

    public static double macheps(){
        double x = 1;
        while(1+x!=1){
		x/=2;
		}
        x *= 2;
        Write("Machine epsilon for double is {0}\n",x);

        float y = 1F;
        while ((float)(1F+y) != 1F){y/=2F;}
        y *= 2F;
        Write("Machine epsilon for float is {0}\n",y);
        Write("Should be approx {0}\n",System.Math.Pow(2,-23));

        return x;
    }

    public static bool approx(double a, double b, double acc = 1e-9,
        double eps=1e-9){
            if(Abs(b-a)<=acc) return true;
            else if(Abs(b-a)/( Max(Abs(a),Abs(b)) ) <= eps ) return true;
            else return false; 
            
    }

}

