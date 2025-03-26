namespace LoadingContainers.Interfaces;

public interface IHazardNotifier
{
    void NotifyHazard(string message, string serialNumber);
}