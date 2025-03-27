using LoadingContainers.Containers;
namespace LoadingContainers.Ships;

public class Ship
{
    public string ShipName { get; set; }
    public double MaxSpeed { get; set; }                    //maks predkosc
    public double MaxContainersWeight { get; set; }         //maks waga kontenerow
    public int MaxNumOfContainers { get; set; }             //maks liczba kontenerow
    public List<Container> LoadedContainers { get; set; }   //aktualnie zaladowane kontenery
    public double CurrentContainersWeight { get; set; }      //waga aktualnie zaladowanych

    public Ship(string shipName, double maxSpeed, double maxContainersWeight, int maxNumOfContainers)
    {
        ShipName = shipName;
        MaxSpeed = maxSpeed;
        MaxContainersWeight = maxContainersWeight;
        MaxNumOfContainers = maxNumOfContainers;
        LoadedContainers = new List<Container>();
        CurrentContainersWeight = 0;
    }
    public void LoadContainer(Container container)
    {
        if (LoadedContainers.Count >= MaxNumOfContainers)
        {
            Console.WriteLine("Max number of containers reached, ship is full.");
            return;
        }
        if (CurrentContainersWeight + container.ActualCargoWeight > MaxContainersWeight)
        {
            Console.WriteLine("Containers weight reached, ship is full.");
            return;
        }
        LoadedContainers.Add(container);
        CurrentContainersWeight += container.ActualCargoWeight; // Aktualizacja wagi
        Console.WriteLine($"Container {container.SerialNumber} loaded. Current containers weight: {CurrentContainersWeight} kg");
    }
    public void UnloadContainers(Container container)
    {
        if (!LoadedContainers.Contains(container))
        {
            Console.WriteLine($"Container {container.SerialNumber} is not on this ship.");
            return;
        }
        LoadedContainers.Remove(container);
        CurrentContainersWeight -= container.ActualCargoWeight;
        Console.WriteLine($"Container {container.SerialNumber} unloaded.Current containers weight: {CurrentContainersWeight} kg");
    }
    public void TransferContainers(Ship destinationShip, Container containerToTransfer)
    {
        if (!LoadedContainers.Contains(containerToTransfer))
        {
            Console.WriteLine($"Container {containerToTransfer.SerialNumber} is not on this ship.");
            return;
        }
        destinationShip.LoadContainer(containerToTransfer);
        this.UnloadContainers(containerToTransfer);
        Console.WriteLine($"Container {containerToTransfer.SerialNumber} transferred to {destinationShip.ShipName}");
    }
    private double GetTotalWeight()
    {
        double totalWeight = 0;
        foreach (var container in LoadedContainers)
        {
            totalWeight += container.ActualCargoWeight;
        }
        return totalWeight;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Ship: {ShipName}");
        foreach (var container in LoadedContainers)
        {
            Console.WriteLine($"Container {container.SerialNumber}: {container.ActualCargoWeight} kg");
        }
    }
    public void PrepareShip()
    {
        Console.WriteLine($"Ship: {ShipName}");
        Console.WriteLine($"Max spped: {MaxSpeed} knots");
        Console.WriteLine($"Max containers weight: {MaxContainersWeight} kg");
        Console.WriteLine($"Max num of containers: {MaxNumOfContainers}");
        Console.WriteLine($"Current containers weight: {CurrentContainersWeight} kg");
        Console.WriteLine($"Containers loaded: {LoadedContainers.Count}/{MaxNumOfContainers}");
    }
}