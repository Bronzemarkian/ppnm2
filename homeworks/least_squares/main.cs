using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;

public class main{

    public static void Main(string[] args){
	    string outfile = null;
        string outfile2 = null;

	    foreach(string arg in args){
		    var words=arg.Split(':');
		    if(words[0]=="-outfile")outfile=words[1];
		    if(words[0]=="-outfile_data")outfile2=words[1];
	    }
	    if(outfile==null)throw new Exception("Missing outputfile");
        if(outfile2==null)throw new Exception("Missing name for plot file");

        List<double> xlist = new List<double>();
        List<double> ylist = new List<double>();
        List<double> dylist = new List<double>();

        for(string line = ReadLine(); line!=null; line=ReadLine()){
		    var numbers=line.Split(' ');
            xlist.Add( double.Parse(numbers[0]) );
            ylist.Add( double.Parse(numbers[1]) );
            dylist.Add( double.Parse(numbers[2]) );
        }

	    int n=xlist.Count;
        vector x = new vector(n);
        vector y = new vector(n);
        vector dy = new vector(n);

        for(int i=0; i<xlist.Count; i++){
            x[i] = xlist[i];
            y[i] = ylist[i];
            dy[i] = dylist[i];
        }

        System.IO.TextWriter outstream = new System.IO.StreamWriter(outfile);
        outstream.WriteLine("We have data x, y and dy, but am doing a logarithmic fit, so I take the log to y and dy.");

        // we want to plot with log, so:
        vector logy = new vector(n);
        vector dlogy = new vector(n);
        for(int i=0; i<n; i++){
            logy[i] = Log(y[i]);
            // and error propagation:
            dlogy[i] = dy[i]/y[i];
        }

        outstream.WriteLine("The two functions I give is 1 and -z, which then gives c1 - c2*z when taking a linear combination.");
        outstream.WriteLine("When exp is then taken, exp(c1-c2*z) = exp(c1)*exp(-c2*z) = a*exp(-lambda*z),");
        outstream.WriteLine("so that exp(c1) = a and c2 = lambda.");

        /* we give two functions, 1 and -z, so we will get back c1 - c2*z, and when exp is
        taken, exp(c1-c2*z) = exp(c1)*exp(-c2*z), on form a*exp(-lambda*z), so exp(c1)
        is a, and c2 is lambda */
        var fs = new System.Func<double,double>[] { z => 1.0, z=> -z};

        (vector c, vector dc, matrix cov) = leastsq.lsfit(fs, x, logy, dlogy);
    
        // now we try to plot, with exp of course.
        outstream.WriteLine("I plot it with the exponential taken. Refer to 'exp.svg' for the plot.");

        var fexp = new System.Func<double,double>[] {z => Exp(c[0]-z*c[1])};
        Plot(fexp,outfile2);

        double T_half = Log(2)/c[1];
        double dT_half = Log(2)/(Pow(c[1],2))*dc[0];
	    
	    outstream.WriteLine($"My c's are {c[0]} and {c[1]}");
        outstream.WriteLine($"Error on the c's are {dc[0]} and {c[1]}");
        outstream.WriteLine($"Half life from the fit is {T_half} days");
        outstream.WriteLine($"The uncertainty of the half life is {dT_half} days");

	    if(outfile!=null) outstream.Close();

        //cov.print;
	
	/* System.IO.TextWriter newstream = new System.IO.StreamWriter("mytestfile.log");
	newstream.WriteLine("here is my new stream");
	newstream.Close(); */ // just for future refference on how it works

    }
	

    public static void Plot(Func<double,double>[] f, string filename){
        System.IO.TextWriter plotstream = new System.IO.StreamWriter(filename);
        for(double x=1;x<16;x+=0.2){
            plotstream.WriteLine($"{x} {f[0](x)}");
        }
        if(plotstream!=null) plotstream.Close();
    }

}
