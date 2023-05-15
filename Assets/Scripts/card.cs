using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]

public class Card : ICloneable
{
    public int id, cost;
    public int? health, attack;
    public string cardName, description;
    public bool character;


    public Card() {
        id = 0;
        cost = 0;
        health = 0;
        attack = 0;
        cardName = "null";
        description = "null";
        character = true;
    }
    public Card(int id, bool character, string cardName, int cost, int? health, int? attack, string description)
    {
        this.id = id;
        this.character = character;
        this.cost = cost;
        this.health = health;
        this.attack = attack;
        this.cardName = cardName;
        this.description = description;
    }

    public override string ToString()
    {

        string type = character ? "Character" : "Spell";
        string stats = $"{(health.HasValue ? $"Health: {health}, " : "")}{(attack.HasValue ? $"Attack: {attack}" : "")}";
        return $"{cardName} ({type}) - Cost: {cost}, {stats}, Description: {description}";
    }

    public object Clone() {
        var clonedCard = new Card (id, character, cardName, cost, health, attack, description);
        return clonedCard;
    }

}   