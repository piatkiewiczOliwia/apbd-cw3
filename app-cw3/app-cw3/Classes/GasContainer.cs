using app_cw3.Exceptions;
using app_cw3.interfaces;

namespace app_cw3;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double weight, double height, double cargoMass, double depth, double maxLoadCapacity, int pressure) : base( weight, height, cargoMass, depth, maxLoadCapacity)
    {
        SerialNumber = SerialNumberGenerator.GenerateNumber(ContainerTypes.G);
        Pressure = pressure;
    }
    
    public int Pressure { get; private set; }

    public override void Load(double cargoWeight)
    {
        if (CargoMass + cargoWeight > MaxLoadCapacity)
        {
            Emergency();
            throw new OverfillException("Container is full");
        }
        else
        {
            CargoMass = cargoWeight;
        }
    }

    public override void Unload()
    {
        CargoMass *= 0.05;
    }

    public void Emergency()
    {
        Console.WriteLine("Emergency situation in container " + SerialNumber);
    }

    public override void Info()
    {
        Console.WriteLine($"serial number: {SerialNumber}, weight: {Weight}, height: {Height}, cargoMass: {CargoMass}, depth: {Depth}, max load capacity: {MaxLoadCapacity}, pressure: {Pressure}");
    }
}