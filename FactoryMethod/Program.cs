namespace FactoryPattern_Example_1
{
    interface IProduct
    {
        string ShipFrom();
    }


    class ProductA : IProduct
    {
        public string ShipFrom()
        {
            return " from South Africa";
        }
    }

    class ProductB : IProduct
    {
        public string ShipFrom()
        {
            return " from Spain";
        }
    }

    class DefaultProduct : IProduct
    {
        public string ShipFrom()
        {
            return "not available";
        }
    }


    class Creator
    {
        public IProduct FactoryMethod(int month)
            => month switch
            {
                >= 4 and <= 11 => new ProductA(),
                1 or 2 or 12 => new ProductB(),
                _ => new DefaultProduct()
            };
    }



    class Client
    {
        // static void Main()
        // {
        //     Creator c = new Creator();
        //     IProduct product;
        // 
        //     for (int m = 1; m <= 12; m++)
        //     {
        //         product = c.FactoryMethod(m);
        //         Console.WriteLine("Avocados " + product.ShipFrom());
        //     }
        // }
    }

}





















namespace FactoryPattern_Example_2
{
    public interface ITransport
    {
        void Deliver();
    }

    public class Truck : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivered By Road in a box");
    }

    public class Ship : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivered By Sea in a container");
    }

    public class Airplane : ITransport
    {
        public void Deliver() => Console.WriteLine("Delivered By Air in a box");
    }




    public abstract class Logistics
    {
        public void PlanDelivery()
        {
            ITransport transport = CreateTranport();
            transport.Deliver();
        }

        public abstract ITransport CreateTranport();
    }


    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTranport() => new Truck();
    }

    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTranport() => new Ship();
    }

    public class AirLogistics : Logistics
    {
        public override ITransport CreateTranport() => new Airplane();
    }




    class Program
    {
        static void Main()
        {
            // Logistics logistics = new AirLogistics();
            // ITransport transport = logistics.CreateTransport();
            // transport.Deliver();

            Logistics? logistics = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
                        1: Road
                        2: Sea
                        3: Air
                        Any: Exit");

                Console.Write("\n\tEnter choice: ");


                logistics = Console.ReadLine() switch
                {
                    "1" => new RoadLogistics(),
                    "2" => new SeaLogistics(),
                    "3" => new AirLogistics(),
                    _ => null
                };

                if (logistics == null)
                    break;


                logistics?.PlanDelivery();

                Console.ReadKey();
            }
        }
    }
}