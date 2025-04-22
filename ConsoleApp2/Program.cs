using ConsoleApp2;
using System.Reflection;

class Program {
    static void Main () {
        string role = "Admin";

        string requestPath = "/home";
        var controller = new HomeController();
        var methods = typeof( HomeController ).GetMethods();

        foreach (var method in methods) {
            var attr = method.GetCustomAttribute<MyGetAttribute>();
            if (attr != null && attr.route == requestPath) {
                method.Invoke( controller, null );
                break;
            }
        }

    }
}

[AttributeUsage( AttributeTargets.Method )]
public class MyGetAttribute : Attribute {
    public readonly string route;

    public MyGetAttribute ( string route ) {
        this.route = route;
    }


}



class HomeController {
    [MyGet( "/home" )]
    [MyCustomAuthorize( "Admin" )]
    public void Index () {
        MyAuthorizationUsingReflection auth = new MyAuthorizationUsingReflection();
        var controllerName = typeof( HomeController );
        if (auth.IsAuthorized( "Index", controllerName ) == true) {
            Console.WriteLine( "Index" );
        }
        else {
            Console.WriteLine( "Unauthorized" );
        }
    }

    [MyGet( "/privacy" )]
    public void Privacy () {
        Console.WriteLine( "Privacy page" );
    }
}