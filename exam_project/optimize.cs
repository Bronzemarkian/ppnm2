using System;
using static System.Console;
using static System.Math;
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
        vector interval = end - start;
        int n = 1, d = start.size;
        List<int> basis = primes(d);     // get list of primes to use with halton
        sw.Start();                      // start timer
        while (sw.Elapsed < TimeSpan.FromSeconds(time)){
            vector new_x = halton(n,d,basis);
            for(int i = 0; i < d; i++) new_x[i] = start[i] + interval[i]*new_x[i];
            double new_y = F(new_x);

            if(new_y < best_y) { // update x which gives best y and update best y
                best_x = new_x;
                best_y = new_y;
            }
            n += 1;
        }

        return minimize.qnewton(F,best_x,acc);
    }

    public static double corput(int n, int b){
        double q = 0, bk = (double)1/b;
        while(n>0){q+= (n%b)*bk; n/= b; bk /= b; }
        return q;
    }

    public static vector halton(int n, int d, List<int> basis){
        vector x = new vector(d);
        for(int i=0;i<d;i++) x[i] = corput(n, basis[i]); // make each dimension of x with different b
        return x;
    }

    public static List<int> primes(int d){

        List<int> basis = new List<int>();
        basis.Add(2); // faster to add than start with it in list
        int test_prime = 3;
        while(basis.Count < d){
            bool isprime = true;
            int sqrt = (int)Sqrt(test_prime); // only want to search up to sqrt of potential prime
            for(int i = 0; basis[i] <= sqrt; i++){
                if(test_prime % basis[i] == 0){
                    isprime = false;
                    break;
                }
            }
            if(isprime) basis.Add(test_prime);
            test_prime += 2; // no need to evaluate even numbers
        }
        return basis;

    }


}