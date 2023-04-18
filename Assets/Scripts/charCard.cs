using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCard
{
    public int id;
    public int cost;
    public String cardName;
    public String description;
    public int hp;
    public int attack;


    public Card(int id, int hp, int attack, int cost, String cardName, String description){
        this.cost = cost;
        this.hp = hp;
        this.attack = attack;
        this.id = id;
        this.cardName = cardName;
        this.description = description;
    }
}
