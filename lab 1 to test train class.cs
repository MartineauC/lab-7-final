class Program
{
    static void Main(string[] args)
    {
        Train train = new ConcreteTrain(6);
        Console.WriteLine($"Engine Value: {train.EngineValue}");
        Console.WriteLine($"Domino Count: {train.DominoCount}");
        Console.WriteLine($"Is Empty: {train.IsEmpty}");

        Domino domino1 = new Domino(6, 3);
        Domino domino2 = new Domino(3, 4);

        Console.WriteLine($"Is {domino1} playable: {train.IsPlayable(domino1)}");
        Console.WriteLine($"Is {domino2} playable: {train.IsPlayable(domino2)}");

        train.PlayDomino(domino1);
        Console.WriteLine($"Domino Count after playing {domino1}: {train.DominoCount}");
        Console.WriteLine($"Last Domino: {train.LastDomino}");

        train.PlayDomino(domino2);
        Console.WriteLine($"Domino Count after playing {domino2}: {train.DominoCount}");
        Console.WriteLine($"Last Domino: {train.LastDomino}");

        Console.WriteLine($"Train: {train}");

        Console.ReadLine();
    }
}

public class ConcreteTrain : Train
{
    public ConcreteTrain(int engineValue) : base(engineValue)
    {
    }

    public override bool IsPlayable(Domino domino, out bool flipRequired)
    {
        flipRequired = LastDominoSide2Value == domino.Side1Value;
        return flipRequired || LastDominoSide2Value == domino.Side2Value;
    }
}
