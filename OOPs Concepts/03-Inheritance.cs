namespace LowLevelDesign;

public class Vehicle
{
    public void Start()
    {
        Console.WriteLine("Vehicle started.");
    }
}

//Car inherits the public members of Vehicle.
public class Car : Vehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is being driven.");
    }
}

public static class InheritanceDemo
{
    public static void Run()
    {
        var car = new Car();

        //Inherited from Vehicle class.
        car.Start();

        //Defined a car.
        car.Drive();
    }
}