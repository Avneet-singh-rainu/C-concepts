public class Program {

    private static void Main () {
        Utility utility = new Utility();

        int n = 10;
        // PriorityQueue  
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        pq.Enqueue( 1, 1 );
        pq.Enqueue( 2, 2 );
        pq.Enqueue( 3, 3 );
        // User object  
        User u = new();
        u.Id = 1;
        u.Name = "John Doe";
        // Stack   
        Stack<int> st = new();
        st.Push( 1 );
        st.Push( 2 );
        st.Push( 3 );

        // 2d array with comparator  
        int[][] arr = new int[2][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
        Array.Sort( arr, ( a, b ) => b[0].CompareTo( a[0] ) );

        // Heap
        // we can implement heap using prority queue
        // we can implement heap using stack


        try {
            utility.Print( arr );
            utility.Print( st );
            utility.Print( pq );
            utility.Print( u );
            utility.Print( n );
        }
        // since i am throwing the format_error i need to catch that error or else it will cause the main thread to stop...  
        catch (FormatException ex) {
            Console.WriteLine( ex.Message );
        }

        Console.WriteLine( "Application Ending..." );
    }
}

internal class Utility {

    public void Print<T> ( T obj ) {
        if (obj is PriorityQueue<int, int> pq) {
            Console.WriteLine( "This is a PriorityQueue" );
            while (pq.Count > 0) {
                Console.WriteLine( pq.Dequeue() );
            }
        }
        else if (obj is User u) {
            // can do mappings and all here
            Console.WriteLine( u.Name );
        }
        else if (obj is Stack<int> st) {
            while (st.Count > 0) {
                Console.WriteLine( st.Pop() );
            }
        }
        else if (obj is int[][] arr) {
            foreach (var item in arr) {
                foreach (var i in item) {
                    Console.Write( i + " " );
                }
                Console.WriteLine();
            }
        }
        else if (obj is int n) {
            Console.WriteLine( n );
        }
        else if (obj is Student s) {
            Console.WriteLine( s.Id );
        }
        else {
            throw new FormatException( "Unknown type" );
        }
    }
}

internal class User {
    public int Id { get; set; }
    public string Name { get; set; }
}

internal class Student {
    public int Id { get; set; }
}