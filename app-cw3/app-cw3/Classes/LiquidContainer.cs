using app_cw3.interfaces;

namespace app_cw3;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double weight, double height, double cargoMass, double depth, double maxLoadCapacity, bool isDangerous) : base(weight, height, cargoMass, depth, maxLoadCapacity)
    {
        SerialNumber = SerialNumberGenerator.GenerateNumber(ContainerTypes.L);
        IsDangerous = isDangerous;
    }

    public bool IsDangerous { get; set; }
    
    public override void Load(double cargoWeight)
    {
        if ((IsDangerous && cargoWeight > MaxLoadCapacity / 2) || (cargoWeight > MaxLoadCapacity * 0.9))
        {
            Emergency();
            return;
        }

        CargoMass = cargoWeight;

    }

    public override void Unload()
    {
        CargoMass = 0;
    }

    public void Emergency()
    {
        Console.WriteLine("Attempt to perform a hazardous operation in container " + SerialNumber);
    }

    public override void Info()
    {
        Console.WriteLine($"serial number: {SerialNumber}, weight: {Weight}, height: {Height}, cargoMass: {CargoMass}, depth: {Depth}, max load capacity: {MaxLoadCapacity}, dangerous product: {IsDangerous}");
    }
}