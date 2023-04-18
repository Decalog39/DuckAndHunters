using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHandDeckManager: MonoBehaviour
{
    public List<Card> hand = new List<Card>();
    public List<Card> deck = new List<Card>();
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 20; i++){
            deck.Add(new Card(i, true, "Card" + i, i%5, 3, 2, "NA"));
        }
        for (int i = 20; i < 40; i++){
            deck.Add(new Card(i, false, "Card" + i, i%5, null, null, "NA"));
        }
    }

    void Start()
    {
        System.Random rnd = new System.Random();
        for(int j = 0; j < 8; j++){
            int x = rnd.Next(0, deck.Count);
            hand.Add(deck[x]);
            deck.RemoveAt(x);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
