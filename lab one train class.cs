using System;
using System.Collections.Generic;

public abstract class Train
{
    protected List<Domino> dominos;
    protected int engineValue;

    public Train()
    {
        dominos = new List<Domino>();
        engineValue = 0;
    }

    public Train(int engineValue)
    {
        dominos = new List<Domino>();
        this.engineValue = engineValue;
    }

    public int DominoCount => dominos.Count;

    public int EngineValue => engineValue;

    public bool IsEmpty => dominos.Count == 0;

    public Domino LastDomino => dominos.Count > 0 ? dominos[dominos.Count - 1] : null;

    public int LastDominoSide2Value => LastDomino != null ? LastDomino.Side2Value : 0;

    public Domino GetDominoAtPosition(int index)
    {
        if (index >= 0 && index < dominos.Count)
        {
            return dominos[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Invalid index.");
        }
    }

    public bool IsPlayable(Domino domino)
    {
        return IsPlayable(domino, out _);
    }

    public abstract bool IsPlayable(Domino domino, out bool flipRequired);

    public void PlayDomino(Domino domino)
    {
        bool flipRequired;
        if (IsPlayable(domino, out flipRequired))
        {
            if (flipRequired)
            {
                domino.Flip();
            }
            dominos.Add(domino);
        }
        else
        {
            throw new InvalidOperationException("The domino cannot be played on the train.");
        }
    }

    public override string ToString()
    {
        string trainString = "Train: ";
        foreach (Domino domino in dominos)
        {
            trainString += domino + " ";
        }
        return trainString.Trim();
    }
}

public class Domino
{
    public int Side1Value { get; }
    public int Side2Value { get; private set; }

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
}

