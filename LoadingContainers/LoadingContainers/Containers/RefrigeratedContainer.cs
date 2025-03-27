namespace LoadingContainers.Containers;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double ContainerTemperature { get; set; } //temperatura utrzymywana w kontenerze

    private static readonly Dictionary<string, double> RequiredProductTemperatures = new Dictionary<string, double>()
    {
        { "Banana", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(double height, double weight, double depth, string productType, double maxPayload,
        double containerTemperature) 
        : base(height, weight, depth, "C", maxPayload)
    {
        if (!RequiredProductTemperatures.ContainsKey(productType))
        {
            throw new ArgumentException($"Unsupported product type: {productType}");
        }
        ProductType = productType;
        ContainerTemperature = containerTemperature;
    }
    public override void Load(double cargoWeight)
    {
        if (RequiredProductTemperatures[ProductType] > ContainerTemperature)
        {
            throw new OverflowException("The container temperature is too low for this product");
        }
        if (cargoWeight + ActualCargoWeight > MaxPayload)
        {
            throw new OverflowException("Attempting to load a load in excess of the permitted capacity");
        }
        ActualCargoWeight += cargoWeight;
        Console.WriteLine($"Container {SerialNumber} loaded with {cargoWeight} kg of {ProductType}");
    }

    public override void Unload()
    {
        Console.WriteLine($"Container {SerialNumber} has been emptied. Remaining cargo: {ActualCargoWeight} kg");
    }
}