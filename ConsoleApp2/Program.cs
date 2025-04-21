// ******************************************************************************************
// Extension methods in C#
// Extension methods allow you to add new methods to existing types(class, int, string, struct, ...) without modifying their source code.
// This is done by creating a static class with static methods.
// The first parameter of the method must be preceded by the "this" keyword,
// which indicates that the method is an extension method for the type of the first parameter.
// ******************************************************************************************


// Usecase:
// 1. Adding new methods to existing types without modifying their source code.
// 2. Creating a more readable and fluent API.
// 3. Adding functionality to third-party libraries without modifying their source code.
// 4. Working with DTO and mapping them to domain models.



// static class to implement extension methods
static class ExtensionMethods {

    // the extension method for the string type
    // the first parameter is preceded by the "this" keyword
    // the type after the this tell the compiler that this is an extension method for the string type
    // so i can call this method on any string object

    public static void Print ( this string str ) {
        Console.WriteLine( str );
    }


    // the extension method for the User type
    // the first parameter is preceded by the "this" keyword
    // the type after the this tell the compiler that this is an extension method for the User type
    public static void PrintUserName ( this User user ) {
        Console.WriteLine( user.Name );
    }
}


class User {
    public string Name { get; set; }
    public int Age { get; set; }
    public User ( string name, int age ) {
        Name = name;
        Age = age;
    }
}



public class Program {

    public static void Main ( string[] args ) {
        string str = "Hello, World!";
        str.Print();

        User user = new User( "John Doe", 30 );
        user.PrintUserName();

    }
}


