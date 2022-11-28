namespace Memento;

// Memento'ların referansının tutulduğu yerdir.
// UML diyagramındaki CareTaker strukturuna uyğundur.
class TextUndoCareTaker
{
    private readonly Stack<TextMemento> _mementos;

    public TextUndoCareTaker()
    {
        _mementos = new();
    }

    // Çağrılma işlemi yapıldığında yığının en üstündeki Memento örneği silinir ve geriye döndürülür.
    // Ekleme işlemi yapıldığında yığının en üstüne Memento örneği eklenir.
    // Klasik Stack.
    public TextMemento TextMemento
    {
        get
        {
            return _mementos.Pop();
        }
        set
        {
            _mementos.Push(value);
        }
    }
}
