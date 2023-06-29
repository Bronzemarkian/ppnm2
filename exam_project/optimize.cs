using System;
using static System.Console;
using System.Diagnostics;
using System.Collections.Generic;

public class optimize{

    public static vector global_optimize(
        Func<vector,double> F,
        double time,   // alloted time to find best point, not including minimize routine
        vector start,
        vector end,
        double acc = 0.001
    ){
        Stopwatch sw = new Stopwatch();
        vector best_x = start;
        double best_y = F(best_x); 
        vector interval = end - start;   // compare random x to best x
        int n = 1, d = start.size;
        sw.Start();                      // start timer
        while (sw.Elapsed < TimeSpan.FromSeconds(time)){
            vector new_x = halton(n,d);
            for(int i = 0; i < d; i++) new_x[i] = start[i] + interval[i]*new_x[i];
            double new_y = F(new_x);

            if(new_y < best_y) { // update x which gives best y and update best y
                best_x = new_x;
                best_y = new_y;
            }
           
            n += 1;
        }

        WriteLine($"The best found x going through {n} values of x is:");
        for(int i = 0; i<d; i++) WriteLine($"x{i} = {best_x[i]}");

        return minimize.qnewton(F,best_x,acc);
    }

        public static double corput(int n, int b){
        double q = 0, bk = (double)1/b;
        while(n>0){q+= (n%b)*bk; n/= b; bk /= b; }
        return q;
    }

    public static vector halton(int n, int d){
        vector x = new vector(d);
        List<int> basis = new List<int> {2,3,5,7,11,13,17,19,23,29,31,37,41,43,47,53,59,61};
        int maxd = basis.Count;
        if(d > maxd) throw new ArgumentException("dimension too high");
        for(int i=0;i<d;i++) x[i] = corput(n, basis[i]); // make each dimension of x with different b
        return x;
    }


}