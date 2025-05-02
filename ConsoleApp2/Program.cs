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

        ///======================== Method 2 using explicit and implicit operator ===================================
        MyModel mm = new MyModel();
        mm.age = 62;
        mm.name = "ExplicitOperator Method";
        var myDto = (MyModelDTO)mm;
        //System.Console.WriteLine( "My dto age using => " + myDto.age );



        ///======================== Method 3 using my auto mapper of generic type ===================================
        MyAutoMapper mam = new();

        mam.ConvertTo( user, student );
        Console.WriteLine( $" using myautomapper class \n Name: {student.name}, Course: {student.course}" );



    }
}



/// <summary>
/// Method 2
/// It uses explicit and implicit operator to convert the object of one type to another.
/// </summary>
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


/// <summary>
/// Method 3 for automapping the properties of two different classes and returning the destination object.
/// The properties with the same name and type will be mapped.
/// Nested properties are not supported.
/// </summary>
public class MyAutoMapper {
    public U ConvertTo<T, U> ( T source, U destination )
        where T : class
        where U : class {

        var sourceProps = typeof( T ).GetProperties();
        var destProps = typeof( U ).GetProperties()
            .Where( p => p.CanWrite )
            .ToDictionary( p => p.Name, p => p );

        foreach (var prop in sourceProps) {
            if (destProps.TryGetValue( prop.Name, out var destProp )) {
                if (destProp.PropertyType.IsAssignableFrom( prop.PropertyType )) {
                    destProp.SetValue( destination, prop.GetValue( source ) );
                }
            }
        }

        return destination;
    }
}





