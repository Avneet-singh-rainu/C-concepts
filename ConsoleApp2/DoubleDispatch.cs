namespace ConsoleApp2 {
    class DoubleDispatch {
        public DoubleDispatch () {
            IAnimall animal = new Dogg(); // compile-time type = IAnimall, runtime type = Dogg


            AnimalVisitor visitor = new AnimalVisitor();

            // Double Dispatch to get correct behavior
            animal.Accept( visitor ); // Will print Dogg related output


            Horsee horse = new Horsee();


            // Single dispatch limitation
            horse.AnimalType( animal ); // This should print "AnimalType(Dogg)"
        }
    }

    interface IAnimall {
        void Accept ( AnimalVisitor visitor ); // Accept method for double dispatch
    }

    class Dogg : IAnimall {
        public void Accept ( AnimalVisitor visitor ) {

            visitor.Visit( this ); // Visitor visits Dogg
        }

        public void sound () {
            Console.WriteLine( "bhaw bhaw bhaw ..." );
        }

        // AnimalType (Dogg) - method specific to Dogg
        public void AnimalType ( Dogg a ) {
            Console.WriteLine( "AnimalType (Dogg) called" );
        }
    }

    class Horsee : IAnimall {
        public void Accept ( AnimalVisitor visitor ) {

            visitor.Visit( this ); // Visitor visits Horsee
        }

        public void sound () {
            Console.WriteLine( "neighghghghghg ...." );
        }

        // AnimalType (IAnimall) - General method for IAnimall
        public void AnimalType ( IAnimall a ) {
            Console.WriteLine( "AnimalType (IAnimall) called" );
            a.Accept( new AnimalVisitor() ); // Double dispatch through Accept
        }

        // AnimalType (Dogg) - method specific to Dogg
        public void AnimalType ( Dogg a ) {
            Console.WriteLine( "AnimalType (Dogg) called" );
        }
    }

    class AnimalVisitor {
        public void Visit ( Dogg d ) {

        }

        public void Visit ( Horsee h ) {

        }

        public void Visit ( IAnimall a ) {

        }
    }
}
