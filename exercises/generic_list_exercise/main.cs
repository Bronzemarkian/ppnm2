using System;
using static System.Console;
using static System.Math;

public class main{
    public static void Main(string[] args){
        var list = new genlist<double>();
        char [] delimiters = {' ','\t'};
        var options = StringSplitOptions.RemoveEmptyEntries;
        for(string line = ReadLine(); line!=null;line=ReadLine()){
            var words = line.Split(delimiters,options);
            int n = words.Length;
            var numbers = new double[n];
            for(int i=0;i<n;i++){ 
            numbers[i] = double.Parse(words[i]);
            list.add(numbers[i]);}
        }
        for(int i=0;i<list.size;i++){
            var numbers = list[i];
            //foreach(var number in numbers) // this line doesnt work
            Write($"{numbers : 0.00e+00;-0.00e+00}");
            WriteLine();
        }

        WriteLine($"size before: {list.size}");

        Random rnd = new Random();
        int indice = rnd.Next(0,list.size);
        WriteLine("\n Now to remove element {0}:",indice);
        list.remove(indice);

        WriteLine($"size after: {list.size}");

        for(int i=0;i<list.size;i++){
            var numbers = list[i];
            //foreach(var number in numbers) // this line doesnt work
            Write($"{numbers : 0.00e+00;-0.00e+00}");
            WriteLine();
        }

    }
}