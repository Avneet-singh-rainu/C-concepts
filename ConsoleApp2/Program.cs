class Program {
    static void Main () {
        Console.WriteLine( "Hello World" );

        PhoneBuilder builder = new PhoneBuilder();
        builder.SetScreen( "6.5 inch" )
            .SetBattery( "4000 mAh" );

        Phone phone = builder.Build();
        Console.WriteLine( phone );

    }
}

interface IPhone {
    string? Screen { get; }
    string? Battery { get; }
    string? Processor { get; }
    string? Ram { get; }
    string? Storage { get; }
}

class Phone : IPhone {
    public string? Screen { get; }
    public string? Battery { get; }
    public string? Processor { get; }
    public string? Ram { get; }
    public string? Storage { get; }

    public Phone ( PhoneBuilder builder ) {
        Screen = builder.Screen;
        Battery = builder.Battery;
        Processor = builder.Processor;
        Ram = builder.Ram;
        Storage = builder.Storage;
    }

    public override string ToString () {
        return $"Phone [Screen={Screen}, Battery={Battery}, Processor={Processor}, RAM={Ram}, Storage={Storage}]";
    }
}

class PhoneBuilder {
    public string? Screen { get; private set; }
    public string? Battery { get; private set; }
    public string? Processor { get; private set; }
    public string? Ram { get; private set; }
    public string? Storage { get; private set; }

    public PhoneBuilder SetScreen ( string screen ) {
        Screen = screen;
        return this;
    }

    public PhoneBuilder SetBattery ( string battery ) {
        Battery = battery;
        return this;
    }

    public PhoneBuilder SetProcessor ( string processor ) {
        Processor = processor;
        return this;
    }

    public PhoneBuilder SetRam ( string ram ) {
        Ram = ram;
        return this;
    }

    public PhoneBuilder SetStorage ( string storage ) {
        Storage = storage;
        return this;
    }

    public Phone Build () {
        return new Phone( this );
    }
}
