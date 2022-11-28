namespace Memento;

// Saxlamaq istədiyimiz dəyərlərin tanımlandığı yerdir.
// UML diyagramındaki Memento strukturuna uyğundur.
class TextMemento
{
    public string Text { get; set; }
    public int CursorPosition { get; set; }
}
