namespace ConsoleApp2 {
    public class MyContainer {

        public Dictionary<Type, Func<object>> registration = new();


        public void Register<TService, TImplementation> () {
            registration[typeof( TService )] = () => CreateInstance( typeof( TImplementation ) );
        }


        public TService Resolve<TService> () {
            return (TService)registration[typeof( TService )].Invoke();
        }

        private object CreateInstance ( Type implType ) {
            // since i need the constructor with the most parameters
            // i need to resolve the fconstrucrtore service first as well i wll need to create instance of all injected service in the constructor

            var ctors = implType.GetConstructors().OrderByDescending( c => c.GetParameters().Length ).First();
            var parameters = ctors.GetParameters()
             .Select( p => Resolve( p.ParameterType ) )
             .ToArray();

            return Activator.CreateInstance( implType, parameters )!;
        }

        private object Resolve ( Type parameterType ) {
            return registration[parameterType].Invoke();
        }
    }
}
