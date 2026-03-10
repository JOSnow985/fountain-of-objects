namespace Lab08;

public class Player
{
    // Player starts from 0, 0, top left corner.
    public int X = 0;
    public int Y = 0;
    private readonly Map Map;
    public Room CurrentRoom => Map.Layout[Y][X];

    // Need a map for the player to be on from the constructor
    public Player(Map selectedMap) { Map = selectedMap; }

    // Our senses retrieve info from the room we're currently in
    public string Look() => CurrentRoom.Sight;
    public string Smell() => CurrentRoom.Scent;
    public string Sound() => CurrentRoom.Sound;
    public bool MoveNorth()
    {
        if (!CurrentRoom.Exits.Contains(Map.Direction.North))
            return false;
        else
        {
            Y--;
            return true;
        }
    }
    public bool MoveEast()
    {
        if (!CurrentRoom.Exits.Contains(Map.Direction.East))
            return false;
        else
        {
            X++;
            return true;
        }
    }
    public bool MoveSouth()
    {
        if (!CurrentRoom.Exits.Contains(Map.Direction.South))
            return false;
        else
        {
            Y++;
            return true;
        }
    }
    public bool MoveWest()
    {
        if (!CurrentRoom.Exits.Contains(Map.Direction.West)) 
            return false;
        else
        {
            X--;
            return true;
        }
    }
    // public bool MoveCheck(Map.Direction dir) => CurrentRoom.Exits.Contains(dir);
}
