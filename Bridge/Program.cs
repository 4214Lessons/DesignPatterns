namespace Bridge;


//// Implementation
//interface IColor
//{
//    string? Name { get; set; }
//    (int, int, int) GetRGB();
//}



//// Concrete implementation 1
//class Red : IColor
//{
//    public string? Name { get; set; } = "Red";
//    public (int, int, int) GetRGB() => (255, 0, 0);
//}


//// Concrete implementation 2
//class Blue : IColor
//{
//    public string? Name { get; set; } = "Blue";
//    public (int, int, int) GetRGB() => (0, 0, 255);
//}





//// Abstraction
//abstract class Shape
//{
//    public IColor Color { get; set; }

//    public double Area { get; protected set; }
//    public byte Corner { get; init; }
//    public string Name { get; set; }


//    protected Shape(IColor color, double area, byte corner, string name)
//    {
//        Color = color;
//        Area = area;
//        Corner = corner;
//        Name = name;
//    }
//}



//// Refined abstraction (optional)
//class Rectangle : Shape
//{
//    public double Width { get; set; }
//    public double Height { get; set; }

//    public Rectangle(IColor color, double width, double height)
//        : base(color, width * height, 4, nameof(Rectangle))
//    {
//        Width = width;
//        Height = height;
//    }

//}



//// Refined abstraction (optional)
//class Circle : Shape
//{
//    public double Radius { get; set; }

//    public Circle(IColor color, double radius)
//        : base(color, 3.14 * Math.Pow(radius, 2), 0, nameof(Circle))
//    {
//        Radius = radius;
//    }
//}



//class Program
//{
//    static void Main()
//    {
//        IColor color = new Red();
//        // color = new Blue();

//        Shape shape = new Rectangle(color, 10, 7);
//        // shape = new Circle(color, 10);


//        Console.WriteLine(shape.Name);
//        Console.WriteLine(shape.Area);
//        Console.WriteLine(shape.Corner);
//        Console.WriteLine(shape.Color.Name);
//        Console.WriteLine(shape.Color.GetRGB());
//    }
//}












public abstract class Remote
{
    protected readonly IDevice _device;
    public Remote(IDevice device)
    {
        _device = device;
    }


    public void TogglePower()
        => _device.IsEnabled = !_device.IsEnabled;

    public void VolumeDown() => --_device.Volume;
    public void VolumeUp() => ++_device.Volume;

    public void ChannelDown() => --_device.Channel;
    public void ChannnelUp() => ++_device.Channel;
}

public class AdvancedRemote : Remote
{
    public AdvancedRemote(IDevice device)
        : base(device) { }

    public void Mute()
    {
        _device.Volume = 0;
    }
}

public interface IDevice
{
    bool IsEnabled { get; set; }
    int Volume { get; set; }
    int Channel { get; set; }

    void Enable();
    void Disable();
}

public class Radio : IDevice
{
    public int Volume { get; set; }
    public int Channel { get; set; }
    public bool IsEnabled { get; set; }

    public void Disable() => IsEnabled = false;
    public void Enable() => IsEnabled = true;





    public override string ToString() =>
$"Device {nameof(Radio)},\n" +
$"Is Enabled - {IsEnabled},\n" +
$"Volume - {Volume},\n" +
$"Channel - {Channel}";
}


public class TV : IDevice
{
    public int Volume { get; set; }
    public int Channel { get; set; }
    public bool IsEnabled { get; set; }

    public void Disable() => IsEnabled = false;
    public void Enable() => IsEnabled = true;


    public override string ToString() =>
$"Device {nameof(TV)},\n" +
$"Is Enabled - {IsEnabled},\n" +
$"Volume - {Volume},\n" +
$"Channel - {Channel}";
}


class Program
{
    static void Main()
    {
        IDevice device = new Radio();
        device.Volume = 50;
        device.Channel = 22;

        Remote remote = new AdvancedRemote(device);
        remote.ChannnelUp();
        remote.VolumeDown();

        Console.WriteLine(device);


        device = new TV();
        device.Volume = 30;
        device.Channel = 45;

        remote = new AdvancedRemote(device);
        remote.TogglePower();
        remote.VolumeUp();
        remote.ChannnelUp();

        Console.WriteLine();
        Console.WriteLine(device);
    }
}