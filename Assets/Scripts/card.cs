using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]

public class Card
{
    public int id, cost;
    public int? health, attack;
    public string cardName, description;
    public bool character;

    public Card(int id, bool character, int cost, int? health, int? attack, string cardName, string description)
    {
        this.id = id;
        this.character = character;
        this.cost = cost;
        this.health = health;
        this.attack = attack;
        this.cardName = cardName;
        this.description = description;
    }

}   