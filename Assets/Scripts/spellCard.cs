using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCard
{
    public int id;
    public String cardName;
    public String description;
    public int cost;

    public Card(int id, int cost, String cardName, String description){
        this.cost = cost;
        this.id = id;
        this.cardName = cardName;
        this.description = description;
    }
}
