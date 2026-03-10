namespace Lab08;

public static class Printer
{
    public static readonly string wallBonk = "You bump into a wall of the cavern, you can't go that way.";
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
    public static void MapSelect()
    {
        Console.Clear();
        Console.WriteLine("You're nearing the Cavern of Objects, how big do you expect the cavern to be?");
        ColorPrint(TextType.Input, "Small   Medium   Large\n");
        Console.WriteLine("Enter a selection to continue...");
    }
    public static void OpeningCrawl()
    {
        Console.Clear();
        ColorPrint(TextType.Descriptive, "You descend into the ");
        ColorPrint(TextType.Enemy, "Cavern of Objects");
        ColorPrint(TextType.Descriptive, ", a maze of rooms with ");
        ColorPrint(TextType.Enemy, "dangerous pits");
        ColorPrint(TextType.Descriptive, " in search of the ");
        ColorPrint(TextType.Fountain, "Fountain of Objects.\n");
        ColorPrint(TextType.Entrance, "Light is visible only here, in the entrance, ");
        ColorPrint(TextType.Enemy, "a roiling wall of darkness covers the passage to the rest of the cavern.\n");
        ColorPrint(TextType.Descriptive, "You must navigate the Cavern with your other senses.\n");
        ColorPrint(TextType.Descriptive, "Find the ");
        ColorPrint(TextType.Fountain, "Fountain of Objects");
        ColorPrint(TextType.Descriptive, ", activate it, and return to the entrance.");
        ColorPrint(TextType.Entrance, "\n\nYou can use \"help\" to see the controls!");
        ColorPrint(TextType.Descriptive, "\nLook out for pits. You will hear a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will surely die.");
        // ColorPrint(TextType.Descriptive, "\nMaelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.");
        // ColorPrint(TextType.Descriptive, "\nAmaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench from nearby rooms.");
        // ColorPrint(TextType.Descriptive, "\nYou carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.");
        ColorPrint(TextType.Enemy, "\n\npress any key to begin");
    }

    public static void HelpMenu()
    {
        Console.Clear();
        ColorPrint(TextType.Fountain, "--- Commands ---\n");
        ColorPrint(TextType.Input, "\nNorth, East, South, West: Attempt to walk that direction.");
        ColorPrint(TextType.Input, "\nActivate: Attempt to activate the Fountain of Objects.");
        // ColorPrint(TextType.Input, "\nFire <Direction>: Attempt to fire your bow in a direction.");
        ColorPrint(TextType.Descriptive, "\n\nPress any key to return.");
        Console.ReadKey(true);
    }
    public enum TextType { Entrance, Narrative, Descriptive, Input, Fountain, Enemy }
}
