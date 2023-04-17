using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour {
    public static List<Cards> cardlist = new List<Cards>();
    
    void Awake() {
        cardlist.Add(new Cards(0, 0, 0, 0, "None", "None"));
    }
}
