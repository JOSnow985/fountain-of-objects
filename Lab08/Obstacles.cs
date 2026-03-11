namespace Lab08;

public abstract class Obstacle
{
    // Obstacles have locations
    public int X = 0;
    public int Y = 0;
    
    public Obstacle (int x, int y)
    {
        X = x;
        Y = y;
    }

    public abstract void TripPlayer(Player player);         // Every Obstacle will do something different to the player
}

public class Pit : Obstacle
{
    public Pit(int x, int y) : base(x, y) { }
    public static Pit At(int x, int y) => new Pit(x, y);    // Will give us a cute way to call up a new Pit at the coordinates
    public override void TripPlayer(Player player)          // Pit just kills the player and ends the game
    {
        player.Dead = true;
        Console.Clear();
        Printer.ColorPrint(Printer.TextType.Enemy, "You have fallen into a pit and died. Your journey ends here.");
    }
}

public class Maelstrom : Obstacle
{
    public Maelstrom(int x, int y) : base(x, y) { }
    public static Maelstrom At(int x, int y) => new Maelstrom(x, y);
    public override void TripPlayer(Player player)          // Maelstrom moves player one space north, two spaces east, itself one space south, two spaces west
    {
        // Needs some way of checking if this is a valid set of moves
        int playerX = player.X + 2;
        int playerY = player.Y - 1;
        int maelstromX = X + 1;
        int maelstromY = Y - 2;

    }
}

public class Amarok : Obstacle
{
    public Amarok(int x, int y) : base(x, y) { }
    public static Amarok At(int x, int y) => new Amarok(x, y);
    public override void TripPlayer(Player player)          // Amarok also just kills the player and ends the game
    {
        player.Dead = true;
        Console.Clear();
        Printer.ColorPrint(Printer.TextType.Enemy, "You have fallen into a pit and died. Your journey ends here.");
    }
}
