using LoadingContainers.Exceptions;
using LoadingContainers.Interfaces;
namespace LoadingContainers.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double height, double weight, double depth, double maxPayload, double pressure)
        : base(height, weight, depth,"G", maxPayload)
    {
        Pressure = pressure;
    }
    public void NotifyHazard(string message, string serialNumber)
    {
        Console.WriteLine($"ATTENTION!: {message} (Container {serialNumber})");
    }
    public override void Unload()
    {
        ActualCargoWeight *= 0.05;
        Console.WriteLine($"Container {SerialNumber} has been emptied. Remaining cargo: {ActualCargoWeight} kg");      
    }
}