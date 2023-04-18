using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    
    public int displayID;

    public int id, cost;
    public string cardName;
    public int? health;
    public int? attack;
    //public string description;
    public bool character;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI attackText;
    //public TextMeshProUGUI descriptionText;

    void Start() {
        displayCard[0] = CardDatabase.cardList[displayID];
    }

    void Update() {
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        cost = displayCard[0].cost;
        attack = displayCard[0].attack;
        health = displayCard[0].health;
        //description = displayCard[0].description;

        nameText.text = " " + cardName;
        costText.text = " " + cost;
        attackText.text = " " + attack;
        healthText.text = " " + health;
        //descriptionText.text = " " + description;

    }

}
