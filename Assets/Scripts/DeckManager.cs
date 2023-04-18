using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>(30);
    
    void Start()
    {
        for (int i = 0; i < 15; i++){
            deck[i] = (new CharCard(i, 0, 0, 0, null, null));
            deck[15 + i] = (new SpellCard(15 + i, 0, null, null));
        }
    }
}
