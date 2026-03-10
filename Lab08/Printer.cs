namespace Lab08;

public class Printer
{
    public static void ColorPrint(TextType textType, string message)
    {
        Console.ForegroundColor = textType switch
        {
            TextType.Narrative   => ConsoleColor.Magenta,
            TextType.Descriptive => ConsoleColor.White,
            TextType.Input       => ConsoleColor.Cyan,
            TextType.Fountain    => ConsoleColor.Blue,
            TextType.Enemy       => ConsoleColor.DarkRed,
            TextType.Entrance    => ConsoleColor.Yellow,
            _                    => ConsoleColor.White
        };

        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.White;   // Return to white after writing
    }
    public enum TextType { Entrance, Narrative, Descriptive, Input, Fountain, Enemy }
}
