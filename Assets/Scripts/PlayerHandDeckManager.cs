using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Mirror;
using UnityEngine.UI;

public class PlayerHandDeckManager : MonoBehaviour
{

    //same as OppoHandDeckManager, but for own GameManagerScript.instance.deckDuck. Check comments there. 

    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    public List<int> hand = new List<int>();
    public List<int> deck = new List<int>();
    public List<int> field = new List<int>();

    public GameObject cardInDeck;
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject cardinHand1;
    public int id1, cost1;
    public string cardName1;
    public int? health1;
    public int? attack1;
    public string description1;
    public bool character1;
    public Sprite image1;

    public TextMeshProUGUI nameText1;
    public TextMeshProUGUI costText1;
    public TextMeshProUGUI healthText1;
    public TextMeshProUGUI attackText1;
    public TextMeshProUGUI descriptionText1;

    public GameObject cardinHand2;
    public int id2, cost2;
    public string cardName2;
    public int? health2;
    public int? attack2;
    public string description2;
    public bool character2;
    public Sprite image2;


    public TextMeshProUGUI nameText2;
    public TextMeshProUGUI costText2;
    public TextMeshProUGUI healthText2;
    public TextMeshProUGUI attackText2;
    public TextMeshProUGUI descriptionText2;

    public GameObject cardinHand3;
    public int id3, cost3;
    public string cardName3;
    public int? health3;
    public int? attack3;
    public string description3;
    public bool character3;
    public Sprite image3;


    public TextMeshProUGUI nameText3;
    public TextMeshProUGUI costText3;
    public TextMeshProUGUI healthText3;
    public TextMeshProUGUI attackText3;
    public TextMeshProUGUI descriptionText3;

    public GameObject cardinHand4;
    public int id4, cost4;
    public string cardName4;
    public int? health4;
    public int? attack4;
    public string description4;
    public bool character4;
    public Sprite image4;


    public TextMeshProUGUI nameText4;
    public TextMeshProUGUI costText4;
    public TextMeshProUGUI healthText4;
    public TextMeshProUGUI attackText4;
    public TextMeshProUGUI descriptionText4;

    public GameObject cardinHand5;
    public int id5, cost5;
    public string cardName5;
    public int? health5;
    public int? attack5;
    public string description5;
    public bool character5;
    public Sprite image5;


    public TextMeshProUGUI nameText5;
    public TextMeshProUGUI costText5;
    public TextMeshProUGUI healthText5;
    public TextMeshProUGUI attackText5;
    public TextMeshProUGUI descriptionText5;

    public GameObject cardinHand6;
    public int id6, cost6;
    public string cardName6;
    public int? health6;
    public int? attack6;
    public string description6;
    public bool character6;
    public Sprite image6;

    public TextMeshProUGUI nameText6;
    public TextMeshProUGUI costText6;
    public TextMeshProUGUI healthText6;
    public TextMeshProUGUI attackText6;
    public TextMeshProUGUI descriptionText6;

    public GameObject cardinHand7;
    public int id7, cost7;
    public string cardName7;
    public int? health7;
    public int? attack7;
    public string description7;
    public bool character7;
    public Sprite image7;

    public TextMeshProUGUI nameText7;
    public TextMeshProUGUI costText7;
    public TextMeshProUGUI healthText7;
    public TextMeshProUGUI attackText7;
    public TextMeshProUGUI descriptionText7;

    public GameObject cardinHand8;
    public int id8, cost8;
    public string cardName8;
    public int? health8;
    public int? attack8;
    public string description8;
    public bool character8;
    public Sprite image8;

    public TextMeshProUGUI nameText8;
    public TextMeshProUGUI costText8;
    public TextMeshProUGUI healthText8;
    public TextMeshProUGUI attackText8;
    public TextMeshProUGUI descriptionText8;

    public GameObject cardinHand9;
    public int id9, cost9;
    public string cardName9;
    public int? health9;
    public int? attack9;
    public string description9;
    public bool character9;
    public Sprite image9;

    public TextMeshProUGUI nameText9;
    public TextMeshProUGUI costText9;
    public TextMeshProUGUI healthText9;
    public TextMeshProUGUI attackText9;
    public TextMeshProUGUI descriptionText9;

    public GameObject cardinHand10;
    public int id10, cost10;
    public string cardName10;
    public int? health10;
    public int? attack10;
    public string description10;
    public bool character10;
    public Sprite image10;


    public TextMeshProUGUI nameText10;
    public TextMeshProUGUI costText10;
    public TextMeshProUGUI healthText10;
    public TextMeshProUGUI attackText10;
    public TextMeshProUGUI descriptionText10;


    public Card displayCard1;
    public Card displayCard2;
    public Card displayCard3;
    public Card displayCard4;
    public Card displayCard5;
    public Card displayCard6;
    public Card displayCard7;
    public Card displayCard8;
    public Card displayCard9;
    public Card displayCard10;


    public GameObject fieldCard1;
    public int idf1, costf1;
    public string cardNamef1;
    public int? healthf1;
    public int? attackf1;
    public string descriptionf1;
    public bool characterf1;
    public Sprite imagef1;


    public TextMeshProUGUI nameTextf1;
    public TextMeshProUGUI costTextf1;
    public TextMeshProUGUI healthTextf1;
    public TextMeshProUGUI attackTextf1;
    public TextMeshProUGUI descriptionTextf1;

