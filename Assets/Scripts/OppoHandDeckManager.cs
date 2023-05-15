using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Mirror;
using UnityEngine.UI;

public class OppoHandDeckManager: MonoBehaviour
{
    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    public List<int> hand = new List<int>();
    public List<int> deck = new List<int>();
    public List<int> field = new List<int>();

    public List<Sprite> imageRefs = new List<Sprite>();


    //creates 5 cards in the deck (visual)
    public GameObject cardInDeck;
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    //creates 10 cards in the hand. They will always be present, just turned off if 
    //the card is not in play (when game starts, there will be 5 active cards and 5 unactive cards)
    //When a card is drawn, the next unactive card is turned on. The hand is a list of integers (their ids).
    public GameObject cardInHand1;
    public GameObject cardInHand2;
    public GameObject cardInHand3;
    public GameObject cardInHand4;
    public GameObject cardInHand5;
    public GameObject cardInHand6;
    public GameObject cardInHand7;
    public GameObject cardInHand8;
    public GameObject cardInHand9;
    public GameObject cardInHand10;

    //creates the 5 field cards. They will always be present, and will display if a card is added
    //to the field. The field is a list of integers (their ids)
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

    public Image imageSpritef1;
    public Image imageSpritef2;
    public Image imageSpritef3;
    public Image imageSpritef4;
    public Image imageSpritef5;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start()
    {
        initiateImage();
    }

    // Update is called once per frame

    void updateOppDeckHunterUI() {
        if (GameManagerScript.instance.deckDuck.Count < 26){
            cardInDeck4.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count < 20){
            cardInDeck3.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count < 14){
            cardInDeck2.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count < 6){
            cardInDeck1.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count == 0){
            cardInDeck.SetActive(false);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 26){
            cardInDeck4.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 20){
            cardInDeck3.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 14){
            cardInDeck2.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count >= 6){
            cardInDeck1.SetActive(true);
        }
        if (GameManagerScript.instance.deckDuck.Count > 0){
            cardInDeck.SetActive(true);
        }
    }

    void updateOppDeckDuckUI() {
        if (GameManagerScript.instance.deckHunter.Count < 26){
            cardInDeck4.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count < 20){
            cardInDeck3.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count < 14){
            cardInDeck2.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count < 6){
            cardInDeck1.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count == 0){
            cardInDeck.SetActive(false);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 26){
            cardInDeck4.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 20){
            cardInDeck3.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 14){
            cardInDeck2.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count >= 6){
            cardInDeck1.SetActive(true);
        }
        if (GameManagerScript.instance.deckHunter.Count > 0){
            cardInDeck.SetActive(true);
        }
    }

    void updateOppHandHunterUI(){
        if (GameManagerScript.instance.handDuck.Count < 1){
            cardInHand1.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 2){
            cardInHand2.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 3){
            cardInHand3.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 4){
            cardInHand4.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 5){
            cardInHand5.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 6){
            cardInHand6.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 7){
            cardInHand7.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 8){
            cardInHand8.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 9){
            cardInHand9.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count < 10){
            cardInHand10.SetActive(false);
        }
        if (GameManagerScript.instance.handDuck.Count >= 1){
            cardInHand1.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 2){
            cardInHand2.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 3){
            cardInHand3.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 4){
            cardInHand4.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 5){
            cardInHand5.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 6){
            cardInHand6.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 7){
            cardInHand7.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 8){
            cardInHand8.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count >= 9){
            cardInHand9.SetActive(true);
        }
        if (GameManagerScript.instance.handDuck.Count == 10){
            cardInHand10.SetActive(true);
        }
    }

    void updateOppHandDuckUI(){
        if (GameManagerScript.instance.handHunter.Count < 1){
            cardInHand1.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 2){
            cardInHand2.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 3){
            cardInHand3.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 4){
            cardInHand4.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 5){
            cardInHand5.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 6){
            cardInHand6.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 7){
            cardInHand7.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 8){
            cardInHand8.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 9){
            cardInHand9.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count < 10){
            cardInHand10.SetActive(false);
        }
        if (GameManagerScript.instance.handHunter.Count >= 1){
            cardInHand1.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 2){
            cardInHand2.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 3){
            cardInHand3.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 4){
            cardInHand4.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 5){
            cardInHand5.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 6){
            cardInHand6.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 7){
            cardInHand7.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 8){
            cardInHand8.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count >= 9){
            cardInHand9.SetActive(true);
        }
        if (GameManagerScript.instance.handHunter.Count == 10){
            cardInHand10.SetActive(true);
        }
    }

    void updateOppFieldAddingHunterUI(){
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
    }

    void updateOppFieldAddingDuckUI(){
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
            descriptionf2 = displayCardf2.description;
            
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
    }

    void Update()
    {
    
    }

    public void updateOppClientUI() {

        if (playerManager == null)
        {
            Debug.Log("No playerManager attached to this script");
            return;
        }

        if (playerManager.isDuck)
        {
            // Do something with the PlayerManager
        

            // update UI
            updateOppDeckDuckUI();
            updateOppHandDuckUI();
            updateOppFieldAddingDuckUI();
        }
        else
        {
            // Do something with the PlayerManager
            
            // update UI
            updateOppDeckHunterUI(); 
            updateOppHandHunterUI();
            updateOppFieldAddingHunterUI();
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

   


}
