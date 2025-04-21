using ConsoleApp2;

class Program
{
    static void Main()
    {
        User user = new User();
        user.name = "John";
        user.age = 25;
        user.course = "C# Programming";

        Student student = new Student();
        // mapping using the Mapper class
        //student = Mapper.MapToStudent( user );

        // mapping using the extension method
        student = user.ExtensionMapToStudent();
        Console.WriteLine($"Name: {student.name}, Course: {student.course}");
        MyModel mm = new MyModel();
        mm.age = 62;
        mm.name = "ExplicitOperator Method";
        var myDto = (MyModelDTO)mm;
        System.Console.WriteLine("My dto age using => " + myDto.age);
    }
}



// we can also utilize the implicit and explicit operators

public class MyModel
{
    public int age;
    public string? name;
    // creating an explicit operator on user which will convert it into method name object type
    public static explicit operator MyModelDTO(MyModel mm)
    {
        return new MyModelDTO
        {
            age = mm.age
        };
    }
}

public class MyModelDTO
{
    public int age;
}





