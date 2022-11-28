namespace State; // Vəziyyət

interface IState
{
    void Do(Television tv);
}


class Television
{
    public IState State { get; set; }

    public Television()
    {
        State = new OffState();
    }

    public void PressToggleButton() => State.Do(this);
}


class OffState : IState
{
    public void Do(Television tv)
    {
        tv.State = new OnState();
        Console.WriteLine("Televizor açıldı");
    }
}

class OnState : IState
{
    public void Do(Television tv)
    {
        tv.State = new OffState();
        Console.WriteLine("Televizor bağlandı");
    }
}




class Program
{
    static void Main()
    {
        Television tv = new Television();

        tv.PressToggleButton();
        tv.PressToggleButton();
        tv.PressToggleButton();
        tv.PressToggleButton();
    }
}