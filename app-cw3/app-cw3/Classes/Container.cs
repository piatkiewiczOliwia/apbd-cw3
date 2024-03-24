using app_cw3.Exceptions;
using app_cw3.interfaces;

namespace app_cw3;

public abstract class Container : IContainer
{
    protected Container(double weight, double height, double cargoMass, double depth, double maxLoadCapacity)
    {
        SerialNumber = "";
        Weight = weight;
        Height = height;
        CargoMass = cargoMass;
        Depth = depth;
        MaxLoadCapacity = maxLoadCapacity;

    }

    public double Weight { get; set; }
    public double Height { get; set; }
    public double CargoMass { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoadCapacity { get; set; }

    public virtual void Unload() { }
    public virtual void Load(double cargoWeight) { }

    public virtual void Info() { }
}