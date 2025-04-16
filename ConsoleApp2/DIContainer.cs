public class SimpleContainer {

    //2. Dictionary to store service types and their corresponding factory functions
    // For example, if we register IEmailService with EmailService, the dictionary will look like:
    // { typeof(IEmailService), () => new EmailService() }
    private readonly Dictionary<Type, Func<object>> _registrations = new();

    // Registers a service type and its implementation type
    // For example, Register<IEmailService, EmailService>() will store:
    // { typeof(IEmailService), () => new EmailService() }
    public void Register<TService, TImplementation> ()
        where TImplementation : TService {
        _registrations[typeof( TService )] = () => CreateInstance( typeof( TImplementation ) );
    }

    // Registers a singleton instance of a service type
    // For example, RegisterSingleton<IEmailService>(emailServiceInstance) will store:
    // { typeof(IEmailService), () => emailServiceInstance }
    // public void RegisterSingleton<TService>(TService instance) {
    //     _registrations[typeof(TService)] = () => instance;
    // }

    //1. Resolves an instance of the requested service type
    // For example, Resolve<IEmailService>() will return an instance of EmailService
    public TService Resolve<TService> () {
        // Look for the service in the dictionary and invoke the function to create the instance
        return (TService)_registrations[typeof( TService )].Invoke();
    }

    //3. Creates an instance of the specified implementation type
    // This method uses reflection to find the constructor with the most parameters
    // and resolves each parameter before creating the instance
    private object CreateInstance ( Type implementationType ) {
        // Get the constructor with the most parameters
        // just for this small example i am using the most parameters constructor
        /// usually i will pick the constructor with the most parameters that belong to the dictionary or resolvable
        var constructor = implementationType
            .GetConstructors()
            .OrderByDescending( c => c.GetParameters().Length )
            .First();

        // Resolve each parameter of the constructor
        var parameters = constructor.GetParameters()
            .Select( p => Resolve( p.ParameterType ) )
            .ToArray();

        // Create an instance of the implementation type with the resolved parameters
        return Activator.CreateInstance( implementationType, parameters )!;
    }

    //4. Resolves an instance of the specified type
    // This method is used internally to resolve constructor parameters
    // this is for the Services injected in the constructor
    private object Resolve ( Type type ) {
        if (!_registrations.ContainsKey( type )) {
            throw new InvalidOperationException( $"Service of type {type} is not registered." );
        }

        // Invoke the factory function to create the instance
        return _registrations[type].Invoke();
    }
}


