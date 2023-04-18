
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        //cardList.Add(new Card(0,true, "None", 0, 0, 0, "None"));

        //hunters
        // cardList.Add(new Card(1,true, "MasterHunter", 10, 6, 6, "This is a MasterHunter"));
        // cardList.Add(new Card(2,true, "Hunter", 9, 5, 5, "This is a Hunter"));
        // cardList.Add(new Card(3, true,"ApprenticeHunter", 8, 4, 4, "This is an ApprenticeHunter"));
        // cardList.Add(new Card(4,true, "Caddy", 7, 3, 3, "This is a Caddy"));
        // cardList.Add(new Card(5,true, "Nova Scotia Duck Tolling Retriever", 6, 2, 2, "This is a Nova Scotia Duck Tolling Retriever"));

        // //ducks
        // cardList.Add(new Card(6, true,"KingDuck", 10, 6, 6, "This is a KingDuck"));
        // cardList.Add(new Card(7, true,"CrownPrincessDuck", 9, 5, 5, "This is a CrownPrincessDuck"));
        // cardList.Add(new Card(8,true, "SoldierDuck", 8, 4, 4, "This is a SoldierDuck"));
        // cardList.Add(new Card(9,true, "Duck", 7, 3, 3, "This is a Duck"));
        // cardList.Add(new Card(10,true, "Egg", 6, 2, 2, "This is an Egg"));

        cardList.Add(new Card(0, true, "MasterHunter", 10, 6, 6, "This is a MasterHunter"));




    }

}
