namespace ChainOfResponsibility;


abstract class CompilerCoR
{
    protected CompilerCoR? Next { get; set; }

    public virtual CompilerCoR SetNext(CompilerCoR next)
    {
        Next = next;
        return this;
    }

    public abstract void Handle();
}


class SyntaxAnalyzer : CompilerCoR
{
    public override void Handle()
    {
        Console.WriteLine("SyntaxAnalyzer");
        Next?.Handle();
    }
}

class LexicalAnalyzer : CompilerCoR
{
    public override void Handle()
    {
        Console.WriteLine("LexicalAnalyzer");
        Next?.Handle();
    }
}

class Linker : CompilerCoR
{
    public override void Handle()
    {
        Console.WriteLine("Linker");
        Next?.Handle();
    }
}



class Program
{
    static void Main()
    {
        CompilerCoR compiler = new SyntaxAnalyzer()
            .SetNext(new LexicalAnalyzer()
            .SetNext(new Linker()));

        compiler.Handle();
    }
}