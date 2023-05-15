using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Player {

    public int health, maxMana, currentMana;
    public int ID;
    public bool myTurn;

    public Player(int health, int maxMana, int currentMana, int ID) {
        this.health = health;
        this.maxMana = maxMana;
        this.currentMana = currentMana;
        this.ID = ID;
    }




}
