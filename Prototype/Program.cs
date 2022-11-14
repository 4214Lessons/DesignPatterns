using static System.Console;



namespace Prototype_Example_1
{

    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return MemberwiseClone() as Person;
        }

        public Person DeepCopy()
        {
            Person clone = (Person)MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            return clone;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            IdNumber = idNumber;
        }
    }




    class Program
    {
        static void Main1()
        {
            Person p1 = new Person();
            p1.Age = 18;
            p1.BirthDate = Convert.ToDateTime("2004-08-29");
            p1.Name = "Kenan Muradov";
            p1.IdInfo = new IdInfo(666);


            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();


            WriteLine("Original values of p1, p2, p3:");

            WriteLine("   p1 instance values: ");
            DisplayValues(p1);

            WriteLine("   p2 instance values:");
            DisplayValues(p2);

            WriteLine("   p3 instance values:");
            DisplayValues(p3);





            p1.Age = 19;
            p1.BirthDate = Convert.ToDateTime("2003-09-01");
            p1.Name = "Miri";
            p1.IdInfo.IdNumber = 7878;

            WriteLine("\nValues of p1, p2 and p3 after changes to p1:");

            WriteLine("   p1 instance values: ");
            DisplayValues(p1);

            WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);

            WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }


        public static void DisplayValues(Person p)
        {
            WriteLine($"\tName: {p.Name}, Age: {p.Age}, BirthDate: {p.BirthDate.ToShortDateString()}");
            WriteLine($"\tID#: {p.IdInfo.IdNumber}");
        }
    }
}







namespace Prototype_Example_2
{

    using System.Runtime.Serialization.Formatters.Binary;


    [Serializable]
    public abstract class IPrototype<T>
    {
        // Shallow copy
        public T Clone()
        {
            return (T)MemberwiseClone();
        }


        // Deep Copy
        public T DeepCopy()
        {
            using MemoryStream stream = new();
            BinaryFormatter formatter = new();

#pragma warning disable SYSLIB0011
            formatter.Serialize(stream, this);

            stream.Seek(0, SeekOrigin.Begin);

            T copy = (T)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011

            return copy;
        }
    }
}








namespace Prototype_Example_3
{
    record PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main()
        {
            PersonDTO p1 = new();
            PersonDTO p2 = p1 with { Name = "Murad"};
        }
    }
}






namespace Prototype_Example_3
{
    // interface IPrototype
    // {
    //     IPrototype Clone();
    // }


    class Airplane : ICloneable
    {
        //public IPrototype Clone()
        //{
        //    ShallowCopy
        //    Airplane clone = MemberwiseClone() as Airplane;
        //    return clone;
        //}

        public object Clone()
        {
            // ShallowCopy
            Airplane clone = MemberwiseClone() as Airplane;
            return clone;
        }
    }
}