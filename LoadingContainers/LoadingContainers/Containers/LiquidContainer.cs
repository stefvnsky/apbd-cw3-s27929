using LoadingContainers.Exceptions;
using LoadingContainers.Interfaces;
namespace LoadingContainers.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous { get; set; } //czy kontener zawiera niebiezpiecnczny ładunek
    
    public LiquidContainer(double height, double weight, double depth, string serialNumber, double maxPayload, bool isHazardous)
        : base(height, weight, depth, serialNumber, maxPayload)
    {
        IsHazardous = isHazardous; //przechowanie wartosci we wlasciwosci
    }
    //załadunek
    public override void Load(double cargoWeight)
    {
        if (cargoWeight > MaxPayload)
        {
            throw new OverfillException("The loaded weight exceeds the maximum capacity of the container");
        }
        double maxLoadPercantage = IsHazardous ? 0.5 : 0.9; //jak niebezpieczny to 50% a jak nie to 90%
        double maxAllowedWeight = MaxPayload * maxLoadPercantage;
        //double maxAllowedWeightToLoad = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (cargoWeight > maxAllowedWeight)
        {
            NotifyHazard("Attempting to load too much weight into a container!!", SerialNumber);
            throw new OverfillException("Attempting to load a load in excess of the permitted capacity.");
        }   
        //ładowanie kontenera
        Console.WriteLine($"Container {SerialNumber} loaded: {cargoWeight} kg");
    }
    //oproznianie 
    public override void Unload()
    {
        Console.WriteLine($"Container {SerialNumber} has been emptied.");        
    }
    //powiadomienie
    public void NotifyHazard(string message, string serialNumber)
    {
        Console.WriteLine($"ATTENTION!: {message} (Container {serialNumber})");
    }
}