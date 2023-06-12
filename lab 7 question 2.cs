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