    public GameObject fieldCard2;
    public int idf2, costf2;
    public string cardNamef2;
    public int? healthf2;
    public int? attackf2;
    public string descriptionf2;
    public bool characterf2;
    public Sprite imagef2;

    public TextMeshProUGUI nameTextf2;
    public TextMeshProUGUI costTextf2;
    public TextMeshProUGUI healthTextf2;
    public TextMeshProUGUI attackTextf2;
    public TextMeshProUGUI descriptionTextf2;

    public GameObject fieldCard3;
    public int idf3, costf3;
    public string cardNamef3;
    public int? healthf3;
    public int? attackf3;
    public string descriptionf3;
    public bool characterf3;
    public Sprite imagef3;

    public TextMeshProUGUI nameTextf3;
    public TextMeshProUGUI costTextf3;
    public TextMeshProUGUI healthTextf3;
    public TextMeshProUGUI attackTextf3;
    public TextMeshProUGUI descriptionTextf3;

    public GameObject fieldCard4;
    public int idf4, costf4;
    public string cardNamef4;
    public int? healthf4;
    public int? attackf4;
    public string descriptionf4;
    public bool characterf4;
    public Sprite imagef4;

    public TextMeshProUGUI nameTextf4;
    public TextMeshProUGUI costTextf4;
    public TextMeshProUGUI healthTextf4;
    public TextMeshProUGUI attackTextf4;
    public TextMeshProUGUI descriptionTextf4;

    public GameObject fieldCard5;
    public int idf5, costf5;
    public string cardNamef5;
    public int? healthf5;
    public int? attackf5;
    public string descriptionf5;
    public bool characterf5;
    public Sprite imagef5;

    public TextMeshProUGUI nameTextf5;
    public TextMeshProUGUI costTextf5;
    public TextMeshProUGUI healthTextf5;
    public TextMeshProUGUI attackTextf5;
    public TextMeshProUGUI descriptionTextf5;

    public Card displayCardf1;
    public Card displayCardf2;
    public Card displayCardf3;
    public Card displayCardf4;
    public Card displayCardf5;

    public Image imageSprite1;
    public Image imageSprite2;
    public Image imageSprite3;
    public Image imageSprite4;
    public Image imageSprite5;
    public Image imageSprite6;
    public Image imageSprite7;
    public Image imageSprite8;
    public Image imageSprite9;
    public Image imageSprite10;
    public Image imageSpritef1;
    public Image imageSpritef2;
    public Image imageSpritef3;
    public Image imageSpritef4;
    public Image imageSpritef5;
    public Image imageSpriteS;

    public GameObject spellCard;
    public int idS, costS;
    public string cardNameS;
    public int? healthS;
    public int? attackS;
    public string descriptionS;
    public bool characterS;

    public Card displayCardS;
    public Sprite imageS;

    public TextMeshProUGUI nameTextS;
    public TextMeshProUGUI costTextS;
    public TextMeshProUGUI healthTextS;
    public TextMeshProUGUI attackTextS;
    public TextMeshProUGUI descriptionTextS;

    public List<Sprite> imageRefs = new List<Sprite>();
    

    //[ClientRPC]
    void updateDeckDuckUI() {
        if (GameManagerScript.instance.deckDuck.Count < 26) {
            cardInDeck4.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count < 20) {
            cardInDeck3.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count < 14) {
            cardInDeck2.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count < 6) {
            cardInDeck1.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count == 0) {
            cardInDeck.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 26) {
            cardInDeck4.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 20) {
            cardInDeck3.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 14) {
            cardInDeck2.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 6) {
            cardInDeck1.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count > 0) {
            cardInDeck.SetActive(true);
        }
    }

    void updateDeckHunterUI() {
        if (GameManagerScript.instance.deckHunter.Count < 26) {
            cardInDeck4.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count < 20) {
            cardInDeck3.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count < 14) {
            cardInDeck2.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count < 6) {
            cardInDeck1.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count == 0) {
            cardInDeck.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 26) {
            cardInDeck4.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 20) {
            cardInDeck3.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 14) {
            cardInDeck2.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 6) {
            cardInDeck1.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count > 0) {
            cardInDeck.SetActive(true);
        }
    }

