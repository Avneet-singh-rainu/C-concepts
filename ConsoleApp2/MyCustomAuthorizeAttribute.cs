// implement Attribute class
// Attribute is just a metadata class it does not do anything by itself
// To make use of this metadata we need to use reflection
// The authorize is used in main program to check if the user is authorized to access the method

using System.Reflection;

namespace ConsoleApp2 {
    // This attribute can be applied to methods
    [AttributeUsage( AttributeTargets.Method )]
    public class MyCustomAuthorizeAttribute : Attribute {
        // Expose role via a public property
        public string Role { get; }

        public MyCustomAuthorizeAttribute ( string role ) {
            Role = role;
        }
    }

    public class MyAuthorizationUsingReflection {
        public bool IsAuthorized ( string methodName, Type controllerType ) {
            // No need to re-get the type from fullname
            var method = controllerType.GetMethod( methodName );
            var attr = method?.GetCustomAttribute<MyCustomAuthorizeAttribute>();

            if (attr != null) {
                if (attr.Role != "Admin") {
                    return false;
                }
            }
            Console.WriteLine( "The user is admin verified" );
            return true;
        }
    }
}
