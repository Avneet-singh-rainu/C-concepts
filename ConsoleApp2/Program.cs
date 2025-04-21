using ConsoleApp2;

class Program {
    static void Main () {

        User user = new User();
        user.name = "John";
        user.age = 25;
        user.course = "C# Programming";

        Student student = new Student();
        // mapping using the Mapper class
        //student = Mapper.MapToStudent( user );

        // mapping using the extension method
        student = user.ExtensionMapToStudent();



        Console.WriteLine( $"Name: {student.name}, Course: {student.course}" );


    }

}





