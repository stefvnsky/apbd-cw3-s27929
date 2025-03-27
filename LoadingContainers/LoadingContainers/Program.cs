using LoadingContainers.Containers;
using LoadingContainers.Ships;

class Program
{
    static void Main(string[] args)
    {
        Container liquidContainer = new LiquidContainer(200, 2500, 100, 4000, true);
        Container gasContainer = new GasContainer(200, 2500, 100, 1500, 20);
        Container refrigeratedContainer = new RefrigeratedContainer(250, 1200, 100, "Meat", 2500, -20);

        Ship ship = new Ship("MSC-Titanic", 20, 200000, 150);
        ship.LoadContainer(liquidContainer);
        ship.LoadContainer(gasContainer);
        ship.LoadContainer(refrigeratedContainer);
        
        ship.PrintInfo();
        ship.PrepareShip();
        
        Ship ship2 = new Ship("Atlantic", 25, 40000, 80);
        ship.TransferContainers(ship2, refrigeratedContainer);
        
        ship.PrintInfo();
        ship2.PrintInfo();
    }
}