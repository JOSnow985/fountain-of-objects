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

    public virtual void TripPlayer(Player player) { }
}

public class Pit : Obstacle
{
    public Pit(int x, int y) : base(x, y) { }
    public override void TripPlayer(Player player)
    {
        player.Dead = true;
        Console.Clear();
        Printer.ColorPrint(Printer.TextType.Enemy, "You have fallen into a pit and died. Your journey ends here.");
    }
}
