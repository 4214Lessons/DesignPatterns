namespace Memento; // Xatirə

// Also known as: Snapshot - Anlıq görüntü

// Originator - Yaradıcı
// Memento - Xatirə
// Caretaker - Gözətçi, Baxıcı



class Program
{
    static void Main()
    {
        TextOriginator textOriginator = new TextOriginator();

        textOriginator.Text = "asm";
        textOriginator.CursorPosition = 3;

        // Anlıq vəziyyət yığına əlavə edilir.
        textOriginator.Save();


        textOriginator.Text = "asmi";
        textOriginator.CursorPosition = 4;

        // Anlıq vəziyyət yığına əlavə edilir.
        textOriginator.Save();

        textOriginator.Text = "asmin";
        textOriginator.CursorPosition = 5;

        // Anlıq vəziyyət yığına əlavə edilir.
        textOriginator.Save();


        // Yığındaki bir öncəki vəziyyətə keçir.
        textOriginator.Undo();
        Console.WriteLine(textOriginator.ToString());

        // Yığındaki bir öncəki vəziyyətə keçir.
        textOriginator.Undo();
        Console.WriteLine(textOriginator.ToString());

        // Yığındaki bir öncəki vəziyyətə keçir.
        textOriginator.Undo();
        Console.WriteLine(textOriginator.ToString());


        // OUTPUT:
        //  text: asmin, cursor position: 5
        //  text: asmi, cursor position: 4
        //  text: asm, cursor position: 3
    }
}