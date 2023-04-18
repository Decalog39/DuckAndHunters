using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour
{

    public Card card;
    public TextMeshProUGUI cardName, cost, attack, health;

    private void awake() {
        Initialize(card);
    }
    
    private void Start() {
    }

    public void Initialize(Card card) {
        cardName.text = card.cardName;
        cost.text = card.cost.ToString();
        attack.text = card.attack.ToString();
        health.text = card.health.ToString();
    }

    private void Update() {
        /*cardName.text = card.cardName;
        cost.text = card.cost.ToString();
        attack.text = card.attack.ToString();
        health.text = card.health.ToString();*/
    }

}
