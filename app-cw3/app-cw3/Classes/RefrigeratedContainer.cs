using app_cw3.Exceptions;

namespace app_cw3;

public class RefrigeratedContainer : Container
{
    public RefrigeratedContainer(double weight, double height, double cargoMass, double depth, double maxLoadCapacity, Product productType, double temperature) : base( weight, height, cargoMass, depth, maxLoadCapacity)
    {
        if (productType.MinTemperature > temperature)
        {
            throw new TooLowTemperatureException("The temperature in this container is too low for this type of product");
        }
        
        SerialNumber = SerialNumberGenerator.GenerateNumber(ContainerTypes.C);
        ProductType = productType;
        Temperature = temperature;

    }

    public Product ProductType { get; set; }
    public double Temperature { get; set; }
   
    public override void Info()
    {
        Console.WriteLine($"serial number: {SerialNumber}, weight: {Weight}, height: {Height}, cargoMass: {CargoMass}, depth: {Depth}, max load capacity: {MaxLoadCapacity}, product: {ProductType}, temperature: {Temperature}");
    }
    
}