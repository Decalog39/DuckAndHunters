using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class GameManagerScript : NetworkBehaviour
{
    // cards SyncList only used for testing
    public readonly SyncList<int> cards = new SyncList<int>();

    public readonly SyncList<Card> cardDatabase = new SyncList<Card>();

    public readonly SyncList<int> handDuck = new SyncList<int>();
    public readonly SyncList<int> fieldDuck = new SyncList<int>();
    public readonly SyncList<int> deckDuck = new SyncList<int>();

    public readonly SyncList<int> handHunter = new SyncList<int>();
    public readonly SyncList<int> fieldHunter = new SyncList<int>();
    public readonly SyncList<int> deckHunter = new SyncList<int>();

    public static GameManagerScript instance;

    public List<GameObject> players = new List<GameObject>();
    public readonly SyncList<PlayerManager> playerManagers = new SyncList<PlayerManager>();

    public int nofPlayers = 0;

    /* PHASE and currentPhase not used */
    public enum PHASE { DUCK_DRAG, DUCK_ATTACK, DUCK_DEFEND, HUNTER_DRAG, HUNTER_ATTACK, HUNTER_DEFEND }

    [SyncVar]
    public bool camoBool;

    [SyncVar]
    public PHASE currentPhase = PHASE.DUCK_DRAG;

    [SyncVar]
    public int duckHealth = 30;
    
    [SyncVar]
    public int hunterHealth = 30;

    [SyncVar]
    public int duckCurrentMana = 1;

    [SyncVar]
    public int hunterCurrentMana = 1;

    [SyncVar]
    public int duckMaxMana = 1;

    [SyncVar]
    public int hunterMaxMana = 1;

    [SyncVar (hook = nameof(OnAttackPhaseChanged))]
    public bool isDuckAttackPhase = false;
    
    [SyncVar(hook = nameof(OnDefensePhaseChanged))]
    public bool isDuckDefensePhase = false;

    [SyncVar(hook = nameof(OnDragPhaseChanged))]
    public bool isDuckDragPhase = false;

    [SyncVar(hook = nameof(OnAttackPhaseChanged))]
    public bool isHunterAttackPhase = false;

    [SyncVar(hook = nameof(OnDefensePhaseChanged))]
    public bool isHunterDefensePhase = false;

    [SyncVar(hook = nameof(OnDragPhaseChanged))]
    public bool isHunterDragPhase = false;

    public readonly SyncList<bool> incomingAttacksFromDuck = new SyncList<bool>();
    public readonly SyncList<bool> incomingAttacksFromHunter = new SyncList<bool>();

    [SyncVar(hook = nameof(OnActiveSpellCardChanged))]
    public int activeSpellId = -1;

    [SyncVar]
    public bool firstIsDuck;




    // create an instance if it doesn't exist already, otherwise destroy - singleton pattern
    public void Awake()
    {
        duckHealth = 30;
    
        hunterHealth = 30;

        if (instance == null)
        {
            instance = this;
            
        }
        else if (instance != this)
        {
            
            Destroy(gameObject);
        } 
        camoBool = true;
    }

    public void Update(){
        if( nofPlayers == 2 && isServer){
            removeDeadDucks();
            removeDeadHunters();
        
        }

        if (duckHealth <= 0 || hunterHealth <= 0) {
            RpcGameOver();
        }

    }

    public override void OnStartServer()
    {
        

        //Initialize card database
        initDatabase();

        // Initialize the game state when the server starts
        InitCards();
        InitIncomingAttacks();

        // Initialize phases

        isDuckAttackPhase = false;
        isDuckDefensePhase = false;
        isDuckDragPhase = false;
        isHunterAttackPhase = false;
        isHunterDefensePhase = false;
        isHunterDragPhase = false;

        // Add a callback for the SyncList
        handDuck.Callback += OnHandDuckChanged;
        fieldDuck.Callback += OnFieldDuckChanged;
        deckDuck.Callback += OnDeckDuckChanged;
        handHunter.Callback += OnHandHunterChanged;
        fieldHunter.Callback += OnFieldHunterChanged;
        deckHunter.Callback += OnDeckHunterChanged;
        cardDatabase.Callback += OnCardDatabaseChanged;
        incomingAttacksFromDuck.Callback += OnIncomingAttacksChanged;
        incomingAttacksFromHunter.Callback += OnIncomingAttacksChanged;
    }



    public void OnDisable()
    {
        

        // remove the callbacks on disable
        handDuck.Callback -= OnHandDuckChanged;
        fieldDuck.Callback -= OnFieldDuckChanged;
        deckDuck.Callback -= OnDeckDuckChanged;
        handHunter.Callback -= OnHandHunterChanged;
        fieldHunter.Callback -= OnFieldHunterChanged;
        deckHunter.Callback -= OnDeckHunterChanged;
        cardDatabase.Callback -= OnCardDatabaseChanged;
        incomingAttacksFromDuck.Callback -= OnIncomingAttacksChanged;
        incomingAttacksFromHunter.Callback -= OnIncomingAttacksChanged;

    }


    /* --Remove Function-- */
    [Server]
    public void removeDeadDucks(){
        for(int i = 0; i < fieldDuck.Count; i++){
            if(cardDatabase[fieldDuck[i]].health != null && cardDatabase[fieldDuck[i]].health <= 0){
                
                int deadCard = fieldDuck[i];

                fieldDuck.RemoveAt(i);

                if(deadCard == 18) {
                GameManagerScript.instance.fieldDuck.Add(60);
                }
                else if(deadCard == 19) {
                GameManagerScript.instance.fieldDuck.Add(61);
                }
            }
        }
    }

    [Server]
    public void removeDeadHunters(){
        for(int i = 0; i < fieldHunter.Count; i++){
            if(cardDatabase[fieldHunter[i]].health != null && cardDatabase[fieldHunter[i]].health <= 0){
                fieldHunter.RemoveAt(i);
            }
        }
    }

    /* --CLIENT RPC-- */

    [ClientRpc]
    public void RpcGameOver() {
        SceneManager.LoadScene(sceneName:"EndofScene");
    }

    [ClientRpc]
    public void RpcDefensePhaseEntered() {
        GameObject DefensePhase = GameObject.Find("DefensePhase");

        DefensePhase defensePhase = DefensePhase.GetComponent<DefensePhase>();

        defensePhase.updateDefenseUI();
    }

    [ClientRpc]
    public void RpcUpdateText(){
        GameObject PlayerTurnManager = GameObject.Find("PlayerTurnManager");

        PlayerTurnManager PlayerTurnManagerScript = PlayerTurnManager.GetComponent<PlayerTurnManager>();

        PlayerTurnManagerScript.updateText();
    }

    [ClientRpc]
    public void RpcHandCardAdded(int cardIndex)
    {
        //Debug.Log($"ClientRPC received -> card at index = {cardIndex} was added");

        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientHandUI();
        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcHandCardRemoved(int cardIndex)
    {
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientHandUI();
        oppoHandDeckManager.updateOppClientUI();
    }


    [ClientRpc]
    public void RpcFieldCardAdded(int cardIndex)
    {
        //Debug.Log($"ClientRPC received -> card at index = {cardIndex} was added");

        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientFieldUI();
        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcFieldCardRemoved(int cardIndex)
    {
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientFieldUI();
        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcDeckCardAdded(int cardIndex)
    {
        //Debug.Log($"ClientRPC received -> card at index = {cardIndex} was added");

        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientDeckUI();
        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcDeckCardRemoved(int cardIndex)
    {
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientDeckUI();
        playerHandDeckManager.updateClientHandUI();
        playerHandDeckManager.updateClientFieldUI();
        oppoHandDeckManager.updateOppClientUI();
    }

        [ClientRpc]
    public void RpcCardDatabaseCardAdded(int index, Card newCard)
    {
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientHandUI();
        playerHandDeckManager.updateClientFieldUI();

        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcCardDatabaseCardSet(int index, Card newCard)
    {
        Debug.Log("Set occurs");
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientHandUI();
        playerHandDeckManager.updateClientFieldUI();

        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcCardDatabaseCardRemoved(int index, Card newCard)
    {
        Debug.Log("Remove occurs");
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientHandUI();
        playerHandDeckManager.updateClientFieldUI();

        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcCardDatabaseCardInserted(int index, Card newCard)
    {
        Debug.Log("Insert occurs");
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();
        OppoHandDeckManager oppoHandDeckManager = OppoDeck.GetComponent<OppoHandDeckManager>();

        playerHandDeckManager.updateClientHandUI();
        playerHandDeckManager.updateClientFieldUI();

        oppoHandDeckManager.updateOppClientUI();
    }

    [ClientRpc]
    public void RpcIncomingAttacksChanged() {
        GameObject DefensePhase = GameObject.Find("DefensePhase");

        DefensePhase defensePhase = DefensePhase.GetComponent<DefensePhase>();

        defensePhase.updateDefenseUI();
    }

    [ClientRpc]
    public void RpcUpdateActiveSpell()
    {
        GameObject Deck = GameObject.Find("Deck");
        GameObject OppoDeck = GameObject.Find("OppoDeck");

        PlayerHandDeckManager playerHandDeckManager = Deck.GetComponent<PlayerHandDeckManager>();

        playerHandDeckManager.updateClientActiveSpellUI();
    }

    /* --HELPER METHODS-- */

    // print cards (debugging)
    public void printCards()
    {
        for (int i = 0; i < instance.cards.Count; i++)
        {
            //Debug.Log($"Count = {instance.cards.Count} cards[{i}] = {cards[i]}");
        }
    }

    public void printFieldDuckCards()
    {
        for (int i = 0; i < instance.fieldDuck.Count; i++)
        {
            //Debug.Log($"Count = {instance.fieldDuck.Count} fieldDuck[{i}] = {fieldDuck[i]}");
        }
    }

    // Constant values for the initial game state (testing)
    private const int MAX_CARD_VALUE = 3;

    // populating the cards list with all indexes from card database
    //[Server]
    public void InitCards()
    {
        // Add cards to the SyncList
        for (int i = 1; i <= MAX_CARD_VALUE; i++)
        {
            cards.Add(i);
        }
        //Debug.Log($"CARDS AFTER INIT:");
        printCards();
    }

    public void InitIncomingAttacks()
    {
        for (int i = 0; i < 5; i++)
        {
            incomingAttacksFromDuck.Add(false);
            incomingAttacksFromHunter.Add(false);
        }
    }


     private void initDatabase() {
       //ducks
        cardDatabase.Add(new Card(0, true, "Duckling", 1, 1, 1, "This is a Duckling"));
        cardDatabase.Add(new Card(1, true, "Duckling", 1, 1, 1, "This is a Duckling"));
        cardDatabase.Add(new Card(2, true, "Duckling", 1, 1, 1, "This is a Duckling"));
        cardDatabase.Add(new Card(3, true, "Duckling", 1, 1, 1, "This is a Duckling"));
        cardDatabase.Add(new Card(4, true, "Mallard", 2, 2, 3, "Just a regular wild duck")); 
        cardDatabase.Add(new Card(5, true, "Mallard", 2, 2, 3, "Just a regular wild duck")); 
        cardDatabase.Add(new Card(6, true, "Mallard", 2, 2, 3, "Just a regular wild duck")); 
        cardDatabase.Add(new Card(7, true, "Duck", 2, 3, 2, "Just a regular household duck")); 
        cardDatabase.Add(new Card(8, true, "Duck", 2, 3, 2, "Just a regular household duck")); 
        cardDatabase.Add(new Card(9, true, "Duck", 2, 3, 2, "Just a regular household duck")); 
        
        cardDatabase.Add(new Card(10, true,"King Duck", 8, 10, 7, "Buffs all ducks and mallards on field by +1 attack."));
        cardDatabase.Add(new Card(11, true,"Crown Princess Duck", 6, 6, 7, "Random buff to random card on your field)"));

        cardDatabase.Add(new Card(12,true, "Soldier Duck", 4, 5, 4, "Adds +1 health to all regular ducks already on board."));
        cardDatabase.Add(new Card(13,true, "Soldier Duck", 4, 5, 4, "Adds +1 health to all regular ducks already on board."));
        cardDatabase.Add(new Card(14,true, "Soldier Duck", 4, 5, 4, "Adds +1 health to all regular ducks already on board."));

        cardDatabase.Add(new Card(15, true, "D**k", 5, 3, 6, "This is a D**k. It packs a punch.")); //higher stats

        cardDatabase.Add(new Card(16, true, "Flock", 5, 7, 5, "For each duck you control, add that much health to target card."));
        cardDatabase.Add(new Card(17, true, "Flock", 5, 7, 5, "For each duck you control, add that much health to target card"));

        cardDatabase.Add(new Card(18, true, "Brace", 4, 4, 4, "When Brace dies, spawn Duck partner")); //two ducks
        cardDatabase.Add(new Card(19, true, "Brace", 4, 4, 4, "When Brace dies, spawn Duck partner")); //two ducks

        cardDatabase.Add(new Card(20, true, "Donovan Duck", 4, 5, 5, "If Donovan defends and lives, he doesn't lose health"));
        cardDatabase.Add(new Card(21, true, "Donovan Duck", 4, 5, 5, "If Donovan defends and lives, he doesn't lose health"));

        cardDatabase.Add(new Card(22, false, "Waddle", 1, 0, 0, "Draw a card")); 
        cardDatabase.Add(new Card(23, false, "Rest", 2, 0, 0, "Target card gets +2 health")); 
        cardDatabase.Add(new Card(24, false, "Rest", 2, 0, 0, "Target card gets +2 health")); 
        cardDatabase.Add(new Card(25, false, "Fence", 4, 0, 0, "Enemy player's health is decreased by 2."));
        cardDatabase.Add(new Card(26, false, "Drown", 8, 0, 0, "Kill target character")); 
        cardDatabase.Add(new Card(27, false, "Bread", 5, 0, 0, "Health + 1 for all cards on your field"));
        cardDatabase.Add(new Card(28, false, "Sleep with one eye open", 9, 0, 0, "Adds 10 health to target card"));
        cardDatabase.Add(new Card(29, false, "QUACK", 4, 0, 0, "Randomly inc./ dec. target card's attack and health by between 0 and 5"));
        
        // hunters
        cardDatabase.Add(new Card(30, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice."));
        cardDatabase.Add(new Card(31, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice."));
        cardDatabase.Add(new Card(32, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice."));
        cardDatabase.Add(new Card(33, true, "Apprentice Hunter", 1, 1, 1, "This is an Apprentice."));
        cardDatabase.Add(new Card(34, true, "Hunter", 2, 2, 3, "This is a regular hunter.")); 
        cardDatabase.Add(new Card(35, true, "Hunter", 2, 2, 3, "This is a regular hunter.")); 
        cardDatabase.Add(new Card(36, true, "Hunter", 2, 2, 3, "This is a regular hunter.")); 
        cardDatabase.Add(new Card(37, true, "Archer", 2, 3, 2, "This is a regular Archer."));
        cardDatabase.Add(new Card(38, true, "Archer", 2, 3, 2, "This is a regular Archer."));
        cardDatabase.Add(new Card(39, true, "Archer", 2, 3, 2, "This is a regular Archer."));

        cardDatabase.Add(new Card(40, true, "Master Hunter", 8, 12, 11, "This is a Master Hunter. Super strong")); //no special effects
        cardDatabase.Add(new Card(41, true, "Artemis", 8, 3, 4, "Adds +1 attack and +1 health for each card on your field"));


        cardDatabase.Add(new Card(42, true, "Beagle", 4, 5, 4, "Adds +1 attack to all the regular hunters already on board.")); 
        cardDatabase.Add(new Card(43, true, "Beagle", 4, 5, 4, "Adds +1 attack to all the regular hunters already on board.")); 
        cardDatabase.Add(new Card(44, true, "Beagle", 4, 5, 4, "Adds +1 attack to all the regular hunters already on board.")); 

        cardDatabase.Add(new Card(45, true, "Recreational Hunter", 0, 3, 3, "Sacrifice 3 player health to play this card"));

        cardDatabase.Add(new Card(46, true, "Duck Tolling Retriever", 5, 7, 5, "For each enemy duck, add that much attack to target card."));
        cardDatabase.Add(new Card(47, true, "Duck Tolling Retriever", 5, 7, 5, "For each enemy duck, add that much attack to target card."));

        cardDatabase.Add(new Card(48, true, "Trap Setter", 4, 5, 4, "Removes 2 health from target card.")); 
        cardDatabase.Add(new Card(49, true, "Trap Setter", 4, 5, 4, "Removes 2 health from target card.")); 
            
        cardDatabase.Add(new Card(50, true, "Assassin", 4, 5, 5, "If it kills a card during attack, the damage enemy player takes is doubled."));
        cardDatabase.Add(new Card(51, true, "Assassin", 4, 5, 5, "If it kills a card during attack, the damage enemy player takes is doubled."));

        cardDatabase.Add(new Card(52, false, "Expedition", 1, 0, 0, "Draw a card"));
        cardDatabase.Add(new Card(53, false, "Hunting season", 2, 0, 0, "Target card gets +2 attack")); 
        cardDatabase.Add(new Card(54, false, "Hunting season", 2, 0, 0, "Target card gets +2 attack")); 
        cardDatabase.Add(new Card(55, false, "Trap", 4, 0, 0, "Halves the health and attack of target card (round down if odd)"));
        cardDatabase.Add(new Card(56, false, "Camouflage", 8, 0, 0, "You take no damage until your next turn"));
        cardDatabase.Add(new Card(57, false, "Slingshot", 5, 0, 0, "Attack +1 for all cards on your field"));
        cardDatabase.Add(new Card(58, false, "Gunpowder", 6, 0, 0, "Adds 5 attack to target card"));
        cardDatabase.Add(new Card(59, false, "Swap", 4, 0, 0, "Swap the health and attack stats of target card"));


        // duck tokens
        cardDatabase.Add(new Card(60, true, "Partner Duck", 2, 3, 2, "Just a regular household duck")); 
        cardDatabase.Add(new Card(61, true, "Partner Duck", 2, 3, 2, "Just a regular household duck")); 
    }


    /* --CALLBACKS-- */

    public void OnHandDuckChanged(SyncList<int>.Operation op, int index, int oldIndex, int newIndex)
    {
        //Debug.Log($"OHDC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        switch (op)
        {
            case SyncList<int>.Operation.OP_ADD: 
                RpcHandCardAdded(index);
                break;
            case SyncList<int>.Operation.OP_REMOVEAT:
                RpcHandCardRemoved(index);
                RpcUpdateText();
                break;
            case SyncList<int>.Operation.OP_INSERT:
                // index is where it was inserted into the list
                // newIndex is the new item
                break;
            case SyncList<int>.Operation.OP_SET:
                // index is of the item that was changed
                // oldIndex is the previous value for the item at the index
                // newIndex is the new value for the item at the index
                break;
            case SyncList<int>.Operation.OP_CLEAR:
                // list got cleared
                break;
        }        
        

    }

    public void OnFieldDuckChanged(SyncList<int>.Operation op, int index, int oldIndex, int newIndex)
    {
        //Debug.Log($"OFDC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        switch (op)
        {
            case SyncList<int>.Operation.OP_ADD:
                RpcFieldCardAdded(index);
                break;
            case SyncList<int>.Operation.OP_REMOVEAT:
                RpcFieldCardRemoved(index);
                break;
            case SyncList<int>.Operation.OP_INSERT:
                // index is where it was inserted into the list
                // newIndex is the new item
                break;
            case SyncList<int>.Operation.OP_SET:
                // index is of the item that was changed
                // oldIndex is the previous value for the item at the index
                // newIndex is the new value for the item at the index
                break;
            case SyncList<int>.Operation.OP_CLEAR:
                // list got cleared
                break;
        }
    }

    public void OnDeckDuckChanged(SyncList<int>.Operation op, int index, int oldIndex, int newIndex)
    {
        //Debug.Log($"ODDC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        switch (op)
        {
            case SyncList<int>.Operation.OP_ADD:
                RpcDeckCardAdded(index);
                break;
            case SyncList<int>.Operation.OP_REMOVEAT:
                RpcDeckCardRemoved(index);
                break;
            case SyncList<int>.Operation.OP_INSERT:
                // index is where it was inserted into the list
                // newIndex is the new item
                break;
            case SyncList<int>.Operation.OP_SET:
                // index is of the item that was changed
                // oldIndex is the previous value for the item at the index
                // newIndex is the new value for the item at the index
                break;
            case SyncList<int>.Operation.OP_CLEAR:
                // list got cleared
                break;
        }
    }

    public void OnHandHunterChanged(SyncList<int>.Operation op, int index, int oldIndex, int newIndex)
    {
        //Debug.Log($"OHHC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        switch (op)
        {
            case SyncList<int>.Operation.OP_ADD:
                RpcHandCardAdded(index);
                break;
            case SyncList<int>.Operation.OP_REMOVEAT:
                RpcHandCardRemoved(index);
                RpcUpdateText();
                break;
            case SyncList<int>.Operation.OP_INSERT:
                // index is where it was inserted into the list
                // newIndex is the new item
                break;
            case SyncList<int>.Operation.OP_SET:
                // index is of the item that was changed
                // oldIndex is the previous value for the item at the index
                // newIndex is the new value for the item at the index
                break;
            case SyncList<int>.Operation.OP_CLEAR:
                // list got cleared
                break;
        }

    }

    public void OnFieldHunterChanged(SyncList<int>.Operation op, int index, int oldIndex, int newIndex)
    {
        //Debug.Log($"OFHC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        switch (op)
        {
            case SyncList<int>.Operation.OP_ADD:
                RpcFieldCardAdded(index);
                break;
            case SyncList<int>.Operation.OP_REMOVEAT:
                RpcFieldCardRemoved(index);
                break;
            case SyncList<int>.Operation.OP_INSERT:
                // index is where it was inserted into the list
                // newIndex is the new item
                break;
            case SyncList<int>.Operation.OP_SET:
                // index is of the item that was changed
                // oldIndex is the previous value for the item at the index
                // newIndex is the new value for the item at the index
                break;
            case SyncList<int>.Operation.OP_CLEAR:
                // list got cleared
                break;
        }
    }

    public void OnDeckHunterChanged(SyncList<int>.Operation op, int index, int oldIndex, int newIndex)
    {
        //Debug.Log($"ODHC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        switch (op)
        {
            case SyncList<int>.Operation.OP_ADD:
                RpcDeckCardAdded(index);
                break;
            case SyncList<int>.Operation.OP_REMOVEAT:
                RpcDeckCardRemoved(index);
                break;
            case SyncList<int>.Operation.OP_INSERT:
                // index is where it was inserted into the list
                // newIndex is the new item
                break;
            case SyncList<int>.Operation.OP_SET:
                // index is of the item that was changed
                // oldIndex is the previous value for the item at the index
                // newIndex is the new value for the item at the index
                break;
            case SyncList<int>.Operation.OP_CLEAR:
                // list got cleared
                break;
        }
    }

    public void OnCardDatabaseChanged(SyncList<Card>.Operation op, int index, Card oldCard, Card newCard)
    {
        /*bool playerSideChange = false;
        if (((isDuckAttackPhase || isDuckDefensePhase || isDuckDragPhase) && index >= 0 && index < 30) 
        ||((isHunterAttackPhase || isHunterDefensePhase || isHunterDragPhase) && index >= 30 && index < 60)){
            playerSideChange = true;
        } */
        // Debug.Log($"OCDC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        if (true){
            switch (op)
            {
                case SyncList<Card>.Operation.OP_ADD:
                    RpcCardDatabaseCardAdded(index, newCard);
                    break;
                case SyncList<Card>.Operation.OP_REMOVEAT:
                    RpcCardDatabaseCardRemoved(index, newCard);
                    break;
                case SyncList<Card>.Operation.OP_INSERT:
                    RpcCardDatabaseCardInserted(index, newCard);
                    // index is where it was inserted into the list
                    // newIndex is the new item
                    break;
                case SyncList<Card>.Operation.OP_SET:
                    Debug.Log($"OFDC op = {op}, index = {index}, oldIndex = {oldCard.ToString()}, newIndex = {newCard.ToString()}");
                    RpcCardDatabaseCardSet(index, newCard);
                    // index is of the item that was changed
                    // oldIndex is the previous value for the item at the index
                    // newIndex is the new value for the item at the index
                    break;
                case SyncList<Card>.Operation.OP_CLEAR:
                    // list got cleared
                    break;
            }
        }

        RpcUpdateText();
    }

    public void OnIncomingAttacksChanged(SyncList<bool>.Operation op, int index, bool oldVal, bool newVal) {
        //Debug.Log($"OIAC op = {op}, index = {index}, oldIndex = {oldIndex}, newIndex = {newIndex}");
        switch (op)
        {
            case SyncList<bool>.Operation.OP_ADD:
                RpcIncomingAttacksChanged();
                break;
            case SyncList<bool>.Operation.OP_REMOVEAT:
                RpcIncomingAttacksChanged();
                break;
            case SyncList<bool>.Operation.OP_INSERT:
                RpcIncomingAttacksChanged();
                // index is where it was inserted into the list
                // newIndex is the new item
                break;
            case SyncList<bool>.Operation.OP_SET:
                RpcIncomingAttacksChanged();
                // index is of the item that was changed
                // oldIndex is the previous value for the item at the index
                // newIndex is the new value for the item at the index
                break;
            case SyncList<bool>.Operation.OP_CLEAR:
                // list got cleared
                break;
        }
    }
    /* HOOKS */
    
    public void OnDefensePhaseChanged(bool oldVal, bool newVal) {
        if (newVal && isServer) {
            Debug.Log("RpcDefensePhaseEntered called from server");
            RpcDefensePhaseEntered();
        }
        if(isServer){
           RpcUpdateText(); 
        }
        
    }


    public void OnAttackPhaseChanged(bool oldVal, bool newVal){
        if (isServer)
            RpcUpdateText();
    }


    public void OnDragPhaseChanged(bool oldVal, bool newVal){
        if (isServer)
            RpcUpdateText();
    }

    public void OnActiveSpellCardChanged(int oldVal, int newVal)
    {
        if (isServer)
            RpcUpdateActiveSpell();
    }
}
