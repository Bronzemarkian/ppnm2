using static System.Console;


public class main{
    public static int i=1; 
    public static void Main(){
        macheps();
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

    public static void macheps(){
        double x = 1;
        while(1+x!=x){x/=2;}
        x *= 2;
        Write("Machine epsilon for double is {0}\n",x);

        /* float y = 1F;
        while ((float)(1F+y) != 1F){y/=2F;}
        y *= 2F;
        Write("Machine epsilon for float is {0}\n",y); */
    }

}