    //[ClientRPC]
    void updateHandDuckUI() {
        if (GameManagerScript.instance.handDuck.Count < 1) {
            cardinHand1.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 2) {
            cardinHand2.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 3) {
            cardinHand3.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 4) {
            cardinHand4.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 5) {
            cardinHand5.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 6) {
            cardinHand6.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 7) {
            cardinHand7.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 8) {
            cardinHand8.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 9) {
            cardinHand9.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 10) {
            cardinHand10.SetActive(false);
        }

        if (GameManagerScript.instance.handDuck.Count >= 1) {
            cardinHand1.SetActive(true);
            displayCard1 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[0]];
            id1 = displayCard1.id;
            cardName1 = displayCard1.cardName;
            cost1 = displayCard1.cost;
            attack1 = displayCard1.attack;
            health1 = displayCard1.health;
            description1 = displayCard1.description;
            nameText1.text = " " + cardName1;
            costText1.text = " " + cost1;

            imageSprite1.sprite = imageRefs[id1];
        

            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[0]].character) {
                attackText1.text = " ";
                healthText1.text = " ";
            }
            else {
                attackText1.text = " " + attack1;
                healthText1.text = " " + health1;
            }
            descriptionText1.text = " " + description1;
        }
        if (GameManagerScript.instance.handDuck.Count >= 2) {
            cardinHand2.SetActive(true);
            displayCard2 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[1]];
            id2 = displayCard2.id;
            cardName2 = displayCard2.cardName;
            cost2 = displayCard2.cost;
            attack2 = displayCard2.attack;
            health2 = displayCard2.health;
            description2 = displayCard2.description;

            imageSprite2.sprite = imageRefs[id2];


            nameText2.text = " " + cardName2;
            costText2.text = " " + cost2;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[1]].character) {
                attackText2.text = " ";
                healthText2.text = " ";
            }
            else {
                attackText2.text = " " + attack2;
                healthText2.text = " " + health2;
            }
            descriptionText2.text = " " + description2;
        }
        if (GameManagerScript.instance.handDuck.Count >= 3) {
            cardinHand3.SetActive(true);
            displayCard3 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[2]];
            id3 = displayCard3.id;
            cardName3 = displayCard3.cardName;
            cost3 = displayCard3.cost;
            attack3 = displayCard3.attack;
            health3 = displayCard3.health;
            description3 = displayCard3.description;

            imageSprite3.sprite = imageRefs[id3];


            nameText3.text = " " + cardName3;
            costText3.text = " " + cost3;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[2]].character) {
                attackText3.text = " ";
                healthText3.text = " ";
            }
            else {
                attackText3.text = " " + attack3;
                healthText3.text = " " + health3;
            }
            descriptionText3.text = " " + description3;
        }
        if (GameManagerScript.instance.handDuck.Count >= 4) {
            cardinHand4.SetActive(true);
            displayCard4 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[3]];
            id4 = displayCard4.id;
            cardName4 = displayCard4.cardName;
            cost4 = displayCard4.cost;
            attack4 = displayCard4.attack;
            health4 = displayCard4.health;
            description4 = displayCard4.description;

            imageSprite4.sprite = imageRefs[id4];


            nameText4.text = " " + cardName4;
            costText4.text = " " + cost4;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[3]].character) {
                attackText4.text = " ";
                healthText4.text = " ";
            }
            else {
                attackText4.text = " " + attack4;
                healthText4.text = " " + health4;
            }
            descriptionText4.text = " " + description4;
        }
        if (GameManagerScript.instance.handDuck.Count >= 5) {
            cardinHand5.SetActive(true);
            displayCard5 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[4]];
            id5 = displayCard5.id;
            cardName5 = displayCard5.cardName;
            cost5 = displayCard5.cost;
            attack5 = displayCard5.attack;
            health5 = displayCard5.health;
            description5 = displayCard5.description;

            imageSprite5.sprite = imageRefs[id5];

            nameText5.text = " " + cardName5;
            costText5.text = " " + cost5;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[4]].character) {
                attackText5.text = " ";
                healthText5.text = " ";
            }
            else {
                attackText5.text = " " + attack5;
                healthText5.text = " " + health5;
            }
            descriptionText5.text = " " + description5;
        }
        if (GameManagerScript.instance.handDuck.Count >= 6) {
            cardinHand6.SetActive(true);
            displayCard6 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[5]];
            id6 = displayCard6.id;
            cardName6 = displayCard6.cardName;
            cost6 = displayCard6.cost;
            attack6 = displayCard6.attack;
            health6 = displayCard6.health;
            description6 = displayCard6.description;

            imageSprite6.sprite = imageRefs[id6];


            nameText6.text = " " + cardName6;
            costText6.text = " " + cost6;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[5]].character) {
                attackText6.text = " ";
                healthText6.text = " ";
            }
            else {
                attackText6.text = " " + attack6;
                healthText6.text = " " + health6;
            }
            descriptionText6.text = " " + description6;
        }
        if (GameManagerScript.instance.handDuck.Count >= 7) {
            cardinHand7.SetActive(true);
            displayCard7 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[6]];
            id7 = displayCard7.id;
            cardName7 = displayCard7.cardName;
            cost7 = displayCard7.cost;
            attack7 = displayCard7.attack;
            health7 = displayCard7.health;
            description7 = displayCard7.description;

            imageSprite7.sprite = imageRefs[id7];


            nameText7.text = " " + cardName7;
            costText7.text = " " + cost7;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[6]].character) {
                attackText7.text = " ";
                healthText7.text = " ";
            }
            else {
                attackText7.text = " " + attack7;
                healthText7.text = " " + health7;
            }
            descriptionText7.text = " " + description7;
        }
        if (GameManagerScript.instance.handDuck.Count >= 8) {
            cardinHand8.SetActive(true);
            displayCard8 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[7]];
            id8 = displayCard8.id;
            cardName8 = displayCard8.cardName;
            cost8 = displayCard8.cost;
            attack8 = displayCard8.attack;
            health8 = displayCard8.health;
            description8 = displayCard8.description;

            imageSprite8.sprite = imageRefs[id8];


            nameText8.text = " " + cardName8;
            costText8.text = " " + cost8;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[7]].character) {
                attackText8.text = " ";
                healthText8.text = " ";
            }
            else {
                attackText8.text = " " + attack8;
                healthText8.text = " " + health8;
            }
            descriptionText8.text = " " + description8;
        }
        if (GameManagerScript.instance.handDuck.Count >= 9) {
            cardinHand9.SetActive(true);
            displayCard9 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[8]];
            id9 = displayCard9.id;
            cardName9 = displayCard9.cardName;
            cost9 = displayCard9.cost;
            attack9 = displayCard9.attack;
            health9 = displayCard9.health;
            description9 = displayCard9.description;

            imageSprite9.sprite = imageRefs[id9];


            nameText9.text = " " + cardName9;
            costText9.text = " " + cost9;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[8]].character) {
                attackText9.text = " ";
                healthText9.text = " ";
            }
            else {
                attackText9.text = " " + attack9;
                healthText9.text = " " + health9;
            }
            descriptionText9.text = " " + description9;
        }
        if (GameManagerScript.instance.handDuck.Count == 10) {
            cardinHand10.SetActive(true);
            displayCard10 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[9]];
            id10 = displayCard10.id;
            cardName10 = displayCard10.cardName;
            cost10 = displayCard10.cost;
            attack10 = displayCard10.attack;
            health10 = displayCard10.health;
            description10 = displayCard10.description;

            imageSprite10.sprite = imageRefs[id10];


            nameText10.text = " " + cardName10;
            costText10.text = " " + cost10;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[9]].character) {
                attackText10.text = " ";
                healthText10.text = " ";
            }
            else {
                attackText10.text = " " + attack10;
                healthText10.text = " " + health10;
            }
            descriptionText10.text = " " + description10;
        }
    }

    void updateHandHunterUI() {
        if (GameManagerScript.instance.handHunter.Count < 1) {
            cardinHand1.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 2) {
            cardinHand2.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 3) {
            cardinHand3.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 4) {
            cardinHand4.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 5) {
            cardinHand5.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 6) {
            cardinHand6.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 7) {
            cardinHand7.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 8) {
            cardinHand8.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 9) {
            cardinHand9.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 10) {
            cardinHand10.SetActive(false);
        }

        if (GameManagerScript.instance.handHunter.Count >= 1) {
            cardinHand1.SetActive(true);
            displayCard1 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[0]];
            id1 = displayCard1.id;
            cardName1 = displayCard1.cardName;
            cost1 = displayCard1.cost;
            attack1 = displayCard1.attack;
            health1 = displayCard1.health;
            description1 = displayCard1.description;
            nameText1.text = " " + cardName1;
            costText1.text = " " + cost1;

            imageSprite1.sprite = imageRefs[id1];


            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[0]].character) {
                attackText1.text = " ";
                healthText1.text = " ";
            }
            else {
                attackText1.text = " " + attack1;
                healthText1.text = " " + health1;    
            }
            descriptionText1.text = " " + description1;
        }
        if (GameManagerScript.instance.handHunter.Count >= 2) {
            cardinHand2.SetActive(true);
            displayCard2 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[1]];
            id2 = displayCard2.id;
            cardName2 = displayCard2.cardName;
            cost2 = displayCard2.cost;
            attack2 = displayCard2.attack;
            health2 = displayCard2.health;
            description2 = displayCard2.description;

            imageSprite2.sprite = imageRefs[id2];

            nameText2.text = " " + cardName2;
            costText2.text = " " + cost2;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[1]].character) {
                attackText2.text = " ";
                healthText2.text = " ";
            }
            else {
                attackText2.text = " " + attack2;
                healthText2.text = " " + health2;
            }
            descriptionText2.text = " " + description2;
        }
        if (GameManagerScript.instance.handHunter.Count >= 3) {
            cardinHand3.SetActive(true);
            displayCard3 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[2]];
            id3 = displayCard3.id;
            cardName3 = displayCard3.cardName;
            cost3 = displayCard3.cost;
            attack3 = displayCard3.attack;
            health3 = displayCard3.health;
            description3 = displayCard3.description;

            imageSprite3.sprite = imageRefs[id3];

            nameText3.text = " " + cardName3;
            costText3.text = " " + cost3;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[2]].character) {
                attackText3.text = " ";
                healthText3.text = " ";
            }
            else {
                attackText3.text = " " + attack3;
                healthText3.text = " " + health3;
            }
            descriptionText3.text = " " + description3;
        }
        if (GameManagerScript.instance.handHunter.Count >= 4) {
            cardinHand4.SetActive(true);
            displayCard4 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[3]];
            id4 = displayCard4.id;
            cardName4 = displayCard4.cardName;
            cost4 = displayCard4.cost;
            attack4 = displayCard4.attack;
            health4 = displayCard4.health;
            description4 = displayCard4.description;

            imageSprite4.sprite = imageRefs[id4];


            nameText4.text = " " + cardName4;
            costText4.text = " " + cost4;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[3]].character) {
                attackText4.text = " ";
                healthText4.text = " ";
            }
            else {
                attackText4.text = " " + attack4;
                healthText4.text = " " + health4;
            }
            descriptionText4.text = " " + description4;
        }
        if (GameManagerScript.instance.handHunter.Count >= 5) {
            cardinHand5.SetActive(true);
            displayCard5 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[4]];
            id5 = displayCard5.id;
            cardName5 = displayCard5.cardName;
            cost5 = displayCard5.cost;
            attack5 = displayCard5.attack;
            health5 = displayCard5.health;
            description5 = displayCard5.description;

            imageSprite5.sprite = imageRefs[id5];


            nameText5.text = " " + cardName5;
            costText5.text = " " + cost5;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[4]].character) {
                attackText5.text = " ";
                healthText5.text = " ";
            }
            else {
                attackText5.text = " " + attack5;
                healthText5.text = " " + health5;
            }
            descriptionText5.text = " " + description5;
        }
        if (GameManagerScript.instance.handHunter.Count >= 6) {
            cardinHand6.SetActive(true);
            displayCard6 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[5]];
            id6 = displayCard6.id;
            cardName6 = displayCard6.cardName;
            cost6 = displayCard6.cost;
            attack6 = displayCard6.attack;
            health6 = displayCard6.health;
            description6 = displayCard6.description;

            imageSprite6.sprite = imageRefs[id6];


            nameText6.text = " " + cardName6;
            costText6.text = " " + cost6;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[5]].character) {
                attackText6.text = " ";
                healthText6.text = " ";
            }
            else {
                attackText6.text = " " + attack6;
                healthText6.text = " " + health6;
            }
            descriptionText6.text = " " + description6;
        }
        if (GameManagerScript.instance.handHunter.Count >= 7) {
            cardinHand7.SetActive(true);
            displayCard7 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[6]];
            id7 = displayCard7.id;
            cardName7 = displayCard7.cardName;
            cost7 = displayCard7.cost;
            attack7 = displayCard7.attack;
            health7 = displayCard7.health;
            description7 = displayCard7.description;

            imageSprite7.sprite = imageRefs[id7];


            nameText7.text = " " + cardName7;
            costText7.text = " " + cost7;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[6]].character) {
                attackText7.text = " ";
                healthText7.text = " ";
            }
            else {
                attackText7.text = " " + attack7;
                healthText7.text = " " + health7;
            }
            descriptionText7.text = " " + description7;
        }
        if (GameManagerScript.instance.handHunter.Count >= 8) {
            cardinHand8.SetActive(true);
            displayCard8 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[7]];
            id8 = displayCard8.id;
            cardName8 = displayCard8.cardName;
            cost8 = displayCard8.cost;
            attack8 = displayCard8.attack;
            health8 = displayCard8.health;
            description8 = displayCard8.description;

            imageSprite8.sprite = imageRefs[id8];


            nameText8.text = " " + cardName8;
            costText8.text = " " + cost8;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[7]].character) {
                attackText8.text = " ";
                healthText8.text = " ";
            }
            else {
                attackText8.text = " " + attack8;
                healthText8.text = " " + health8;
            }
            descriptionText8.text = " " + description8;
        }
        if (GameManagerScript.instance.handHunter.Count >= 9) {
            cardinHand9.SetActive(true);
            displayCard9 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[8]];
            id9 = displayCard9.id;
            cardName9 = displayCard9.cardName;
            cost9 = displayCard9.cost;
            attack9 = displayCard9.attack;
            health9 = displayCard9.health;
            description9 = displayCard9.description;

            imageSprite9.sprite = imageRefs[id9];


            nameText9.text = " " + cardName9;
            costText9.text = " " + cost9;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[8]].character) {
                attackText9.text = " ";
                healthText9.text = " ";
            }
            else {
                attackText9.text = " " + attack9;
                healthText9.text = " " + health9;
            }
            descriptionText9.text = " " + description9;
        }
        if (GameManagerScript.instance.handHunter.Count == 10) {
            cardinHand10.SetActive(true);
            displayCard10 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[9]];
            id10 = displayCard10.id;
            cardName10 = displayCard10.cardName;
            cost10 = displayCard10.cost;
            attack10 = displayCard10.attack;
            health10 = displayCard10.health;
            description10 = displayCard10.description;

            imageSprite10.sprite = imageRefs[id10];


            nameText10.text = " " + cardName10;
            costText10.text = " " + cost10;
            if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[9]].character) {
                attackText10.text = " ";
                healthText10.text = " ";
            }
            else {
                attackText10.text = " " + attack10;
                healthText10.text = " " + health10;
            }
            descriptionText10.text = " " + description10;
        }
    }

    //[ClientRPC]
    void updateFieldDuckUI() {
        if (GameManagerScript.instance.fieldDuck.Count >= 1) {
            fieldCard1.SetActive(true);
            displayCardf1 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]];
            idf1 = displayCardf1.id;
            cardNamef1 = displayCardf1.cardName;
            costf1 = displayCardf1.cost;
            attackf1 = displayCardf1.attack;
            healthf1 = displayCardf1.health;
            descriptionf1 = displayCardf1.description;
                        
            imageSpritef1.sprite = imageRefs[idf1];


            nameTextf1.text = " " + cardNamef1;
            costTextf1.text = " " + costf1;
            attackTextf1.text = " " + attackf1;
            healthTextf1.text = " " + healthf1;
            descriptionTextf1.text = " " + descriptionf1;
        }
        if (GameManagerScript.instance.fieldDuck.Count >= 2) {
            fieldCard2.SetActive(true);
            displayCardf2 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]];
            idf2 = displayCardf2.id;
            cardNamef2 = displayCardf2.cardName;
            costf2 = displayCardf2.cost;
            attackf2 = displayCardf2.attack;
            healthf2 = displayCardf2.health;
            descriptionf2 = displayCardf2.description;
            
            imageSpritef2.sprite = imageRefs[idf2];


            nameTextf2.text = " " + cardNamef2;
            costTextf2.text = " " + costf2;
            attackTextf2.text = " " + attackf2;
            healthTextf2.text = " " + healthf2;
            descriptionTextf2.text = " " + descriptionf2;
        }
        if (GameManagerScript.instance.fieldDuck.Count >= 3) {
            fieldCard3.SetActive(true);
            displayCardf3 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]];
            idf3 = displayCardf3.id;
            cardNamef3 = displayCardf3.cardName;
            costf3 = displayCardf3.cost;
            attackf3 = displayCardf3.attack;
            healthf3 = displayCardf3.health;
            descriptionf3 = displayCardf3.description;
            imageSpritef3.sprite = imageRefs[idf3];


            nameTextf3.text = " " + cardNamef3;
            costTextf3.text = " " + costf3;
            attackTextf3.text = " " + attackf3;
            healthTextf3.text = " " + healthf3;
            descriptionTextf3.text = " " + descriptionf3;
        }
        if (GameManagerScript.instance.fieldDuck.Count >= 4) {
            fieldCard4.SetActive(true);
            displayCardf4 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]];
            idf4 = displayCardf4.id;
            cardNamef4 = displayCardf4.cardName;
            costf4 = displayCardf4.cost;
            attackf4 = displayCardf4.attack;
            healthf4 = displayCardf4.health;
            descriptionf4 = displayCardf4.description;
            imageSpritef4.sprite = imageRefs[idf4];


            nameTextf4.text = " " + cardNamef4;
            costTextf4.text = " " + costf4;
            attackTextf4.text = " " + attackf4;
            healthTextf4.text = " " + healthf4;
            descriptionTextf4.text = " " + descriptionf4;
        }
        if (GameManagerScript.instance.fieldDuck.Count == 5) {
            fieldCard5.SetActive(true);
            displayCardf5 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]];
            idf5 = displayCardf5.id;
            cardNamef5 = displayCardf5.cardName;
            costf5 = displayCardf5.cost;
            attackf5 = displayCardf5.attack;
            healthf5 = displayCardf5.health;
            descriptionf5 = displayCardf5.description;
            imageSpritef5.sprite = imageRefs[idf5];


            nameTextf5.text = " " + cardNamef5;
            costTextf5.text = " " + costf5;
            attackTextf5.text = " " + attackf5;
            healthTextf5.text = " " + healthf5;
            descriptionTextf5.text = " " + descriptionf5;
        }

        if (GameManagerScript.instance.fieldDuck.Count < 1) {
            fieldCard1.SetActive(false);
        }
        if (GameManagerScript.instance.fieldDuck.Count < 2) {
            fieldCard2.SetActive(false);
        }
        if (GameManagerScript.instance.fieldDuck.Count < 3) {
            fieldCard3.SetActive(false);
        }
        if (GameManagerScript.instance.fieldDuck.Count < 4) {
            fieldCard4.SetActive(false);
        }
        if (GameManagerScript.instance.fieldDuck.Count < 5) {
            fieldCard5.SetActive(false);
        }

        // the following functions deactivate a fieldCard if it is not alive
        /*
        isAlive1Duck();
        isAlive2Duck();
        isAlive3Duck();
        isAlive4Duck();
        isAlive5Duck();*/
    }

    void updateFieldHunterUI() {
        if (GameManagerScript.instance.fieldHunter.Count >= 1) {
            fieldCard1.SetActive(true);
            displayCardf1 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]];
            idf1 = displayCardf1.id;
            cardNamef1 = displayCardf1.cardName;
            costf1 = displayCardf1.cost;
            attackf1 = displayCardf1.attack;
            healthf1 = displayCardf1.health;
            descriptionf1 = displayCardf1.description;
            imageSpritef1.sprite = imageRefs[idf1];


            nameTextf1.text = " " + cardNamef1;
            costTextf1.text = " " + costf1;
            attackTextf1.text = " " + attackf1;
            healthTextf1.text = " " + healthf1;
            descriptionTextf1.text = " " + descriptionf1;
        }
        if (GameManagerScript.instance.fieldHunter.Count >= 2) {
            fieldCard2.SetActive(true);
            displayCardf2 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]];
            idf2 = displayCardf2.id;
            cardNamef2 = displayCardf2.cardName;
            costf2 = displayCardf2.cost;
            attackf2 = displayCardf2.attack;
            healthf2 = displayCardf2.health;
            descriptionf1 = displayCardf1.description;
            imageSpritef2.sprite = imageRefs[idf2];


            nameTextf2.text = " " + cardNamef2;
            costTextf2.text = " " + costf2;
            attackTextf2.text = " " + attackf2;
            healthTextf2.text = " " + healthf2;
            descriptionTextf2.text = " " + descriptionf2;
        }
        if (GameManagerScript.instance.fieldHunter.Count >= 3) {
            fieldCard3.SetActive(true);
            displayCardf3 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]];
            idf3 = displayCardf3.id;
            cardNamef3 = displayCardf3.cardName;
            costf3 = displayCardf3.cost;
            attackf3 = displayCardf3.attack;
            healthf3 = displayCardf3.health;
            descriptionf3 = displayCardf3.description;
            imageSpritef3.sprite = imageRefs[idf3];

            nameTextf3.text = " " + cardNamef3;
            costTextf3.text = " " + costf3;
            attackTextf3.text = " " + attackf3;
            healthTextf3.text = " " + healthf3;
            descriptionTextf3.text = " " + descriptionf3;
        }
        if (GameManagerScript.instance.fieldHunter.Count >= 4) {
            fieldCard4.SetActive(true);
            displayCardf4 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]];
            idf4 = displayCardf4.id;
            cardNamef4 = displayCardf4.cardName;
            costf4 = displayCardf4.cost;
            attackf4 = displayCardf4.attack;
            healthf4 = displayCardf4.health;
            descriptionf4 = displayCardf4.description;
            imageSpritef4.sprite = imageRefs[idf4];


            nameTextf4.text = " " + cardNamef4;
            costTextf4.text = " " + costf4;
            attackTextf4.text = " " + attackf4;
            healthTextf4.text = " " + healthf4;
            descriptionTextf4.text = " " + descriptionf4;
        }
        if (GameManagerScript.instance.fieldHunter.Count == 5) {
            fieldCard5.SetActive(true);
            displayCardf5 = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]];
            idf5 = displayCardf5.id;
            cardNamef5 = displayCardf5.cardName;
            costf5 = displayCardf5.cost;
            attackf5 = displayCardf5.attack;
            healthf5 = displayCardf5.health;
            descriptionf5 = displayCardf5.description;
            imageSpritef5.sprite = imageRefs[idf5];


            nameTextf5.text = " " + cardNamef5;
            costTextf5.text = " " + costf5;
            attackTextf5.text = " " + attackf5;
            healthTextf5.text = " " + healthf5;
            descriptionTextf5.text = " " + descriptionf5;
        }

        if (GameManagerScript.instance.fieldHunter.Count < 1) {
            fieldCard1.SetActive(false);
        }
        if (GameManagerScript.instance.fieldHunter.Count < 2) {
            fieldCard2.SetActive(false);
        }
        if (GameManagerScript.instance.fieldHunter.Count < 3) {
            fieldCard3.SetActive(false);
        }
        if (GameManagerScript.instance.fieldHunter.Count < 4) {
            fieldCard4.SetActive(false);
        }
        if (GameManagerScript.instance.fieldHunter.Count < 5) {
            fieldCard5.SetActive(false);
        }

        // the following functions deactivate a fieldCard if it is not alive
        /*
        isAlive1Hunter();
        isAlive2Hunter();
        isAlive3Hunter();
        isAlive4Hunter();
        isAlive5Hunter();*/
    }

    bool tested = false;
    // Update is called once per frame
    void Update()
    {
        if (playerManager != null && playerManager.isDuck && !tested)
        {
            playerManager.CmdAddCard(100);
            tested = true;
        }
    }

    // called when SyncList cards is changed
    public void updateClientFieldUI() {

        if (playerManager == null)
        {
            return;
        }

        if (playerManager.isDuck)
        {
            // update UI
            updateFieldDuckUI();
        }
        else
        {
            // update UI
            updateFieldHunterUI();
        }
    }

    public void updateClientDeckUI()
    {
        if (playerManager == null)
        {
            Debug.Log("No playerManager attached to this script");
            return;
        }

        if (playerManager.isDuck)
        {


            // update UI
            updateDeckDuckUI();
        }
        else
        {

            // update UI
            updateDeckHunterUI();
        }
    }

    public void updateClientHandUI()
    {
        if (playerManager == null)
        {

            return;
        }

        if (playerManager.isDuck)
        {


            // update UI
            updateHandDuckUI();
        }
        else
        {


            // update UI
            updateHandHunterUI();
        }
    }

    public void updateClientActiveSpellUI()
    {
        if (GameManagerScript.instance.activeSpellId < 0)
        {
            spellCard.SetActive(false);
            return;
        }

        spellCard.SetActive(true);
        displayCardS = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.activeSpellId];
        idS = displayCardS.id;
        cardNameS = displayCardS.cardName;
        costS = displayCardS.cost;
        attackS = displayCardS.attack;
        healthS = displayCardS.health;
        descriptionS = displayCardS.description;
        imageSpriteS.sprite = imageRefs[idS];


        nameTextS.text = " " + cardNameS;
        costTextS.text = " " + costS;
        
        if (!GameManagerScript.instance.cardDatabase[GameManagerScript.instance.activeSpellId].character) {
                attackTextS.text = " ";
                healthTextS.text = " ";
            }
        else {
                attackTextS.text = " " + attackS;
                healthTextS.text = " " + healthS;
        }
        
        descriptionTextS.text = " " + descriptionS;
    }

    public void isAlive1Duck(){

        if (GameManagerScript.instance.fieldDuck.Count > 0 && displayCardf1.health != null && displayCardf1.health <= 0){
            
            int deadCard = displayCardf1.id;
            Debug.Log(deadCard);

            GameManagerScript.instance.printFieldDuckCards();
            playerManager.CmdRemoveDuckFieldCardAtIndex(0);
            
            if(deadCard == 18) {
                Debug.Log("18");
                playerManager.addFieldDuck(60);
            }
            else if(deadCard == 19) {
                Debug.Log("19");
                playerManager.addFieldDuck(61);
            }
        
        }
    }

    public void isAlive2Duck(){
        if (GameManagerScript.instance.fieldDuck.Count > 1 && displayCardf2.health != null && displayCardf2.health <= 0){
            
            int deadCard = displayCardf2.id;
            
            GameManagerScript.instance.printFieldDuckCards();
            playerManager.CmdRemoveDuckFieldCardAtIndex(1);

            if(deadCard == 18) {
                playerManager.addFieldDuck(60);
            }
            else if(deadCard == 19) {
                playerManager.addFieldDuck(61);
            }
        
        }
    }

    public void isAlive3Duck(){
        if (GameManagerScript.instance.fieldDuck.Count > 2 && displayCardf3.health != null && displayCardf3.health <= 0){
            
            int deadCard = displayCardf3.id;
            
            GameManagerScript.instance.printFieldDuckCards();
            playerManager.CmdRemoveDuckFieldCardAtIndex(2);
           
            if(deadCard == 18) {
                playerManager.addFieldDuck(60);
            }
            else if(deadCard == 19) {
                playerManager.addFieldDuck(61);
            }

        }
    }

    public void isAlive4Duck(){
        if (GameManagerScript.instance.fieldDuck.Count > 3 && displayCardf4.health != null && displayCardf4.health <= 0){
        
            int deadCard = displayCardf4.id;
            
            GameManagerScript.instance.printFieldDuckCards();
            playerManager.CmdRemoveDuckFieldCardAtIndex(3);

            if(deadCard == 18) {
                playerManager.addFieldDuck(60);
            }
            else if(deadCard == 19) {
                playerManager.addFieldDuck(61);
            }
    
        }
    }

    public void isAlive5Duck(){
        if (GameManagerScript.instance.fieldDuck.Count > 4 && displayCardf5.health != null && displayCardf5.health <= 0){
            
            int deadCard = displayCardf5.id;

            GameManagerScript.instance.printFieldDuckCards();
            playerManager.CmdRemoveDuckFieldCardAtIndex(4);

            if(deadCard == 18) {
                playerManager.addFieldDuck(60);
            }
            else if(deadCard == 19) {
                playerManager.addFieldDuck(61);
            }
            
        }
    }

    public void isAlive1Hunter(){
        if (GameManagerScript.instance.fieldHunter.Count > 0 && displayCardf1.health != null && displayCardf1.health <= 0){
            
            playerManager.CmdRemoveHunterFieldCardAtIndex(0);
        }
    }

    public void isAlive2Hunter(){
        if (GameManagerScript.instance.fieldHunter.Count > 1 && displayCardf2.health != null && displayCardf2.health <= 0){
            playerManager.CmdRemoveHunterFieldCardAtIndex(1);
        }
    }

    public void isAlive3Hunter(){
        if (GameManagerScript.instance.fieldHunter.Count > 2 && displayCardf3.health != null && displayCardf3.health <= 0){
            playerManager.CmdRemoveHunterFieldCardAtIndex(2);
        }
    }

    public void isAlive4Hunter(){
        if (GameManagerScript.instance.fieldHunter.Count > 3 && displayCardf4.health != null && displayCardf4.health <= 0){
            playerManager.CmdRemoveHunterFieldCardAtIndex(3);
        }
    }

    public void isAlive5Hunter(){
        if (GameManagerScript.instance.fieldHunter.Count > 4 && displayCardf5.health != null && displayCardf5.health <= 0){
            playerManager.CmdRemoveHunterFieldCardAtIndex(4);
        }
    }

    public void initiateImage(){
        imageRefs.Add(Resources.Load<Sprite>("Ducks/duckling"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/duckling"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/duckling"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/duckling"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/mallard"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/mallard"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/mallard"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/household_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/household_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/household_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/duck_king"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/queen_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/soldier_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/soldier_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/soldier_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/dk"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/flock"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/flock"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/brace"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/brace"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/donovan_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/donovan_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/waddle"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/rest"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/rest"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/fence"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/drown"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/bread"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/sleep_with_one_eye_open"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/quack"));
        //hunters
        imageRefs.Add(Resources.Load<Sprite>("Hunters/apprentice_hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/apprentice_hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/apprentice_hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/apprentice_hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/archer"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/archer"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/archer"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/master_hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/artemis"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/beagle"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/beagle"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/beagle"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/recreational_hunter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/duck_tolling_retriever"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/duck_tolling_retriever"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/trap_setter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/trap_setter"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/assassin"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/assassin"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/expedition"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/hunting_season"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/hunting_season"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/trap"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/camo"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/slingshot"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/gunpowder"));
        imageRefs.Add(Resources.Load<Sprite>("Hunters/swap"));
        
        imageRefs.Add(Resources.Load<Sprite>("Ducks/household_duck"));
        imageRefs.Add(Resources.Load<Sprite>("Ducks/household_duck"));
    }
    void Start(){
        initiateImage();
    }
}
