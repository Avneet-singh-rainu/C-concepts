class Program {
    static void Main () {
        Mydelegate my = new();


        // anonymous function statement  
        // Anonymous function using lambda
        // Action is a built-in delegate type that takes no parameters and returns void
        // It can be used to define a method that takes no parameters and returns void
        //Key Points about Action:
        //Does not return anything: It's used for methods that perform an action but don't return a result( i.e., methods with a void return type).
        //Can have parameters: You can define it to take up to 16 parameters of any types.
        Action sayHello = () => Console.WriteLine( "Hello World!" );
        sayHello(); // Calls the function

        // Correct delegate usage: match the signature `void md(string)`  
        my.run( ( name ) => {
            System.Console.WriteLine( "Hello " + name );
        } );
    }
}

public class Mydelegate {
    // Delegate that accepts a string and returns void
    public delegate void md ( string n );

    public void printName ( string name ) {
        System.Console.WriteLine( name );
    }

    public void run ( md d ) {
        System.Console.WriteLine( "Running the program..." );
        d.Invoke( "Avneet" );  // Pass the name to the delegate
    }
}

