namespace Lab08;

public class Map
{
    // Layout is readonly and only smallMap for now
    private readonly Room[][] _layout = smallMap;
    public Room[][] Layout => _layout;
    // public int CoordinateMax => Layout.GetLength(0) - 1;

    public Map() { }

    public readonly static Room[][] smallMap =
        [
            [new GateRoom(), new([Direction.East, Direction.South]), new FountainRoom(), new([Direction.South, Direction.West])],
            [new([Direction.North, Direction.South]), new([Direction.North, Direction.East]), new([Direction.South, Direction.West]), new([Direction.North, Direction.South])],
            [new([Direction.North, Direction.East, Direction.South]), new([Direction.East, Direction.West]), new(), new([Direction.North, Direction.South, Direction.West])],
            [new([Direction.North]), new([Direction.East]), new([Direction.North, Direction.West]), new([Direction.North])],
        ];

    public enum Direction { North, East, South, West }
}
