using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour {
    public static list<Card> cardlist = new List<Card>();
    
    void Awake() {
        cardlist.add(new Card(0, "None", 0, 0 "None"));
    }
}
