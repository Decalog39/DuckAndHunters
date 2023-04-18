using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Card[] deck = new Card[30];
    
    void Start()
    {
        for (int i = 0; i < 15; i++){
            deck[i] = (new Card(i, true, 0, 0, 0, null, null));
            deck[15 + i] = (new Card(15 + i, false, 0, null, null, null, null));
        }
    }
}
