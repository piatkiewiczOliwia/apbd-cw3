using app_cw3;

public class Program
{
    public static void Main(string[] args)
    {
        //containers
        var l1 = new LiquidContainer(200,200,0,400,400,false);
        var l2 = new LiquidContainer(200,200,0,400,400,true);
        var g1 = new GasContainer(200, 200, 0, 500, 600, 1000);
        var r1 = new RefrigeratedContainer(150, 300, 0, 350, 1000, new Product("Bananas", 13.3), 14);
        
        //too low temp exception
        //var r2 = new RefrigeratedContainer(150, 300, 0, 350, 1000, new Product("Chocolate", 18), 12);
        
        //serial number check
        l1.Info();
        l2.Info();
        r1.Info();
        
        //loading and unloading
        l1.Load(300);
        l1.Info();
        l1.Unload();
        l1.Info();
        
        //overfill exception check
        //g1.Load(800);
        
        //emergency check
        //g1.Load(3000);
    
        //container ships
        var ship1 = new ContainerShip(10, 3, 2000);
        var ship2 = new ContainerShip(8, 2, 1000);
        
        //loading
        ship1.AddContainer(l1);
        ship1.Info();
        
        //unloading
        ship1.RemoveContainer(l1.SerialNumber);
        ship1.Info();
        
        //loading a list
        ship1.AddContainers(new List<Container> {l1,l2});
        ship1.Info();
        
        //replacing containers
        ship1.ReplaceContainer(l2.SerialNumber, g1);
        ship1.Info();
        
        //changing ships
        ContainerShip.ChangeShips(l1, ship1, ship2);
        ship1.Info();
        ship2.Info();
        
    }
}