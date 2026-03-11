namespace Lab08;

public class Room
{
    protected string _sight = "nothing, the unnatural darkness of the Cavern of Objects completely obscures your vision.";
    protected string _sound = "the sound of silence.";
    protected string _scent = "stale cavern air.";

    public string Sight => _sight;
    public virtual string Sound => _sound;  // virtual so we can override it in Fountain Room
    public string Scent => _scent;

    public Room(){}
    public Room(string sound, string scent)  // Constructor without sight, for the typical room
    {
        _sound = sound;
        _scent = scent;
    }

    // public virtual void RoomAction(){}
    // public enum RoomType { Normal, Gate, Fountain}
}

// Entrance and Exit room
public class GateRoom : Room
{
    public GateRoom()
    {
        _scent = "stale cavern air mixing with fresh air from above.";
        _sound = "birds happily chirping outside, and a soft hissing noise. Maybe that's your imagination.";
        _sight = "the sunlit entrance to the cavern, a roiling wall of darkness covers the only passage further.";
    }
}

public class FountainRoom : Room
{
    public bool _fountainEnabled = false;
    public override string Sound => _fountainEnabled ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!" : _sound;    // If the fountain is enabled, we return a different sound. 
    public FountainRoom()
        {
        _scent = "something damp, apparently mold still grows in the Cavern of Objects.";
        _sound = "water dripping in this room. The Fountain of Objects is here!";
    }

    public void ToggleFountain() => _fountainEnabled = !_fountainEnabled;
}
