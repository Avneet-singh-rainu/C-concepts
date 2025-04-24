class Program
{
    static void Main()
    {

        User user = new User { Age = 25, Name = "Alice", Role = 1 };

        UserDTO dto = (UserDTO)user;
        Student student = user;
        Console.WriteLine($"UserDTO - Name: {dto.Name}, Age: {dto.Age}");

        Console.WriteLine($"Student - Name: {student.Name}");

    }
}


public class User
{
    public int Age { get; set; }
    public string? Name { get; set; }
    public int Role { get; set; }

    public static explicit operator UserDTO(User user)
    {
        return new UserDTO
        {
            Age = user.Age,
            Name = user.Name
        };
    }


    public static implicit operator Student(User user)
    {
        return new Student
        {
            Name = user.Name
        };
    }
}


public class UserDTO
{
    public int Age { get; set; }
    public string? Name { get; set; }
}

public class Student
{
    public string? Name;
}





