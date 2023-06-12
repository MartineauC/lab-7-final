
public class Domino : IComparable<Domino>
{
    public int Side1Value { get; }
    public int Side2Value { get; private set; }

    public int Score => Side1Value + Side2Value;

    public Domino(int side1Value, int side2Value)
    {
        Side1Value = side1Value;
        Side2Value = side2Value;
    }

    public void Flip()
    {
        int temp = Side1Value;
        Side1Value = Side2Value;
        Side2Value = temp;
    }

    public override string ToString()
    {
        return $"[{Side1Value}|{Side2Value}]";
    }

    public int CompareTo(Domino other)
    {
        if (other == null)
            return 1;

        return Score.CompareTo(other.Score);
    }
}