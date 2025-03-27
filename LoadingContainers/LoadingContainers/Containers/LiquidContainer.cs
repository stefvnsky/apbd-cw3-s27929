using LoadingContainers.Exceptions;
using LoadingContainers.Interfaces;
namespace LoadingContainers.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous { get; set; } //czy kontener zawiera niebiezpiecnczny ładunek
    
    public LiquidContainer(double height, double weight, double depth, double maxPayload, bool isHazardous)
        : base(height, weight, depth, "L", maxPayload)
    {
        IsHazardous = isHazardous; //przechowanie wartosci we wlasciwosci
    }
    //załadunek
    public override void Load(double cargoWeight)
    {
        base.Load(cargoWeight);
        
        /*double maxLoadPercantage = IsHazardous ? 0.5 : 0.9;
        double maxAllowedWeight = MaxPayload * maxLoadPercantage;*/
        
        double maxAllowedWeightToLoad = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (cargoWeight + ActualCargoWeight > maxAllowedWeightToLoad)
        {
            NotifyHazard("Attempting to load too much weight into a container!!", SerialNumber);
            throw new OverfillException("Attempting to load a load in excess of the permitted capacity.");
        }   
        //ładowanie kontenera
        ActualCargoWeight += cargoWeight;
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