using app_cw3.Exceptions;

namespace app_cw3;

public class ContainerShip
{
    public ContainerShip(double maxSpeed, int maxContainersCapacity, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainersCapacity = maxContainersCapacity;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }
    
    public List<Container> Containers { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainersCapacity { get; set; }
    public double MaxWeight { get; set; }

    public void AddContainer(Container container)
    {
        if (Containers.Count >= MaxContainersCapacity || GetTotalWeight() + container.CargoMass + container.Weight > MaxWeight)
        {
            throw new OverfillException("This container ship is full");
        }
        else
        {
            Containers.Add(container);
        }
        
    }

    public void AddContainers(List<Container> containersList)
    {
        double containersWeight = 0;
        foreach (var container in containersList)
        {
            containersWeight += container.Weight + container.CargoMass;
        }

        if (Containers.Count + containersList.Count > MaxContainersCapacity || GetTotalWeight() + containersWeight > MaxWeight)
        {
            throw new OverfillException("This container ship is full");
        }
        else
        {
            Containers.AddRange(containersList);
        }

    }

    public void RemoveContainer(string serialNumber)
    {
        Container container = Containers.Find(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            Containers.Remove(container);
        }
    }

    public void ReplaceContainer(string oldSerialNumber, Container newContainer)
    {
        RemoveContainer(oldSerialNumber);
        AddContainer(newContainer);
    }

    public static void ChangeShips(Container container, ContainerShip oldShip, ContainerShip newShip)
    {
        oldShip.RemoveContainer(container.SerialNumber);
        newShip.AddContainer(container);
    }

    public double GetTotalWeight()
    {
        double total = 0;
        foreach (var container in Containers)
        {
            total += container.CargoMass + container.Weight;
        }

        return total;
    }

    public void Info()
    {
        Console.WriteLine($"Ship info:\n max speed: {MaxSpeed}, container capacity: {MaxContainersCapacity}, max weight: {MaxWeight}");
        Console.WriteLine("Containers on this ship: ");
        foreach (var container in Containers)
        {
            container.Info();
        }
        
    }
}