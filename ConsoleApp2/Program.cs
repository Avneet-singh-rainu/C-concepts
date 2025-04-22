

// Usecases of generics
// 1. Generic class
// 2. Generic method
// 3. Generic interface
// 4. Generic delegate
// 5. Generic constraints  ----> explore the multiple constraints in order to get better at this...
// 6. Generic collections
// 7. Generic covariance and contravariance
// 8. Generic type parameters
// 9. Generic type arguments
// 10. Generic type inference
// 11. Generic type parameters with default values
// 12. Generic type parameters with constraints
// 13. Generic type parameters with multiple constraints
// 14. Generic type parameters with default values and constraints

//      Concept           | Description                                       | Keyword
//      Covariance        | Enables method return of derived types            | out
//      Contravariance    | Enables method parameter of base types            | in
//      Type Parameters   | Placeholders for types in generic definitions     | T, U
//      Type Arguments    | Actual types supplied to generic types/methods    | string, int, etc.


//Yes, you can use constraints on both class-level and method-level generic type parameters —
//but only if both define their own separate generic type parameters.
/*
 class Utility<T> where T : User
{
    // U is a new method-level type parameter with its own constraint
    public void Process<U>(U value) where U : Car
    {
        Console.WriteLine("Class T: " + typeof(T).Name); // e.g., User or derived
        Console.WriteLine("Method U: " + typeof(U).Name); // e.g., Car or derived
    }
}



❌ Not valid: Cannot apply a second constraint on the same T in method if it was already defined at class level
class Utility<T> where T : User
{
    // ❌ Illegal: You can't re-constrain class-level T inside method
    public void Print<T>(T value) where T : Car { } // ❌ error: duplicate definition
}

*/
class Program {
    static void Main () {


        User u = new User();
        u.Name = "John";
        u.Age = 30;
        Utility<User> u1 = new Utility<User>();
        u1.Print( u );


        Car c = new Car();
        c.manufacturer = "Toyota";
        //it is throwing error as the class utility is constrained to Use only the User Object
        //Utility<Car> u2 = new Utility<Car>();
        //u2.Print( c );

    }

}


class Utility<T> where T : User {

    //Here, the T in the method Print<T> shadows (overrides) the T from the class definition.
    //So inside the method, T is not necessarily a User anymore, just a new, unrelated type — that's why value.
    //Name is not accessible, but value.Age is accessible only because Age is part of the type you're passing in
    //(coincidentally User).
    //public void Print<T> ( T value ) {
    //    Console.WriteLine( value.Age );
    //}

    public void Print ( T value ) {
        Console.WriteLine( value.Name );
    }

}

public class User {
    public string? Name { get; set; }
    public int Age { get; set; }
}

public class Car {
    public string? manufacturer { get; set; }
}





