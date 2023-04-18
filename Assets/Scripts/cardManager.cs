using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager{
    public static List<Card> cardlist = new List<Card>();
    
    public CardManager()
    {
        cardlist.Add(new CharCard(0, 0, 0, 0, null, null));
        cardlist.Add(new CharCard(1, 0, 0, 0, null, null));
        cardlist.Add(new CharCard(2, 0, 0, 0, null, null));
        cardlist.Add(new CharCard(3, 0, 0, 0, null, null));
        cardlist.Add(new CharCard(4, 0, 0, 0, null, null));
        cardlist.Add(new SpellCard(5, 0, null, null));
        cardlist.Add(new SpellCard(6, 0, null, null));
        cardlist.Add(new SpellCard(7, 0, null, null));
        cardlist.Add(new SpellCard(8, 0, null, null));
        cardlist.Add(new SpellCard(9, 0, null, null));
    }
}
