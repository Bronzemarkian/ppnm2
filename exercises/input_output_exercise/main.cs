using System;
using static System.Console;
using static System.Math;



public class main{

    public static void Main(string[] args){
        string infile=null,outfile=null;
        foreach(var arg in args){
            WriteLine($"{arg}"); // correctly gives individual arg
            var words = arg.Split(':');
            if(words[0] == "-input") infile = words[1];
            if(words[0] == "-output") outfile = words[1];
            WriteLine("pog"); WriteLine($"{words[0]}");

        }

        WriteLine($"{infile}");WriteLine($"{outfile}");

        if( infile == null || outfile == null){
            Error.WriteLine("wrong filename argument");
            //return 1;  // wont work if I include this, as type is not
            // consistent in every route in code.
        }

        WriteLine("last part approaching");

        var instream = new System.IO.StreamReader(infile);
        var outstream = new System.IO.StreamWriter(outfile,append:false);
        
        WriteLine("step 1 of last part");

        for(string line=instream.ReadLine();line!=null;
            line=instream.ReadLine()){
                double x = double.Parse(line);
                outstream.WriteLine($"{x} {Sin(x)} {Cos(x)}");
            }

        WriteLine("at the end");

        instream.Close();
        outstream.Close();
    }

    public static void Main2(){
        char[] split_delimeters = {' ','\t','\n'};
        var split_options = StringSplitOptions.RemoveEmptyEntries;
        // remove removes extra blanks, tabs etc etc
        for( string line = ReadLine(); line != null; line = ReadLine()){
            var numbers = line.Split(split_delimeters,split_options);
            foreach(var number in numbers){
                double x = double.Parse(number);
                WriteLine($"{x}");
            }
        }
    }

    public static void Main1(string[] args){
        foreach(var arg in args){ 
            var words = arg.Split(':');
            if(words[0] == "-numbers"){
                var numbers=words[1].Split(',');
                foreach(var number in numbers){
                    double x = double.Parse(number); // only accepts string
                    WriteLine($"{x} {Sin(x)} {Cos(x)}");
                }
            }
        
        }

    

        

    } // method Main



} // class main


