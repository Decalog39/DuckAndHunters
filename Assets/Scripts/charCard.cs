using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.serializable]
public class CharCard : Card
{
    public int health, attack, cost;
    public string cardName;
    public string description;

    public CharCard(int id, int health, int attack, int cost, string cardName, string description) : base(id)
    {
        this.health = health;
        this.attack = attack;
        this.cardName = cardName;
        this.description = description;
        this.cost = cost;
    }
}


