using ConsoleApp2;

class Program {
    static void Main () {
        User user = new User();
        user.name = "John";
        user.age = 25;
        user.course = "C# Programming";

        ///======================== Method 1 using the extension method =============================================


        Student student = new Student();
        // mapping using the Mapper class
        //student = Mapper.MapToStudent( user );

        // mapping using the extension method
        student = user.ExtensionMapToStudent();
        //Console.WriteLine( $"Name: {student.name}, Course: {student.course}" );

        ///======================== Method 2 using explicit and implicit operator =============================================
        MyModel mm = new MyModel();
        mm.age = 62;
        mm.name = "ExplicitOperator Method";
        var myDto = (MyModelDTO)mm;
        //System.Console.WriteLine( "My dto age using => " + myDto.age );



        ///======================== Method 3 using my auto mapper of generic type =============================================
        MyAutoMapper mam = new();

        mam.ConvertTo( user, student );
        Console.WriteLine( $" using myautomapper class \n Name: {student.name}, Course: {student.course}" );




    }
}



// we can also utilize the implicit and explicit operators

public class MyModel {
    public int age;
    public string? name;
    // creating an explicit operator on user which will convert it into method name object type
    public static explicit operator MyModelDTO ( MyModel mm ) {
        return new MyModelDTO {
            age = mm.age
        };
    }
}

public class MyModelDTO {
    public int age;
}


public class MyAutoMapper {
    public U ConvertTo<T, U> ( T Source, U Destination ) {

        foreach (var prop in typeof( T ).GetProperties()) {
            var destProp = typeof( U ).GetProperty( prop.Name );
            if (destProp != null && destProp.CanWrite) {
                destProp.SetValue( Destination, prop.GetValue( Source ) );
            }
        }

        return Destination;

    }
}



