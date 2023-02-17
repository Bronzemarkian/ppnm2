using System;
using static System.Console;
using static System.Math;

class main{
    public static void Main(){
        Write("hello\n");
        genlist<double> listd = new genlist<double>();
        listd.add(1.0);
        listd.add(2.0);
        listd.add(3.0);
        listd.add(4.0);
        // func takes a double and returns a double. f pointer to func
        Func<double,double> f;
        f = Sin;
        double a=10;
//        f = delegate(double x){return x*a;}; // 'old fashioned way'
        f = (double x) => x*a; // 'modern notation'
        // a in function above only a pointer, not returned yet, so if 
        // a = 0 as below and we then call f we get 0, 0, 0, 0. Since 
        // everything is captures by reference.
//        double y = f(2.0);
        a=0;

        for(int i=0;i<listd.size;i++){
            double x = listd[i];
            WriteLine($"{x} {f(x)}");
        }
    }
}