namespace Lab08;

public class Map
{
    // Layout is readonly for now
    private readonly Room[][] _layout;
    public Room[][] Layout => _layout;

    public Map(string size)
    {
        if (size == "large")
            _layout = largeMap;
        else if (size == "medium")
            _layout = mediumMap;
        else
            _layout = smallMap;
    }

    private static readonly Direction N = Direction.North;
    private static readonly Direction E = Direction.East;
    private static readonly Direction S = Direction.South;
    private static readonly Direction W = Direction.West;

    // This was not the right way to do this...
    public readonly static Room[][] smallMap =  // 4 x 4
        [
            [new GateRoom([S]), new([E, S]), new FountainRoom([E, W]), new([S, W])],
            [new([N, S]), new([N, E]), new([S, W]), new([N, S])],
            [new([N, E, S]), new([E, W]), new(), new([N, S, W])],
            [new([N]), new([E]), new([N, W]), new([N])],
        ];
    public readonly static Room[][] mediumMap = // 6 x 6
    [
        [new GateRoom([E]), new([E, W]), new([E, W]), new([E, S, W]), new([E, W]), new([S, W])],
        [new([E]), new([E, W]), new([E, W]), new([N, W]), new([E, S]), new([N, S, W])],
        [new([E]), new([E, S, W]), new([E, W]), new([E, S, W]), new([N, W]), new([N, S])],
        [new([E, S]), new([N, W]), new([E, S]), new([N, S, W]), new([E]), new([N, W])],
        [new([N, E, S]), new([E, W]), new([N, S, W]), new([N, E]), new([E, W]), new([W, S])],
        [new([N]), new([E]), new([N, E, W]), new([E, W]), new([E, W]), new FountainRoom([N, W])]
    ];
public readonly static Room[][] largeMap =      // 8 x 8
[
        [new GateRoom([S]), new([S, E]), new([E, W]), new([E, W]), new([S, W]), new([E, S]), new([W]), new([S])],
        [new([N, E]), new([N, W]), new([E, S]), new([E, W]), new([N, S, W]), new([N, E, S]), new([E, W]), new([N, S, W])],
        [new([E, S]), new([E, W]), new([N, E, W]), new([S, W]), new([N, S]), new([N, E]), new([W, S]), new([N, S])],
        [new([N, S]), new([E]), new([E, W]), new([N, W]), new([N, E, S]), new([E, W]), new([N, E, S, W]), new([N, W])],
        [new([N, E, S]), new([E, W]), new([E, W]), new([E, S, W]), new([N, W]), new FountainRoom([S]), new([N, E, S]), new([S, W])],
        [new([N, S]), new([S]), new(), new([N, S]), new([E, S]), new([N, W]), new([N, S]), new([N, S])],
        [new([N, S]), new([N, E]), new([E, W]), new([N, E, W]), new([N, S, W]), new([S, E]), new([W, N]), new([N, S])],
        [new([N, E]), new([E, W]), new([E, W]), new([E, W]), new([N, E, W]), new([N, E, W]), new([E, W]), new([N, W])]
];

    public enum Direction { North, East, South, West }
}
