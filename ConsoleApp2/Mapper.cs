namespace ConsoleApp2 {

    public class User {
        public string name;
        public int age;
        public string course;
    }

    public class Student {
        public string name;
        public string course;
    }

    public static class Mapper {

        // instead of this i can use extension method on the user type
        public static Student MapToStudent ( User u ) {
            Student s = new();
            s.name = u.name;
            s.course = u.course;

            return s;
        }


        public static Student ExtensionMapToStudent ( this User u ) {
            Student s = new();
            s.name = u.name;
            s.course = u.course;
            return s;
        }





    }
}