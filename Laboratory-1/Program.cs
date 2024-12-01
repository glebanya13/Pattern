public class Car
{
    private const int engine = 3996;
    public const string name = "Audi RS7";
    protected const double modification = 4.0;

    private int power;
    public string type;
    protected bool actual;

    public int GetPower_computed()
    {
        return power;
    }

    public void SetPower_computed(int value)
    {
        power = value;
    }

    private string GetType_computed()
    {
        return type;
    }

    private void SetType_computed(string value)
    {
        type = value;
    }

    protected bool GetActual_computed()
    {
        return actual;
    }

    protected void SetActual_computed(bool value)
    {
        actual = value;
    }

    public Car()
    {
        power = 600;
        type = "petrol";
        actual = true;
    }

    public Car(int power, string type, bool actual)
    {
        this.power = power;
        this.type = type;
        this.actual = actual;
    }

    public Car(Car car)
    {
        power = car.power;
        type = car.type;
        actual = car.actual;
    }

    private void Stop()
    {
        Console.WriteLine("Car stopped");
    }

    public void Start()
    {
        Console.WriteLine("Car started");
    }

    protected void None()
    {
        Console.WriteLine("None method");
    }
}

public interface Book
{
    string GetTitle();
    void SetTitle(string value);
    string Read(int pageNumber);
    event EventHandler PageChanged;
    string this[int pageIndex] { get; set; }
}

public interface IPerson
{
    string GetName();
    void SetName(string value);

    int GetAge();
    void SetAge(int value);

    string GetSkinColor();
    void SetSkinColor(string value);

    void Introduce();
}


public class Person : IPerson
{
    private string name;
    private int age;
    private string skinColor;

    public Person(string name, int age, string skinColor)
    {
        this.name = name;
        this.age = age;
        this.skinColor = skinColor;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string value)
    {
        name = value;
    }

    public int GetAge()
    {
        return age;
    }

    public void SetAge(int value)
    {
        age = value;
    }

    public string GetSkinColor()
    {
        return skinColor;
    }

    public void SetSkinColor(string value)
    {
        skinColor = value;
    }

    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {name}, I am {age} years old, and my skin color is {skinColor}.");
    }
}

public class Transport
{
    private string privateTransportType;
    protected int protectedMaxSpeed;
    public string publicFuelType;

    public Transport()
    {
        privateTransportType = "Unknown";
        protectedMaxSpeed = 0;
        publicFuelType = "Unspecified";
    }

    public Transport(string transportType, int maxSpeed, string fuelType)
    {
        privateTransportType = transportType;
        protectedMaxSpeed = maxSpeed;
        publicFuelType = fuelType;
    }

    private string GetPrivateTransportType()
    {
        return privateTransportType;
    }

    private void SetPrivateTransportType(string value)
    {
        privateTransportType = value;
    }

    protected int GetProtectedMaxSpeed()
    {
        return protectedMaxSpeed;
    }

    protected void SetProtectedMaxSpeed(int value)
    {
        protectedMaxSpeed = value;
    }

    public string GetPublicFuelType()
    {
        return publicFuelType;
    }

    public void SetPublicFuelType(string value)
    {
        publicFuelType = value;
    }

    private void DisplayPrivateTransportInfo()
    {
        Console.WriteLine("Transport Type: " + privateTransportType);
    }

    protected void DisplayProtectedTransportInfo()
    {
        Console.WriteLine("Max Speed: " + protectedMaxSpeed);
    }

    public void DisplayPublicTransportInfo()
    {
        Console.WriteLine("Fuel Type: " + publicFuelType);
    }
}

public class Auto : Transport
{
    private string privateAutoModel;
    protected string protectedAutoBrand;
    public int publicNumberOfDoors;

    public Auto() : base()
    {
        privateAutoModel = "Unknown";
        protectedAutoBrand = "Generic";
        publicNumberOfDoors = 4;
    }

    public Auto(string transportType, int maxSpeed, string fuelType, string autoModel, string autoBrand, int numberOfDoors)
        : base(transportType, maxSpeed, fuelType)
    {
        privateAutoModel = autoModel;
        protectedAutoBrand = autoBrand;
        publicNumberOfDoors = numberOfDoors;
    }


    private void DisplayPrivateAutoInfo()
    {
        Console.WriteLine("Auto Model: " + privateAutoModel);
    }

    protected void DisplayProtectedAutoInfo()
    {
        Console.WriteLine("Auto Brand: " + protectedAutoBrand);
    }

    public void DisplayPublicAutoInfo()
    {
        Console.WriteLine("Number of Doors: " + publicNumberOfDoors);
    }

    public new void DisplayPublicTransportInfo()
    {
        Console.WriteLine("This is an Auto with " + publicNumberOfDoors + " doors.");
    }

    public void ShowProtectedInfoFromBase()
    {
        DisplayProtectedTransportInfo();
    }
}

class Program
{
    static void Main()
    {
        Car rs7 = new Car();
        Console.WriteLine($"rs7.power: {rs7.GetPower_computed()}");
        Console.WriteLine($"rs7.type: {rs7.type}");

        Car a6 = new Car(10, "petrol", true);
        Console.WriteLine($"a6.power: {a6.GetPower_computed()}");
        Console.WriteLine($"a6.type: {a6.type}");

        Car q5 = new Car(a6);
        Console.WriteLine($"q5.power: {q5.GetPower_computed()}");
        Console.WriteLine($"q5.type: {q5.type}");

        rs7.Start();

        IPerson person = new Person("Gleb", 18, "white");
        Console.WriteLine($"Name: {person.GetName()}");
        Console.WriteLine($"Age: {person.GetAge()}");
        person.Introduce();

        person.SetName("Denis");
        person.SetAge(18);

        Console.WriteLine($"Updated Name: {person.GetName()}");
        Console.WriteLine($"Updated Age: {person.GetAge()}");
        person.Introduce();
    }
}
