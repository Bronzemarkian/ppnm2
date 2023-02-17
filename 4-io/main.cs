using System;
using static System.Console;
using static System.Math;
class main{
	public static int Main(string[] args){

/////////////////////
	Write("reading from stdin writing to stdout\n");
	for(string line=In.ReadLine();line != null;line=In.ReadLine()){
		double x=double.Parse(line);
		Out.WriteLine($"{x} {Sin(x)}");
	}

/////////////////////
	Write("reading from a given file writing to a given file\n");
	string infile = null, outfile=null;
	foreach(string arg in args){
		System.Console.Out.WriteLine(arg);
		var words = arg.Split(':');
		if(words[0]=="-input") infile = words[1];
		if(words[0]=="-output") outfile = words[1];
		}	
	if(infile!=null && outfile!=null){
		var inputstream = new System.IO.StreamReader(infile);
		var outputstream = new System.IO.StreamWriter(outfile,append:false);
		for(string line=inputstream.ReadLine();
				line != null;
				line=inputstream.ReadLine()){
		double x=double.Parse(line);
		outputstream.WriteLine($"{x} {Sin(x)}");
		}
		inputstream.Close();
		outputstream.Close();
	}

/////////////////////
	Write("reading from command line\n");
	double[] result=null;
	foreach(string arg in args){
		string[] words=arg.Split(':');
		if(words[0]=="-numbers"){
			string[] numbers=words[1].Split(',');
			result=new double[numbers.Length];
			for(int i=0;i<numbers.Length;i++){
				result[i]=double.Parse(numbers[i]);
			}
		}
	foreach(double x in results)WriteLine($"{number:0.00e+00}");
	}

/////////////////////
	return 0;
	}//Main
}//main