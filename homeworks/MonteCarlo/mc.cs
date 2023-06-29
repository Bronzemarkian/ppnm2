using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public class mc{

    public static (double, double) plainmc(Func<vector,double> f, vector a, vector b, int N){
        int dim = a.size; double V=1; for(int i=0;i<dim;i++) V*=b[i] - a[i];
        double sum=0,sum2=0;
        var x=new vector(dim);
        var rnd = new Random();

        for(int i=0;i<N;i++){ // one point per loop, so get N random points
            for(int k=0;k<dim;k++) x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);
            double fx=f(x); sum+=fx; sum2+=fx*fx;
        }

        double mean = sum / N ,sigma = Sqrt(sum2/N-mean*mean);
        var result = (mean*V,sigma*V/Sqrt(N));
        return result;
    }

    public static (double, double) quasimc(Func<vector,double> f, vector a, vector b, int N){

        int dim = a.size; double V=1; for(int i=0;i<dim;i++) V*=b[i] - a[i];
        double sum1=0,sum2=0;
        vector x1 = new vector(dim), x2 = new vector(dim);

        for(int n = 1; n < N+1; n++){  // for every point we advance b by one
            x1 = halton(n,dim); x2 = halton(n,dim,num:2);
            double fx1=f(x1), fx2=f(x2);
            sum1 += fx1; sum2 += fx2;
        }

        double mean1 = sum1/N, mean2 = sum2/N;
        return (mean1*V, V*Abs(mean2-mean1));

    } 

    public static double corput(int n, int b){
        double q = 0, bk = (double)1/b;
        while(n>0){q+= (n%b)*bk; n/= b; bk /= b; }
        return q;
    }

    public static vector halton(int n, int d, int num = 1){
        vector x = new vector(d);
        int maxd = 0;
        if(num == 1){
            List<int> basis1 = new List<int> {2,3,5,7,11,13,17,19,23};
            for(int i=0;i<d;i++) x[i] = corput(n, basis1[i]); // make each dimension of x with different b
            maxd = basis1.Count;
        }
        else{ 
            List<int> basis2 = new List<int> {29,31,37,41,43,47,53,59,61};
            for(int i=0;i<d;i++) x[i] = corput(n, basis2[i]); // make each dimension of x with different b
            maxd = basis2.Count;
        }
        if(d > maxd) throw new ArgumentException("dimension too high");
        
        return x;
    }


}