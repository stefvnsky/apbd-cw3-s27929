namespace LoadingContainers.Containers;

public abstract class Container
{
    public double Height { get; set; } 
    public double Weight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxPayload { get; set; }

    public Container(double Height, double Weight, double Depth, string SerialNumber, double MaxPayload)
    {
        this.Height = Height;
        this.Weight = Weight;
        this.Depth = Depth;
        this.SerialNumber = SerialNumber;
        this.MaxPayload = MaxPayload;
    }
    public abstract void Load(double cargoWeight);
    public abstract void Unload();
}