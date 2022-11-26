namespace Mediator; // Vasitəçi

// Also known as: Intermediary, Controller - Vasitəçi, Nəzarətçi


interface ICenter
{
    void AddAirplane(Airplane airplane);
    void LandingPermission(Airplane airplane);
    void TakeOffPermission(Airplane airplane);
}


class Center : ICenter
{
    private List<Airplane> _airplanes = new();

    public void AddAirplane(Airplane airplane)
    {
        _airplanes.Add(airplane);
    }

    public void LandingPermission(Airplane airplane)
    {
        for (int i = 0; i < _airplanes.Count; i++)
        {
            Airplane next = _airplanes[i];

            if (next.GetType() != airplane.GetType())
            {
                airplane.HandleMessage(next, "Eniş icazesi");
            }
        }
    }

    public void TakeOffPermission(Airplane airplane)
    {
        for (int i = 0; i < _airplanes.Count; i++)
        {
            Airplane next = _airplanes[i];

            if (next.GetType() != airplane.GetType())
            {
                airplane.HandleMessage(next, "Gediş icazesi");
            }
        }
    }
}



abstract class Airplane
{
    public string Code { get; set; }

    private readonly ICenter _center;
    public ICenter Center => _center;


    protected Airplane(ICenter center)
    {
        _center = center;
    }

    public virtual void HandleMessage(Airplane airplane, string message)
    {
        Console.WriteLine($"{Code} kodlu teyyareden {airplane.Code} kodlu teyyareye gelen mesaj: {message}");
    }

    public abstract void LandingPermission();
    public abstract void TakeOffPermission();
}


class AHY : Airplane
{
    public AHY(ICenter center) : base(center)
    {
        Code = "AHY";
    }

    public override void LandingPermission()
    {
        Center.LandingPermission(this);
    }

    public override void TakeOffPermission()
    {
        Center.TakeOffPermission(this);
    }
}


class Buta : Airplane
{
    public Buta(ICenter center) : base(center)
    {
        Code = "Buta";
    }

    public override void LandingPermission()
    {
        Center.LandingPermission(this);
    }

    public override void TakeOffPermission()
    {
        Center.TakeOffPermission(this);
    }
}



class Program
{
    static void Main()
    {
        ICenter center = new Center();

        AHY ahy = new AHY(center);
        Buta buta = new Buta(center);

        center.AddAirplane(ahy);
        center.AddAirplane(buta);

        ahy.LandingPermission();
        buta.TakeOffPermission();

        // buta.LandingPermission();
        // ahy.TakeOffPermission();
    }
}