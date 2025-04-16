public interface IMessageService {
    void Send ( string message );
}

public class EmailService : IMessageService {
    public void Send ( string message ) {
        Console.WriteLine( $"Email sent: {message}" );
    }
}

public class NotificationManager {
    private readonly IMessageService _messageService;

    public NotificationManager ( IMessageService messageService ) {
        _messageService = messageService;
    }

    public void Notify ( string message ) {
        _messageService.Send( message );
    }
}

class Program {
    static void Main () {
        var container = new SimpleContainer();

        container.Register<IMessageService, EmailService>();
        container.Register<NotificationManager, NotificationManager>();

        var manager = container.Resolve<NotificationManager>();
        manager.Notify( "Hello from DI container!" );
    }
}
