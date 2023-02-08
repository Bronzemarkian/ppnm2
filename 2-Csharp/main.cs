using System;
using static System.Console;
using static System.Math;
class main{
    public static string s = "class scope s";
    public static void print_s(){WriteLine(s);}
    public static void Main(){
        string s = "method scope s";
        print_s();
        WriteLine(s);
// this s shadows previous s, takes precidence
    Write("hello from main\n");
    static_hello.print();
    static_world.print();
    static_hello.greeting="new hello from main\n";
    static_world.greeting="new world from main\n";
    static_hello.print();
    static_world.print();
    hello hello1 = new hello("hello1\n");
    hello world1 = new hello("world1\n");
    hello1.print();
    world1.print();
    hello another_hello = hello1; // if class, always a refference. Doesnt create new instance
    // so if another_hello changes, so does hello1.
    another_hello.greeting = "another greeting\n";
    hello1.print();
    hello test = new hello();
    test.print();
    Write($"the value if pi in Math is {System.Math.PI}\n");
    Write("the value if pi in Math is {0}\n", System.Math.PI);
    Write($"the value if e in Math is {System.Math.E}\n");
    double sqrt2 = Sqrt(2);
    Write($"sqrt2^2 = {Pow(sqrt2,2)}\n");
    Write($"1/2 = {1/2}\n");
    Write($"1.0/2 = {1.0/2}\n");
    }
}