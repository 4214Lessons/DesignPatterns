namespace Memento;

// Değerleri tutulacak olan ve önceki dəyərlərine geri dönəbilən sinifdir.
// UML diyagramındaki Originator strukturuna uyğundur.
// Geriyə dönəbilmə özelliyi olduğundan öncəki vəziyyətləri tutan CareTaker referansını tutur.
class TextOriginator
{
    public string Text { get; set; }
    public int CursorPosition { get; set; }

    private readonly TextUndoCareTaker _textCareTaker;

    public TextOriginator()
    {
        _textCareTaker = new();
    }

    // Anlıq rekord dəyərlərini UML diyagramındaki CareTaker üzerindən yığına əlavə edir.
    public void Save()
    {
        _textCareTaker.TextMemento = new TextMemento
        {
            CursorPosition = this.CursorPosition,
            Text = this.Text
        };
    }

    // Geri qaytarma baş verdikdə, UML diaqramında CareTaker-dən yığının ən yüksək dəyərini alır.
    // Dəyər alma prosesindən sonra sinfin cari dəyərlərinə təyin edilir.
    public void Undo()
    {
        TextMemento previousTextMemento = _textCareTaker.TextMemento;

        CursorPosition = previousTextMemento.CursorPosition;
        Text = previousTextMemento.Text;
    }


    public override string ToString()
        => $"text: {Text}, cursor position: {CursorPosition}";
}