
// Interfaces in C# can have -->
// default methods, which are methods with a body.(Mixins)
// static methods, which are methods that belong to the interface itself.
// abstract methods, which are methods without a body.

class Program : IMixin {
    static void Main () {

        // create an instance of the class
        Program p = new Program();
        // call the method from the class
        p.run();
        // call the method from the interface
        // since i am not using the run in the program class hence i will have to use the interface reference 
        IMixin i = new Program();
        i.run2();

    }

    public void run () {
        Console.WriteLine( "Run one" );
    }
}


interface IMixin {
    // since this method is not implemented in the interface, it is not a default method
    void run ();

    // this method is implemented in the interface, it is a default method
    // it is not abstract
    // the child does not need to implement it if it does not want to
    void run2 () {
        Console.WriteLine( "run2" );
    }
}

