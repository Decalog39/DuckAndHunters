using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    public int id;

    public Card(int id)
    {
        this.id = id;
    }
}   