// Jaden Olvera     CS-1410    Fountain of Objects for HW:23
using Lab08;

Printer.MapSelect();

string mapSelect = "small";
Map map;
while (true)
{
    string userInput = Console.ReadLine()!;
    if (userInput is not null)
    {
        userInput = userInput.ToLowerInvariant();
        if (userInput == "large")
        {
           map = Map.Medium;
            break;
        }
        else if (userInput == "medium")
        {
            map = Map.Medium;
            break;
        }
        else if (userInput == "small")
        {
            map = Map.Medium;
            break;
        }
        else
        {
            Console.WriteLine("Please enter a map size selection!");
        }
    }
}

Player player = new(map);

Printer.OpeningCrawl();
Console.ReadKey(true);

(Printer.TextType textType, string lastActionString) lastAction = (Printer.TextType.Enemy, "You've entered the Cavern of Objects...");
bool fountainIsOn = false;

while (true)
{
    Console.Clear();
    Console.WriteLine($"Currently at: ({player.X},{player.Y})");

    Printer.ColorPrint(lastAction.textType, $"{lastAction.lastActionString}\n");

    Console.WriteLine();

    // Console.Write("You see ");
    // Printer.ColorPrint(player.CurrentRoom is GateRoom ? Printer.TextType.Entrance : Printer.TextType.Narrative, $"{player.Look()}\n");

    // Console.Write("You hear ");
    // string weHear = $"{(player.Sound() == "the sound of silence." && player.NearPit ? "wind whispering quietly, a pit is likely to be close by." : player.Sound())}";
    // Printer.ColorPrint(player.CurrentRoom is FountainRoom ? Printer.TextType.Fountain : Printer.TextType.Narrative, $"{weHear}\n");
    
    // Console.Write("You smell ");
    // Printer.ColorPrint(Printer.TextType.Narrative, $"{player.Smell()}\n");

    Console.WriteLine("\nWhat's your next move?");

    // Player input will be Cyan
    Console.ForegroundColor = ConsoleColor.Cyan;
    switch (Console.ReadLine()?.ToLowerInvariant())
    {
        case "walk north":
        case "move north":
        case "north":
        case "n":
        case "up":
            lastAction = player.Move('N') ? (Printer.TextType.Narrative, "You walk to the North...") : (Printer.TextType.Descriptive, Printer.wallBonk);
            break;
        case "walk east":
        case "move east":
        case "east":
        case "e":
        case "right":
            lastAction = player.Move('E') ? (Printer.TextType.Narrative, "You walk to the East...") : (Printer.TextType.Descriptive, Printer.wallBonk);
            break;
        case "walk south":
        case "move south":
        case "south":
        case "s":
        case "down":
            lastAction = player.Move('S') ? (Printer.TextType.Narrative, "You walk to the South...") : (Printer.TextType.Descriptive, Printer.wallBonk);
            break;
        case "walk west":
        case "move west":
        case "west":
        case "w":
        case "left":
            lastAction = player.Move('W') ? (Printer.TextType.Narrative, "You walk to the West...") : (Printer.TextType.Descriptive, Printer.wallBonk);
            break;
        case "enable":
        case "toggle":
        case "turn on":
        case "activate":
        case "use":
        case "fountain":
            if (player.CurrentRoom is FountainRoom fountainRoom)
            {
                fountainRoom._fountainEnabled = fountainIsOn = !fountainRoom._fountainEnabled;
                lastAction = fountainRoom._fountainEnabled ? (Printer.TextType.Fountain, "You have enabled the Fountain of Objects!") : (Printer.TextType.Enemy, "You have disabled the Fountain of Objects... why?");
            }
            else
                lastAction = (Printer.TextType.Descriptive, "You can't enable the Fountain until you're in the room with it!");
            break;
        case "help":
            Printer.HelpMenu();
            break;
        case "leave":
        case "exit":
        case "bail":
        case "quit":
            if (player.CurrentRoom is GateRoom)
            {
                Console.Clear();
                Printer.ColorPrint(Printer.TextType.Enemy, "You decide this is too much and ascend out of the Cavern of Objects. The Uncoded One will probably win now. Nice.");
                return;
            }
            else
                lastAction = (Printer.TextType.Descriptive, "You can't leave unless you're at the entrance...");
            break;
        default:
            lastAction = (Printer.TextType.Descriptive, "The Rules of the Cavern prevent you from doing... that.");
            break;
    }
    // Return text color to white just in case
    Console.ForegroundColor = ConsoleColor.White;

    // Check if we've won...
    if (player.CurrentRoom is GateRoom && fountainIsOn)
        break;
    // Or if we've lost...
    foreach (Pit pit in map.MapPits)
    {
        if (player.X == pit.X && player.Y == pit.Y)
            pit.TripPlayer(player);
    }
    
    if (player.Dead)
        break;
}
if (!player.Dead)
{
    Console.Clear();
    Printer.ColorPrint(Printer.TextType.Entrance, "You've done it! The ");
    Printer.ColorPrint(Printer.TextType.Fountain, "Fountain of Objects");
    Printer.ColorPrint(Printer.TextType.Entrance, " has been activated and you've escaped with your life! Good job!");
}