using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]

public class Card
{
    // public int id, cost;
    // public int? health, attack;
    // public string cardName, description;
    // public bool character;

    // public Card(int id, bool character, string cardName, int cost, int? health, int? attack, string description)
    // {
    //     this.id = id;
    //     this.character = character;
    //     this.cost = cost;
    //     this.health = health;
    //     this.attack = attack;
    //     this.cardName = cardName;
    //     this.description = description;
    // }

    public int id, cost;
    public int health, attack;
    public string cardName, description;
    public bool character;
    public int damageDealtBySpell;


    public Card(int id, bool character, string cardName, int cost, int attack, int health, string description, int damageDealtBySpell)
    {
        this.id = id;
        this.character = character;
        this.cardName = cardName;
        this.cost = cost;
        this.attack = attack;
        this.health = health;
        this.description = description;
        this.damageDealtBySpell = damageDealtBySpell;
    }
}