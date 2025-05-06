namespace ConsoleApp2 {
    class SingleDispatch {
        public SingleDispatch () {
            IAnimal a = new Dog();
            a.sound();

            // 'a' still has compile-time type IAnimal, but its runtime type is now Horse

            a = new Horse();
            a.sound();

            //? this method cant be called as it is not in the compile time type IAnimal
            //a.methodNotInTheParent();
        }

        /// <summary>
        /// AnimalType is accepting "Dog" object type
        /// This wont work as compile time object is IAnimal and run time object is Dog so on compile time will throw error
        /// 
        /// ---------------------------------------------------------------------------------------------------------------
        /// 
        /// The main limitation is that 
        /// horse.AnimalType(animal) calls the IAnimal version of AnimalType 
        /// because the compile-time type of animal is IAnimal (even though it is a Dog at runtime).
        /// This is the limitation of single dispatch where the method resolution doesn't take runtime types into account.
        /// </summary>
        public void Limitation () {
            IAnimal animal = new Dog();
            Dog dog = new Dog();


            //>>>>>>>>>>>>>>>> Error Producing Code at Compile time <<<<<<<<<<<<<<<<<<
            //dog.AnimalType( animal );

            //single dispatch "doesn't work as expected" due to the method not considering argument runtime types, only their compile-time types
            // Horse.AnimalType is method overloaded
            // Here i am passing animal (compile time object type = IAnimal and run time object type is Dog
            // But C# does not care about run time object type it will call the IAnimal expextion method 
            Horse horse = new Horse();
            horse.AnimalType( animal );
        }

    }




    interface IAnimal {
        void sound ();
    }

    class Dog : IAnimal {
        public void sound () {
            Console.WriteLine( "bhaw bhaw bhaw ..." );
        }

        // limitation of single dispatch
        public void AnimalType ( Dog a ) {
            Console.WriteLine( a.GetType() );
        }
    }


    class Horse : IAnimal {
        public void sound () {
            Console.WriteLine( "neighghghghghg ...." );
        }

        public void methodNotInParent () {
            Console.WriteLine( "Method that is not in the interface..." );
        }

        public void AnimalType ( IAnimal a ) {
            Console.WriteLine( "Animal type..." );
        }

        public void AnimalType ( Dog a ) {
            Console.WriteLine( "Dog type..." );
        }

    }
}
