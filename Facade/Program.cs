#nullable disable

namespace Facade;


interface IDevice
{
    string Vendor { get; set; }
    string Model { get; set; }
    void Start();
}


class CPU : IDevice
{
    public string Vendor { get; set; }
    public string Model { get; set; }

    public void Start()
    {
        Console.WriteLine("CPU started");
    }
}


class RAM : IDevice
{
    public string Vendor { get; set; }
    public string Model { get; set; }

    public void Start()
    {
        Console.WriteLine("RAM started");
    }
}

class GPU : IDevice
{
    public string Vendor { get; set; }
    public string Model { get; set; }

    public void Start()
    {
        Console.WriteLine("GPU started");
    }
}

class MotherBoard : IDevice
{
    public string Vendor { get; set; }
    public string Model { get; set; }

    public void Start()
    {
        Console.WriteLine("Motherboard started");
    }

}

class PowerSupply : IDevice
{
    public string Vendor { get; set; }
    public string Model { get; set; }

    public void Start()
    {
        Console.WriteLine("PowerSupply started");
    }
}

class Case : IDevice
{
    private readonly List<IDevice> _devices = new();

    public string Vendor { get; set; }
    public string Model { get; set; }

    public void AddDevice(IDevice _otherDevice)
    {
        _devices.Add(_otherDevice);
    }

    public void Start()
    {
        _devices.ForEach(e => e.Start());
    }
}




class ComputerFacade
{
    MotherBoard mb = new MotherBoard();
    RAM ram = new RAM();
    GPU gpu = new GPU();
    CPU cpu = new CPU();
    PowerSupply ps = new PowerSupply();
    Case c = new Case();

    public ComputerFacade()
    {
        c.AddDevice(mb);
        c.AddDevice(ram);
        c.AddDevice(gpu);
        c.AddDevice(cpu);
        c.AddDevice(ps);
    }

    public void Start()
    {
        // some hard code 

        c.Start();
        Console.WriteLine("Computer started");
    }
}



class Program
{
    static void Main()
    {
        ComputerFacade facade = new ComputerFacade();
        facade.Start();
    }
}