using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

class Program {
    static void Main () {
        var path = Path.GetFullPath( Path.Combine( AppContext.BaseDirectory, @"..\..\.." ) );
        Console.WriteLine( "Watching path: " + path );

        IFileProvider provider = new PhysicalFileProvider( path );
        var fileInfo = provider.GetFileInfo( "index.txt" );

        if (fileInfo.Exists) {
            // Start watching the file for changes
            ChangeToken.OnChange(
                () => provider.Watch( "index.txt" ),
                () => Console.WriteLine( "File changed..." )
            );
        }
        else {
            Console.WriteLine( "File not found." );
        }

        // to keep the watcher alive
        Console.ReadKey();
    }
}




/*using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

class Program {
    static void Main () {
        // Resolve the absolute path of the project root directory (3 levels up from output bin folder)
        var path = Path.GetFullPath( Path.Combine( AppContext.BaseDirectory, @"..\..\.." ) );
        Console.WriteLine( "Watching path: " + path );

        // PhysicalFileProvider is like an adapter for the file system.
        // It allows access to physical files and directories and supports monitoring file changes.
        // Unlike System.IO which only works with local files, IFileProvider can abstract different sources like embedded resources or cloud storage.
        IFileProvider provider = new PhysicalFileProvider( path );

        // Start watching a specific file (index.txt) in the provided directory for changes
        WatchFile( provider, "index.txt" );

        Console.WriteLine( "Press any key to exit..." );
    }

    static void WatchFile ( IFileProvider provider, string fileName ) {
        // ChangeToken.OnChange registers a callback that is triggered when the file changes.
        // The first lambda () => provider.Watch(fileName) returns an IChangeToken that tracks the file.
        // The second lambda is the action to perform when the file changes.
        // Under the hood, this uses FileSystemWatcher and re-subscribes after every change — so it keeps working without manual loops.
        ChangeToken.OnChange(
            // it watches the file for changes and triggers the os file system watcher hook
            () => provider.Watch( fileName ), // Returns a token that monitors the file
            () => {
                Console.WriteLine( $"{fileName} has changed at {DateTime.Now}" ); // This runs whenever the file is changed
                // Additional logic like re-reading the file or triggering business logic can be placed here
            }
        );
    }
}
*/

