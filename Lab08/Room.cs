namespace Lab08;

public class Room
{
    protected string _sight = "nothing, the unnatural darkness of the Cavern of Objects completely obscures your vision.";
    protected string _sound = "the sound of silence.";
    protected string _scent = "stale cavern air.";

    public string Sight => _sight;
    public virtual string Sound => _sound;  // virtual so we can override it in Fountain Room
    public string Scent => _scent;
    public List<Map.Direction> Exits {get; set;} = [ Map.Direction.North, Map.Direction.East, Map.Direction.South, Map.Direction.West ];

    public Room(){}
    public Room(List<Map.Direction> exits) { Exits = exits; }   // Constructor with only exits passed
    public Room(string sound, string scent, List<Map.Direction> exits)  // Constructor without sight, for the typical room
    {
        _sound = sound;
        _scent = scent;
        Exits = exits;
    }

    // public virtual void RoomAction(){}
    // public enum RoomType { Normal, Gate, Fountain}
}

// Maybe use public static methods to pass parameters to a constructor instead of derived classes?

// Entrance and Exit room
public class GateRoom : Room
{
    public GateRoom() : base("birds happily chirping outside, and a soft hissing noise. Maybe that's your imagination.",
                             "stale cavern air mixing with fresh air from above.",
                             [Map.Direction.South]) 
                             => _sight = "the sunlit entrance to the cavern, a roiling wall of darkness covers the only passage further.";
}

public class FountainRoom : Room
{
    public bool _fountainEnabled = false;
    public override string Sound => _fountainEnabled ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!" : _sound;    // If the fountain is enabled, we return a different sound. 
    public FountainRoom() : base("water dripping in this room. The Fountain of Objects is here!", "something damp, apparently mold still grows in the Cavern of Objects.", [Map.Direction.East, Map.Direction.West]) {}

    public void ToggleFountain() => _fountainEnabled = !_fountainEnabled;
}
