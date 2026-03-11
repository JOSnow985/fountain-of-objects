namespace Lab08;

public class Player
{
    // Player starts from 0, 0, top left corner.
    public int X = 0;
    public int Y = 0;
    public bool Dead = false;
    private readonly Map Map;
    public Room CurrentRoom => 
    //Map.RoomList.Contains((Map.Entrance, X, Y)) ? Map.Entrance : ;
    public bool NearPit
    {
        get
        {
            foreach (Pit pit in Map.MapPits)
            {
                if (Math.Abs(X - pit.X) <= 1 && Math.Abs(Y - pit.Y) <= 1)
                {
                    return true;
                }
            }
            return false;
        }
    }

    // Need a map for the player to be on from the constructor
    public Player(Map selectedMap) { Map = selectedMap; }

    public string Sense() => CurrentRoom.Sight;     // Returns a string based on where the player is and what they're close to
    public bool Move(char dir)
    {
        if (!Map.ExitsList[Y][X].Contains(dir))
            return false;
        else
        {
            switch (dir)
            {
                case 'N':
                    Y--;
                    return true;
                case 'E':
                    X++;
                    return true;
                case 'S':
                    Y++;
                    return true;
                case 'W':
                    X--;
                    return true;
                default:
                    return false;
            }
        }
    }
    // public bool MoveCheck(Map.Direction dir) => CurrentRoom.Exits.Contains(dir);
}
