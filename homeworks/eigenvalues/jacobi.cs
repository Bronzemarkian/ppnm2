using System;
using static System.Console;
using static System.Math;

public static class jacobi{

    public static void Main(string[] args){
        
        // ------------ A) -------------------

        // generate random symmetric matrix:
        Random rnd = new Random();
        int m = rnd.Next(3,8);
        matrix A = new matrix(m,m);
        for(int i=0;i<m;i++){
            A[i,i] = rnd.Next(-10,10); // diagonal
            for(int j=i+1;j<m;j++){    // off-diagonal
                A[i,j] = rnd.Next(-10,10);
                A[j,i] = A[i,j];
            }
        }

        A.print("Random symmetric matrix A=");

        WriteLine("After generating A, I will now use 'cyclic' to perform my eigenvalue decomposition.");

        (vector w, matrix V, matrix D) = cyclic(A);

        // ----------------- testing results ----------------

        matrix VTAT = V.T * A * V;

        WriteLine("From this decomposition I will now check some things using the approx() method");

        WriteLine($"Is V^T * A *V = D? {VTAT.approx(D)}");
        matrix VDVT = V * D * V.T;
        WriteLine($"Is V * D *V^T = A? {VDVT.approx(A)}");
        matrix VTV = V.T * V;
        matrix VVT = V * V.T;
        WriteLine($"Is V^T * V = id? {VTV.approx(matrix.id(m))}");
        WriteLine($"Is V * V^T = id? {VVT.approx(matrix.id(m))}");

        // ------------ B) -------------------

        double rmax = 10, dr = 0.3;
        foreach(var arg in args){
            var words = arg.Split(':');
            if(words[0] == "-rmax") rmax = float.Parse(words[1]);
            if(words[0] == "dr") dr = float.Parse(words[1]);
        }

        int npoints = (int)(rmax/dr)-1;
        vector r = new vector(npoints);
        for(int i=0;i<npoints;i++) r[i] = dr*(i+1);
        matrix H = new matrix(npoints,npoints);
        for(int i=0;i<npoints-1;i++){ // first add/make K
            H[i,i] = -2;
            H[i,i+1] = 1;
            H[i+1,i] = 1;
        }
        H[npoints-1,npoints-1]=-2; // last point we didnt make
        matrix.scale(H,-0.5/dr/dr);
        for(int i=0;i<npoints;i++) H[i,i] += -1/r[i]; // now add V

        (vector e, matrix Vb, _ ) = cyclic(H);

        WriteLine("\nStarting on b, I never got as far and pretty much only got the first part down.\n");
        e.print("So the eigenvalues are:");
        Vb.print("with the corresponding eigenvectors:");

    }

    public static void timesJ(matrix A, int p, int q, double theta){
        double c = Cos(theta), s = Sin(theta);
        for(int i=0;i<A.size1;i++){
            double aip = A[i,p], aiq = A[i,q];
            A[i,p] = c*aip + -s*aiq;
            A[i,q] = s*aip + c*aiq;
        }
    }

    public static void Jtimes(matrix A, int p, int q, double theta){
        double c = Cos(theta), s = Sin(theta);
        for(int j=0;j<A.size1;j++){
            double apj = A[p,j], aqj = A[q,j];
            A[p,j] = c*apj + s*aqj;
            A[q,j] = -s*apj + c*aqj;
        }
    }

    public static (vector, matrix, matrix) cyclic(matrix M){
        matrix A = M.copy();
        matrix V = matrix.id(M.size1);
        vector w = new vector(M.size1);

        bool changed;
        do{
            changed = false;
            for(int p=0;p<M.size1-1;p++){
                for(int q=p+1;q<M.size1;q++){
                    double apq = A[p,q], app = A[p,p], aqq = A[q,q];
                    double theta = 0.5*Atan2(2*apq,aqq-app);
                    double c = Cos(theta), s=Sin(theta);
                    double new_app = c*c*app-2*s*c*apq+s*s*aqq;
                    double new_aqq = s*s*app+2*s*c*apq+c*c*aqq;
                    if(new_app!=app || new_aqq!=aqq){
                        changed=true;
                        timesJ(A,p,q,theta);
                        Jtimes(A,p,q,-theta);
                        timesJ(V,p,q,theta);
                    }
                }
            }

        }while(changed);
        // after changed, A is diagonal matrix with eigenvalues on diagonal.
        for(int k=0;k<M.size1;k++) w[k] = A[k,k];

        return (w,V,A);
    }


    public static void Test(){
        var ma = new matrix("1 2 ; 5 4");
        ma.print();
        (ma+ma.T).print();
        (matrix.id(3)).print();
        WriteLine("rows:");
        ma.rows(1,1).print();
        WriteLine("cols:");
        ma.cols(1,1).print();

        WriteLine("multiplied");
        double ij = ma[0,1];
        WriteLine($"{ij}");

    }

}



