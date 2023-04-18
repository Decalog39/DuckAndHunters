using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newCard", menuName = "SpellCard")]
public class SpellCard : Card
{
    public string cardName;
    public string description;
    public int cost;

    public SpellCard(int id, int cost, string cardName, string description) : base(id)
    {
        this.cardName = cardName;
        this.description = description;
        this.cost = cost;
    }
}
