using System;
using static System.Console;
using static System.Math;

public class minimize{


    public static vector qnewton(
        Func<vector,double> f, // objective function
        vector x,          // starting point
        double acc,             // accuracy goal
        int maxit = 10000
    ){
        int dim = x.size;
        matrix B = matrix.id(dim);
        vector gradient = new vector(dim);
        int it = 0;
        double fx = 0;
        double dx = 0;

        do{ // do #1
        fx = f(x);
        for(int i = 0; i<dim; i++){ // calculate numerical gradient
            dx = Abs(x[i])*Pow(2,-26);
            x[i] += dx;
            gradient[i] = (f(x)-fx)/dx;
            x[i] -= dx;
        }

        if(gradient.norm() < acc) return x; //if gradient ~0, found minimum

        vector xstep = -B*gradient;

        double lambda = 1;
        bool linsearch = true;
        vector y = new vector(dim);
        do{
            vector s = lambda*xstep; 
            if (f(x + s) < f(x)){ // accept step and update B
                x += s;
                // now i calculate the symmetric Broyden's update.
                fx = f(x); // since already added lstep
                for(int i = 0; i < dim; i++){  // make y
                    dx = Abs(x[i])*Pow(2,-26);
                    x[i] += dx;
                    y[i] = (f(x)-fx)/dx - gradient[i];
                    x[i] -= dx;
                }

                vector u = s-B*y;
                double gamma = u.dot(y)/(2*s.dot(y));
                vector a = (u-gamma*s)/s.dot(y);
                matrix db1 = matrix.outer(a,s), db2 = matrix.outer(s,a);
                B = B + db1 + db2;

                linsearch = false;

            } else{
                lambda /= 2;
                if (lambda < 1/1024) { // accept step and reset B
                    x += lambda*xstep;
                    B = matrix.id(dim); // reset B
                    linsearch = false;
                }
            }

        }while(linsearch);
        


        it += 1;
        if(it >= maxit) throw new ArgumentException("Maximum allowed number of iterations passed");
        }
        while(true); // do 1

    }


}
