using LoadingContainers.Exceptions;

namespace LoadingContainers.Containers;

public abstract class Container
{
    private static int _serialNumberCounter = 1;
    public double ActualCargoWeight { get; set; } 
    public double Height { get; set; } 
    public double Weight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public string ContainerType { get; set; }
    public double MaxPayload { get; set; }

    public Container(double height, double weight, double depth, string containerType, double maxPayload)
    {
        ActualCargoWeight = 0;
        this.Height = height;
        this.Weight = weight;
        this.Depth = depth;
        this.ContainerType = containerType;
        SerialNumber = GenerateContainerSerialNumber(containerType);
        this.MaxPayload = maxPayload;
    }
    private string GenerateContainerSerialNumber(string containerType)
    {
        return $"KON-{containerType}-{_serialNumberCounter++}";
    }
    public virtual void Load(double cargoWeight)
    {
        if (cargoWeight + ActualCargoWeight > MaxPayload)
        {
            throw new OverfillException("Attempting to load a load in excess of the permitted capacity");
        }
        ActualCargoWeight += cargoWeight;
        Console.WriteLine($"Container {SerialNumber} loaded: {cargoWeight} kg");
    }
    public abstract void Unload();
}