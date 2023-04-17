using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int cost;
    public int hp;
    public int attack;
    public int id;
    public string cardName;
    public string description;

    public Cards(){

    }

    public Cards(int cost, int hp, int attack, int id, string cardName, string description){
        this.cost = cost;
        this.hp = hp;
        this.attack = attack;
        this.id = id;
        this.cardName = cardName;
        this.description = description;
    }
}
