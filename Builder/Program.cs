using System.Text;

namespace Builder;


// Product
// IBuilder
// ConcreteBuilder1, ConcreteBuilder2
// Director (Optional)


/*
class House
{
    public string? Name { get; set; }
    public int Walls { get; set; }
    public int Doors { get; set; }
    public int Windows { get; set; }
    public bool HasRoof { get; set; }
    public bool HasGarage { get; set; }
    public bool HasGarden { get; set; }
    public bool HasPool { get; set; }

    public override string ToString()
    => @$"
        Name {Name}
        Walls {Walls}
        Doors {Doors}
        Windows {Windows}
        HasRoof {HasRoof}
        HasGarage {HasGarage}
        HasGarden {HasGarden}
        HasPool {HasPool}";
}


interface IHouseBuilder
{
    House House { get; set; }

    IHouseBuilder BuildWalls(int count);
    IHouseBuilder BuildDoors(int count);
    IHouseBuilder BuildWindows(int count);
    IHouseBuilder BuildRoof();
    IHouseBuilder BuildGarage();
    IHouseBuilder BuildGarden();
    IHouseBuilder BuildPool();

    void Reset();
    House Build();
}


class WoodHouseBuilder : IHouseBuilder
{
    public House House { get; set; } = new House { Name = "WoodHouse" };

    public IHouseBuilder BuildDoors(int count)
    {
        House.Doors = count;
        return this;
    }
    public IHouseBuilder BuildGarage()
    {
        House.HasGarage = true;
        return this;
    }
    public IHouseBuilder BuildGarden()
    {
        House.HasGarden = true;
        return this;
    }
    public IHouseBuilder BuildPool()
    {
        House.HasPool = true;
        return this;
    }
    public IHouseBuilder BuildRoof()
    {
        House.HasRoof = true;
        return this;
    }
    public IHouseBuilder BuildWalls(int count)
    {
        House.Walls = count;
        return this;
    }
    public IHouseBuilder BuildWindows(int count)
    {
        House.Windows = count;
        return this;
    }

    public House Build()
    {
        var result = House;

        Reset();
        House.Name = "WoodHouse";

        return result;
    }

    public void Reset() => House = new House();
}

class StoneHouseBuilder : IHouseBuilder
{
    public House House { get; set; } = new House { Name = "StoneHouse" };

    public IHouseBuilder BuildDoors(int count)
    {
        House.Doors = count;
        return this;
    }
    public IHouseBuilder BuildGarage()
    {
        House.HasGarage = true;
        return this;
    }
    public IHouseBuilder BuildGarden()
    {
        House.HasGarden = true;
        return this;
    }
    public IHouseBuilder BuildPool()
    {
        House.HasPool = true;
        return this;
    }
    public IHouseBuilder BuildRoof()
    {
        House.HasRoof = true;
        return this;
    }
    public IHouseBuilder BuildWalls(int count)
    {
        House.Walls = count;
        return this;
    }
    public IHouseBuilder BuildWindows(int count)
    {
        House.Windows = count;
        return this;
    }
    public House Build()
    {
        var result = House;

        Reset();
        House.Name = "StoneHouse";

        return result;
    }

    public void Reset() => House = new House();
}



class Director
{

    private IHouseBuilder _builder;

    public Director(IHouseBuilder builder)
    {
        _builder = builder;
    }


    public void ChangeBuilder(IHouseBuilder builder)
    {
        _builder = builder;
    }

    public IHouseBuilder BuildMinimalHouse()
        => _builder
               .BuildWalls(4)
               .BuildDoors(1)
               .BuildWindows(2)
               .BuildRoof();

    public IHouseBuilder BuildFullFeaturedHouse()
        => _builder
               .BuildWalls(12)
               .BuildDoors(3)
               .BuildWindows(7)
               .BuildRoof()
               .BuildGarage()
               .BuildGarden()
               .BuildPool();

}


class Program
{
    static void Main()
    {

        IHouseBuilder builder = new StoneHouseBuilder();
        House house;


        // Fluent
        house = builder
            .BuildWalls(4)
            .BuildDoors(1)
            .BuildWindows(2)
            .BuildRoof()
            .Build();


        Director director = new(builder);
        house = director.BuildFullFeaturedHouse().Build();

        // Console.WriteLine(house);










        // FluentValidation 

        
        // StringBuilder sb = new StringBuilder();
        // 
        // string fullname = sb
        //         .Append("Tural")
        //         .Append(" ")
        //         .Append("Novruzov")
        //         .ToString();
        // 
        // Console.WriteLine(fullname);
        
    }
}
*/









class EndPointBuilder
{
    private string _baseUrl;
    private StringBuilder _routeParameters;
    private StringBuilder _queryStrings;


    public EndPointBuilder(string baseUrl)
    {
        _baseUrl = baseUrl;
        _routeParameters = new();
        _queryStrings = new();
    }


    public EndPointBuilder AppendRoute(string route)
    {
        _routeParameters.Append('/');
        _routeParameters.Append(route);
        return this;
    }


    public EndPointBuilder AppendQueryString(string key, string value)
    {
        _queryStrings.Append(key);
        _queryStrings.Append('=');
        _queryStrings.Append(value);
        _queryStrings.Append('&');

        return this;
    }



    public string Build()
    {
        var url = $"{_baseUrl}{_routeParameters}";

        if (_queryStrings.Length > 0)
            url += $"?{_queryStrings.ToString().TrimEnd('&')}";

        return url;
    }
}



class Program
{
    static void Main()
    {
        string url = new EndPointBuilder("https://www.logbook.itstep.org")
            .AppendRoute("api")
            .AppendRoute("v1")
            .AppendRoute("teachers")
            .AppendQueryString("name", "Tural")
            .AppendQueryString("surname", "Novruzov")
            .Build();


        Console.WriteLine(url);
    }
}