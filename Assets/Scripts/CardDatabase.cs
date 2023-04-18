using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour {
    public static List<Card> cardlist = new List<Card>();
    
    void Awake() {
        cardlist.Add(new Card(0, 0, 0, 0, "None", "None"));
    }
}
