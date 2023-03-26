using System;
using static System.Console;
using System.Threading;
using System.Threading.Tasks;


class main{

    public class data{ public int a,b; public double sum;}

    public static void harmonic(object obj){
        var local = (data)obj;
        local.sum=0;
        for(int i=local.a;i<=local.b;i++)local.sum+=1.0/i;
        }

    public static int Main(string[] args){
        int nthreads = 1, nterms = (int)1e8;

        foreach(var arg in args){
            var words = arg.Split(':');
            if(words[0] == "-threads") nthreads = (int)float.Parse(words[1]);
            if(words[0] == "-terms") nterms = (int)float.Parse(words[1]);
        }


        data[] x = new data[nthreads];
        for(int i=0;i<nthreads;i++){ // make list
            x[i] = new data();
            // following lines to split work in different threads
            x[i].a = 1 + nterms/nthreads*i;
            x[i].b = 1 + nterms/nthreads*(i+1);
        }
        x[x.Length-1].b=nterms+1; // make sure endpoint fits

        var threads = new Thread[nthreads];
        for(int i=0;i<nthreads;i++){
            threads[i] = new Thread(harmonic);  // create thread
            threads[i].Start(x[i]);  // run with x[i] as arg to harmonic
        }

        double sum = 0;
        for(int i=0;i<nthreads;i++) threads[i].Join(); // join threads
        for(int i=0;i<nthreads;i++) sum+=x[i].sum;

/*         double sum=0;
        Parallel.For( 1, nthreads+1, delegate(int i){sum+=1.0/i;}); */

        return 0;
    }



}