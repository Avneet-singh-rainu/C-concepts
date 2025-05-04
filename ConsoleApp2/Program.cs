using System.Linq.Expressions;

class Program {
    /// <summary>
    /// Demonstrates how to create and use Expression Trees in C#.
    /// Expression Trees are data structures that represent code as a tree,
    /// where each node is an expression (e.g., an operation or method call),
    /// and the leaves are constants or parameters.
    /// The data stored is not executed but can be compiled and executed later.
    /// Commnly used in LINQ to SQL, EF, and other ORM FW to build dynamic querie.
    /// The expression tree stores the code in a way that can be analysid and view and modified later and also
    /// can be sent to other systems (SQL) server to execute the code (LINQ).
    /// </summary>
    static void Main () {
        /*
         * Expression Trees allow the code itself to be represented as data.
         * This is useful for building dynamic queries, runtime evaluation, or
         * converting code to another form (e.g., SQL via Entity Framework).
         */

        // ----------------------------
        // Method 1:
        // Creating an expression tree using a lambda expression
        // Expression<Func<int, int, int>> add = (a, b) => a + b;
        // ----------------------------

        // ----------------------------
        // Method 2: Manually building an Expression Tree
        // Step-by-step creation of a lambda: (int a, int b) => a + b
        // ----------------------------

        // 1. Create parameter expressions for the lambda parameters
        ParameterExpression a = Expression.Parameter( typeof( int ), "a" ); // Represents variable 'a'
        ParameterExpression b = Expression.Parameter( typeof( int ), "b" ); // Represents variable 'b'

        // 2. Create the expression body: a + b
        BinaryExpression body = Expression.Add( a, b ); // Represents the binary operation 'a + b'

        // 3. Combine parameters and body into a complete expression tree
        // The resulting expression is equivalent to: (a, b) => a + b
        Expression<Func<int, int, int>> add = Expression.Lambda<Func<int, int, int>>( body, a, b );

        // 4. Compile the expression tree into executable code (delegate)
        Func<int, int, int> addFunction = add.Compile();

        // 5. Invoke the compiled function with sample values
        int result = addFunction( 1, 1 ); // Expected output: 2

        // 6. Output the result
        Console.WriteLine( result ); // Output: 2
    }
}
