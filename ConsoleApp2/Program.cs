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
        // Demonstrating Method 1: Expression Tree using Lambda Syntax
        Console.WriteLine( "Method 1: Expression Tree using Lambda Syntax" );
        RunMethod1_LambdaSyntax();

        // Demonstrating Method 2: Manually Building an Expression Tree
        Console.WriteLine( "\nMethod 2: Manually Building an Expression Tree" );
        RunMethod2_ManualExpression();
    }

    /// <summary>
    /// Method 1: Creates an expression tree using direct lambda syntax.
    /// This is the most concise way and lets the compiler build the expression tree automatically.
    /// The expression tree is compiled into a delegate and invoked to return a result.
    /// </summary>
    static void RunMethod1_LambdaSyntax () {
        // Expression tree that represents: (a, b) => a + b
        Expression<Func<int, int, int>> addExpression = ( a, b ) => a + b;

        // Compile the expression tree into a delegate (Func<int, int, int>)
        Func<int, int, int> compiledAdd = addExpression.Compile();

        // Invoke the compiled delegate (expression tree) with sample values (1, 1)
        int result = compiledAdd( 1, 1 );

        // Output the result of the expression tree execution
        Console.WriteLine( $"(1 + 1) = {result}" );
    }

    /// <summary>
    /// Method 2: Manually constructs an expression tree step-by-step.
    /// This approach provides more control over the expression tree and is useful for building dynamic queries at runtime.
    /// In this example, we manually create parameters and the binary expression (a + b).
    /// </summary>
    static void RunMethod2_ManualExpression () {
        // Step 1: Define parameters for the expression
        ParameterExpression paramA = Expression.Parameter( typeof( int ), "a" ); // Represents the variable 'a'
        ParameterExpression paramB = Expression.Parameter( typeof( int ), "b" ); // Represents the variable 'b'

        // Step 2: Define the expression body: a + b (binary addition expression)
        BinaryExpression body = Expression.Add( paramA, paramB );

        // Step 3: Combine the parameters and body into a complete expression tree: (a, b) => a + b
        Expression<Func<int, int, int>> addExpression = Expression.Lambda<Func<int, int, int>>( body, paramA, paramB );

        // Step 4: Compile the expression tree into executable code (delegate)
        Func<int, int, int> compiledAdd = addExpression.Compile();

        // Step 5: Invoke the compiled delegate (expression tree) with sample values (1, 1)
        int result = compiledAdd( 1, 1 );

        // Output the result of the expression tree execution
        Console.WriteLine( $"(1 + 1) = {result}" );
    }
}
