class Program
{
    static void Main()
    {
        Console.WriteLine("Hello world...");

        User user = new User { Age = 25, Name = "Alice", Role = 1 };

        // Using explicit cast
        UserDTO dto = (UserDTO)user;

        Console.WriteLine($"DTO - Name: {dto.Name}, Age: {dto.Age}");
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
}


public class UserDTO
{
    public int Age { get; set; }
    public string? Name { get; set; }

}






