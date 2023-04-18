using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHandDeckManager: MonoBehaviour
{
    public List<int> hand = new List<int>();
    public List<int> deck = new List<int>();
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 40; i++){
            deck.Add(i);
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
