using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCard : Card
{
    public int hp;
    public int attack;
    public string cardName;
    public string description;
    public int cost;

    public CharCard(int id, int hp, int attack, int cost, string cardName, string description) : base(id)
    {
        this.hp = hp;
        this.attack = attack;
        this.cardName = cardName;
        this.description = description;
        this.cost = cost;
    }
}
