using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{

    int currentNum = 0;
    public enum PlayerTypes { DUCK, HUNTER };
    public bool isDuck;
    public int health, maxMana, currentMana;
    public int ID;
    public bool myTurn;
    PlayerHandDeckManager playerHandDeckManager;
    OppoHandDeckManager oppoHandDeckManager;
    TurnSystem turnSystem;
    GameObject DefensePhase;
    DefensePhase defensePhase;
    PlayerTurnManager playerTurnManager;
    AttackPhase attackPhase;
    DragSystem[] dragSystems;

    System.Random rnd = new System.Random();

    public override void OnStartClient()
    {
        base.OnStartClient();

        // add the player object to the players array in GameManagerScript
        GameManagerScript.instance.nofPlayers++;

        GameManagerScript.instance.players.Add(gameObject);

        // increment nofPlayers and assign duck or hunter
        if (GameObject.FindWithTag("FactionSelectionTag") != null && GameManagerScript.instance.nofPlayers == 1)
        {
            GameObject FactionSelection = GameObject.FindWithTag("FactionSelectionTag");
            FactionChoice factionChoice = FactionSelection.GetComponent<FactionChoice>();
            isDuck = factionChoice.isDuck;
            CmdSetFirstFaction();
        }
        else
        {
            isDuck = !GameManagerScript.instance.firstIsDuck;
        }

        //Initialize player attributes
        this.health = 30;
        this.maxMana = 20;
        this.currentMana = 20;
        //If first to join, ID = 0, otherwise ID = 1.
        this.ID = (GameManagerScript.instance.nofPlayers == 1) ? 0 : 1;
    }

    private void Start()
    {
        if (isLocalPlayer)
        {
            // Get a reference to this PlayerManager and pass it to the non-network scripts
            playerHandDeckManager = FindObjectOfType<PlayerHandDeckManager>();
           oppoHandDeckManager = FindObjectOfType<OppoHandDeckManager>();
           turnSystem = FindObjectOfType<TurnSystem>();
           DefensePhase = GameObject.Find("DefensePhase");
           defensePhase = DefensePhase.GetComponent<DefensePhase>();
           playerTurnManager = FindObjectOfType<PlayerTurnManager>();
           attackPhase = FindObjectOfType<AttackPhase>();
           dragSystems = FindObjectsOfType<DragSystem>();

            playerHandDeckManager?.SetPlayerManager(this);
            oppoHandDeckManager?.SetPlayerManager(this);
            turnSystem?.SetPlayerManager(this);
            defensePhase.SetPlayerManager(this);
            playerTurnManager?.SetPlayerManager(this);
            attackPhase?.SetPlayerManager(this);
            foreach(var dragSystem in dragSystems) {
                dragSystem?.SetPlayerManager(this);
            }
            //Initialize text
            playerTurnManager.initializeText();

            // Initialize phase
        if (GameManagerScript.instance.nofPlayers == 2) {
            CmdInitPhase();
        }

            // initialize the dekcs and hands
            CmdInitDeck();
            CmdInitHand();
            //playerHandDeckManager.initiateImage();
            //oppoHandDeckManager.initiateImage();

        }
    }

    private void Update()
    {
        /*if(GameManagerScript.instance.nofPlayers >= 2){
            playerTurnManager.updateText();
        }*/
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.H))
        {
            int idx = 0;
            foreach(var player in GameManagerScript.instance.players)
            {
                Debug.Log($"{idx++}. player = {player} isDuck = {player.GetComponent<PlayerManager>().isDuck}");
            }
        }

        if(isLocalPlayer && defensePhase == null){
            Debug.Log("DefensePhase is NULLLLLLL");
        }

        if (isLocalPlayer && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log($"{GameManagerScript.instance.cardDatabase[46].ToString()}");
            Debug.Log($"{GameManagerScript.instance.cardDatabase[30].ToString()}");
        }
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.A))
        {
            CmdAddCard(currentNum++);
            ////Debug.Log("A key pressed");
            GameManagerScript.instance.printCards();
        }
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.R))
        {
            //Debug.Log("R pressed");
            drawDuckField(1);
            drawDuckField(2);
            drawDuckField(3);

        }
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.T))
        {
            //Debug.Log("T pressed");
            //CmdRemoveDuckFieldCardAtIndex(0);
            CmdRemoveDuckFieldCardAtIndex(1);
            CmdRemoveDuckFieldCardAtIndex(1);
        }
    }

    // TEST
    [Command(requiresAuthority = false)]
    public void drawDuckField(int index)
    {
        GameManagerScript.instance.fieldDuck.Add(index);
    }

    [Command(requiresAuthority = false)]
    public void CmdAddCard(int num)
    {
        GameManagerScript.instance.cards.Add(num);
    }


    public void updateUI()
    {
        ////Debug.Log("UI GETS UPDATED INSTEAD");

        // trying to activate card4 for testing, when a card is added to cards SyncList
        // TODO this method should be called from the callback when a card is added (on click of 'A')
        GameObject mainCanvasObject = GameObject.Find("Main Canvas");
        Transform fieldCard4Transform = mainCanvasObject.transform.Find("Field Panel/FieldCard (3)");
        GameObject fieldCard4Object = fieldCard4Transform.gameObject;
        fieldCard4Object.SetActive(true);
    }

    [Command(requiresAuthority = false)]
    private void CmdSetFirstFaction()
    {
        GameManagerScript.instance.firstIsDuck = isDuck;
    }

    /* --PHASE MANAGEMENT-- */
    /* --NOT USED-- */
    [Command(requiresAuthority = false)] 
    void CmdChangePhase(/*NetworkConnectionToClient sender = null*/)
    {
        switch (GameManagerScript.instance.currentPhase)
        {
            case GameManagerScript.PHASE.DUCK_DEFEND:
                GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.DUCK_DRAG;
                break;

            case GameManagerScript.PHASE.DUCK_DRAG:
                GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.DUCK_ATTACK;
                break;

            case GameManagerScript.PHASE.DUCK_ATTACK:
                if (GameManagerScript.instance.incomingAttacksFromDuck.Count == 0 || GameManagerScript.instance.fieldHunter.Count == 0)
                    GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.HUNTER_DRAG;
                else
                    GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.HUNTER_DEFEND;
                break;

            case GameManagerScript.PHASE.HUNTER_DEFEND:
                GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.HUNTER_DRAG;
                break;

            case GameManagerScript.PHASE.HUNTER_DRAG:
                GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.HUNTER_ATTACK;
                break;

            case GameManagerScript.PHASE.HUNTER_ATTACK:
                if (GameManagerScript.instance.incomingAttacksFromHunter.Count == 0 || GameManagerScript.instance.fieldDuck.Count == 0)
                    GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.DUCK_DRAG;
                else
                    GameManagerScript.instance.currentPhase = GameManagerScript.PHASE.DUCK_DEFEND;
                break;
        }
    }

    /* --PLAYER HAND DECK MANAGER-- */
    /* --DRAW-- */
    [Command(requiresAuthority = false)]
    public void CmdDraw()
    {
        //Debug.Log($"ConnId = {netId} isOwned = {isOwned}");
        if (isDuck) CmdDrawDuck();
        else CmdDrawHunter();
    }

    [Command(requiresAuthority = false)]
    public void CmdDrawDuck()
    {
        //Debug.Log($"DrawDuck called");

        if (GameManagerScript.instance.handDuck.Count < 10)
        {
            System.Random rnd = new System.Random();
            if (GameManagerScript.instance.deckDuck.Count > 0)
            {
                int x = rnd.Next(0, GameManagerScript.instance.deckDuck.Count);
                GameManagerScript.instance.handDuck.Add(GameManagerScript.instance.deckDuck[x]);
                GameManagerScript.instance.deckDuck.RemoveAt(x);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdDrawHunter()
    {
        ////Debug.Log($"DrawHunter called");
        if (GameManagerScript.instance.handHunter.Count < 10)
        {
            System.Random rnd = new System.Random();
            if (GameManagerScript.instance.deckHunter.Count > 0)
            {
                int x = rnd.Next(0, GameManagerScript.instance.deckHunter.Count);
                GameManagerScript.instance.handHunter.Add(GameManagerScript.instance.deckHunter[x]);
                GameManagerScript.instance.deckHunter.RemoveAt(x);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }


    [Command(requiresAuthority = false)]
    public void addFieldDuck(int index){
        GameManagerScript.instance.fieldDuck.Add(index);
    }

    [Command(requiresAuthority = false)]
    public void CmdInitDeck()
    {
        ////Debug.Log($"InitDeck");
        if (isDuck)
        {
            for (int i = 0; i < 30; i++)
            {
                GameManagerScript.instance.deckDuck.Add(i);
            }
        }
        else
        {
            for (int i = 30; i < 60; i++)
            {
                GameManagerScript.instance.deckHunter.Add(i);
            }
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdInitHand()
    {
        for (int j = 0; j < 5; j++)
        {
            CmdDraw();
        }
        
        // TEST PURPOSE
        if (isDuck) {
            GameManagerScript.instance.handDuck.Add(18);
            GameManagerScript.instance.handDuck.Add(19);
        }

        if (!isDuck) {
            GameManagerScript.instance.handHunter.Add(50);
            GameManagerScript.instance.handHunter.Add(56);

        }
    }

    /* --REMOVING DEAD CARDS-- */

    [Command(requiresAuthority = false)]
    public void CmdRemoveDuckFieldCardAtIndex(int index)
    {
        GameManagerScript.instance.fieldDuck.RemoveAt(index);
    }

    [Command(requiresAuthority = false)]
    public void CmdRemoveHunterFieldCardAtIndex(int index)
    {
        GameManagerScript.instance.fieldHunter.RemoveAt(index);
    }





    /* --DRAG SYSTEM-- */

    [Command(requiresAuthority = false)]
    public void CmdMoveFromHandToField(int cardID, int index) {
        Card card = GameManagerScript.instance.cardDatabase[cardID]; //checks database for the cards ID
        if(isDuck){
            if (card.character){ //character card check. Magic cards are not placed in field.
                if(GameManagerScript.instance.fieldDuck.Count < 5){ //only 5 cards can be on field at once
                    GameManagerScript.instance.fieldDuck.Add(cardID); //adds a the given card to the field, which increases field.Count
                    GameManagerScript.instance.handDuck.RemoveAt(index); //this card is removed from the hand
                }
            } 
            else
            {
                GameManagerScript.instance.handDuck.RemoveAt(index);
            }
        } else {
            if (card.character){ //character card check. Magic cards are not placed in field.
                if(GameManagerScript.instance.fieldHunter.Count < 5){ //only 5 cards can be on field at once
                    GameManagerScript.instance.fieldHunter.Add(cardID); //adds a the given card to the field, which increases field.Count
                    //Debug.Log("Gets Played");
                    GameManagerScript.instance.handHunter.RemoveAt(index); //this card is removed from the hand
                }
            } 
            else
            {
            GameManagerScript.instance.handHunter.RemoveAt(index);
            }
        }
    }


    /* --FROM ATTACK PHASE-- */
    [Command(requiresAuthority = false)]
    public void CmdChangeOutgoingAttackToTrue(int index){
        if(isDuck){
            GameManagerScript.instance.incomingAttacksFromDuck[index] = true;
        } else {
            GameManagerScript.instance.incomingAttacksFromHunter[index] = true;
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeOutgoingAttackToFalse(int index){
        if(isDuck){
            GameManagerScript.instance.incomingAttacksFromDuck[index] = false;
        } else {
            GameManagerScript.instance.incomingAttacksFromHunter[index] = false;
        }
    }

    //Changing boolean for attack
    [Command(requiresAuthority = false)]
    public void CmdStartAttackDuck()
    {
        if (!GameManagerScript.instance.isDuckDefensePhase &&!GameManagerScript.instance.isDuckDragPhase && GameManagerScript.instance.isDuckAttackPhase)
        {
            GameManagerScript.instance.isDuckDragPhase = false;
            GameManagerScript.instance.isDuckAttackPhase = false;
            GameManagerScript.instance.isHunterDefensePhase = true;
        }
        
    }

    [Command(requiresAuthority = false)]
    public void CmdStartAttackHunter()
    {
        if (!GameManagerScript.instance.isHunterDefensePhase && !GameManagerScript.instance.isHunterDragPhase && GameManagerScript.instance.isHunterAttackPhase)
        {
            GameManagerScript.instance.isHunterDragPhase = false;
            GameManagerScript.instance.isHunterAttackPhase = false;
            GameManagerScript.instance.isDuckDefensePhase = true;
        }
    }

    /* --FROM DRAG SYSTEM-- */
    [Command(requiresAuthority = false)]
    public void CmdEndDragPhaseDuck()
    {
        if (!GameManagerScript.instance.isDuckDefensePhase && GameManagerScript.instance.isDuckDragPhase && !GameManagerScript.instance.isDuckAttackPhase)
        {
            GameManagerScript.instance.isDuckDragPhase = false;
            GameManagerScript.instance.isDuckAttackPhase = true;
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdEndDragPhaseHunter()
    {
        if (!GameManagerScript.instance.isHunterDefensePhase && GameManagerScript.instance.isHunterDragPhase && !GameManagerScript.instance.isHunterAttackPhase)
        {
            GameManagerScript.instance.isHunterDragPhase = false;
            GameManagerScript.instance.isHunterAttackPhase = true;
        }
    }

    /* --FROM DEFENSE PHASE-- */
    [Command(requiresAuthority = false)]
    public void CmdEndDefensePhaseDuck()
    {
        if (GameManagerScript.instance.isDuckDefensePhase && !GameManagerScript.instance.isDuckDragPhase && !GameManagerScript.instance.isDuckAttackPhase)
        {
            GameManagerScript.instance.isDuckDragPhase = true;
            GameManagerScript.instance.isDuckDefensePhase = false;
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdEndDefensePhaseHunter()
    {
        if (GameManagerScript.instance.isHunterDefensePhase && !GameManagerScript.instance.isHunterDragPhase && !GameManagerScript.instance.isHunterAttackPhase)
        {
            GameManagerScript.instance.isHunterDragPhase = true;
            GameManagerScript.instance.isHunterDefensePhase = false;
        }
    }

    /* --For changing incoming attack list-- */
    [Command(requiresAuthority = false)]
    public void CmdChangeIncomingAttackFromOpponentIndexToTrue(int index){
        if(isDuck){
            GameManagerScript.instance.incomingAttacksFromHunter[index] = true;
        } else {
            GameManagerScript.instance.incomingAttacksFromDuck[index] = true;
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeIncomingAttackFromOpponentIndexToFalse(int index){
        if(isDuck){
            GameManagerScript.instance.incomingAttacksFromHunter[index] = false;
        } else {
            GameManagerScript.instance.incomingAttacksFromDuck[index] = false;
        }
    }

    /* --For Changing the client health, mana (max and current)-- */
    [Command(requiresAuthority = false)]
    public void CmdChangeDuckHealth(int healthChange){
        GameManagerScript.instance.duckHealth = GameManagerScript.instance.duckHealth + healthChange;
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeHunterHealth(int healthChange){
        GameManagerScript.instance.hunterHealth = GameManagerScript.instance.hunterHealth + healthChange;
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeDuckCurrentMana(int manaChange){
        GameManagerScript.instance.duckCurrentMana = GameManagerScript.instance.duckCurrentMana + manaChange;
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeHunterCurrentMana(int manaChange){
        GameManagerScript.instance.hunterCurrentMana = GameManagerScript.instance.hunterCurrentMana + manaChange;
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeDuckMaxMana(int manaChange){
        GameManagerScript.instance.duckMaxMana = GameManagerScript.instance.duckMaxMana + manaChange;
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeHunterMaxMana(int manaChange){
        GameManagerScript.instance.hunterMaxMana = GameManagerScript.instance.hunterMaxMana + manaChange;
    }

    [Command(requiresAuthority = false)]
    public void CmdSetDuckCurrentMana(int into){
        GameManagerScript.instance.duckCurrentMana = into;
    }

    [Command(requiresAuthority = false)]
    public void CmdSetHunterCurrentMana(int into){
        GameManagerScript.instance.hunterCurrentMana = into;
    }


    /* --For Selecting Attacking Card-- */

    [Command(requiresAuthority = false)]
    public void CmdShiftAttackBoolList(int index){
        if(isDuck){
            GameManagerScript.instance.incomingAttacksFromHunter.RemoveAt(index);
            
            GameManagerScript.instance.incomingAttacksFromHunter.Add(false);
            
        } else {
            GameManagerScript.instance.incomingAttacksFromDuck.RemoveAt(index);
            
            GameManagerScript.instance.incomingAttacksFromDuck.Add(false);
            
        }

    }

    [Command(requiresAuthority = false)]
    public void CmdselectAttackCardToDefend0(Card defendingCard, int index){
        if(isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase && GameManagerScript.instance.incomingAttacksFromHunter[0] && defendingCard != null){
                //int attIndex = defensePhase.at0.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]];
                if (attackingCard.attack >= defendingCard.health){
                    if (attackingCard.id == 50 || attackingCard.id == 51) {
                        CmdChangeDuckHealth((-(int)(attackingCard.attack - defendingCard.health))*2);
                    } else {
                        CmdChangeDuckHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = 0;
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                        CmdChangeIncomingAttackFromOpponentIndexToFalse(0);
                } else
                {
                    if(defendingCard.id != 20 && defendingCard.id != 21) {
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = defendingCard.health - attackingCard.attack;
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                        CmdChangeIncomingAttackFromOpponentIndexToFalse(0);
                    }
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]].Clone();
                    CmdShiftAttackBoolList(0);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[0]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(0);

                }
                

            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase && GameManagerScript.instance.incomingAttacksFromDuck[0] && defendingCard != null){
                
            
                //int attIndex = defensePhase.at0.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]];
                if (attackingCard.attack >= defendingCard.health){
                    if(!GameManagerScript.instance.camoBool) {
                        CmdChangeHunterHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(0);
                } else {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = defendingCard.health - attackingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(0);
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]].Clone();
                    CmdShiftAttackBoolList(0);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[0]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(0);
                }
            
            }
        }
    } 

    [Command(requiresAuthority = false)]
    public void CmdselectAttackCardToDefend1(Card defendingCard, int index){
        if(isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase && GameManagerScript.instance.incomingAttacksFromHunter[1] && defendingCard != null){
                //int attIndex = defensePhase.at1.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]];
                if (attackingCard.attack >= defendingCard.health){
                    if (attackingCard.id == 50 || attackingCard.id == 51) {
                        CmdChangeDuckHealth((-(int)(attackingCard.attack - defendingCard.health))*2);
                    } else {
                        CmdChangeDuckHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(1);
                } else {
                    if(defendingCard.id != 20 && defendingCard.id != 21) {
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = defendingCard.health - attackingCard.attack;
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                        CmdChangeIncomingAttackFromOpponentIndexToFalse(1);
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]].Clone();
                    CmdShiftAttackBoolList(1);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[1]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(1);
                }
                }
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase && GameManagerScript.instance.incomingAttacksFromDuck[1] && defendingCard != null){
                //int attIndex = defensePhase.at1.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]];
                if (attackingCard.attack >= defendingCard.health){
                    if(!GameManagerScript.instance.camoBool) {
                        CmdChangeHunterHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(1);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = defendingCard.health - attackingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(1);
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]].Clone();
                    CmdShiftAttackBoolList(1);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[1]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(1);
                }
                
            }
        }
    } 

    [Command(requiresAuthority = false)]
    public void CmdselectAttackCardToDefend2(Card defendingCard, int index){
        if(isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase && GameManagerScript.instance.incomingAttacksFromHunter[2] && defendingCard != null){
                //int attIndex = defensePhase.at2.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]];
                if (attackingCard.attack >= defendingCard.health){
                    if (attackingCard.id == 50 || attackingCard.id == 51) {
                        CmdChangeDuckHealth((-(int)(attackingCard.attack - defendingCard.health))*2);
                    } else {
                        CmdChangeDuckHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }                    
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(2);
                } else
                {
                    if(defendingCard.id != 20 && defendingCard.id != 21) {
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = defendingCard.health - attackingCard.attack;
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                        CmdChangeIncomingAttackFromOpponentIndexToFalse(2);
                    }
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]].Clone();
                    CmdShiftAttackBoolList(2);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[2]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(2);
                }
               
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase && GameManagerScript.instance.incomingAttacksFromDuck[2] && defendingCard != null){
                //int attIndex = defensePhase.at2.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]];
                if (attackingCard.attack >= defendingCard.health){
                    if(!GameManagerScript.instance.camoBool) {
                        CmdChangeHunterHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(2);

                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = defendingCard.health - attackingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(2);
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]].Clone();
                    CmdShiftAttackBoolList(2);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[2]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(2);
                }
                
            }
        }
    } 

    [Command(requiresAuthority = false)]
    public void CmdselectAttackCardToDefend3(Card defendingCard, int index){
        if(isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase && GameManagerScript.instance.incomingAttacksFromHunter[3] && defendingCard != null){
                //int attIndex = defensePhase.at3.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]];
                if (attackingCard.attack >= defendingCard.health){
                    if (attackingCard.id == 50 || attackingCard.id == 51) {
                        CmdChangeDuckHealth((-(int)(attackingCard.attack - defendingCard.health))*2);
                    } else {
                        CmdChangeDuckHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(3);
                } else
                {
                    if(defendingCard.id != 20 && defendingCard.id != 21) {
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = defendingCard.health - attackingCard.attack;
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                        CmdChangeIncomingAttackFromOpponentIndexToFalse(3);
                    }
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]].Clone();
                    CmdShiftAttackBoolList(3);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[3]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(3);
                }
              
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase && GameManagerScript.instance.incomingAttacksFromDuck[3] && defendingCard != null){
                //int attIndex = defensePhase.at3.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]];
                if (attackingCard.attack >= defendingCard.health){
                    if(!GameManagerScript.instance.camoBool) {
                        CmdChangeHunterHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(3);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = defendingCard.health - attackingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(3);
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]].Clone();
                    CmdShiftAttackBoolList(3);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[3]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(3);
                }
               
            }
        }
    } 

    [Command(requiresAuthority = false)]
    public void CmdselectAttackCardToDefend4(Card defendingCard, int index){
        if(isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase && GameManagerScript.instance.incomingAttacksFromHunter[4] && defendingCard != null){
                //int attIndex = defensePhase.at4.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]];
                if (attackingCard.attack >= defendingCard.health){
                    if (attackingCard.id == 50 || attackingCard.id == 51) {
                        CmdChangeDuckHealth((-(int)(attackingCard.attack - defendingCard.health))*2);
                    } else {
                        CmdChangeDuckHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(4);
                } else
                {
                    if(defendingCard.id != 20 && defendingCard.id != 21) {
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].health = defendingCard.health - attackingCard.attack;
                        GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]].Clone();
                        CmdChangeIncomingAttackFromOpponentIndexToFalse(4);
                    }
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]].Clone();
                    CmdShiftAttackBoolList(4);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[4]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(4);
                }
               
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase && GameManagerScript.instance.incomingAttacksFromDuck[4] && defendingCard != null){
                //int attIndex = defensePhase.at4.transform.GetSiblingIndex();
                Card attackingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]];
                if (attackingCard.attack >= defendingCard.health){
                    if(!GameManagerScript.instance.camoBool) {
                        CmdChangeHunterHealth(-(int)(attackingCard.attack - defendingCard.health));
                    }
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(4);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].health = defendingCard.health - attackingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(4);
                }
                if (defendingCard.attack >= attackingCard.health){
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]].health = 0;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]].Clone();
                    CmdShiftAttackBoolList(4);
                } else
                {
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]].health = attackingCard.health - defendingCard.attack;
                    GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[4]].Clone();
                    CmdChangeIncomingAttackFromOpponentIndexToFalse(4);
                }
                
            }
        }
    } 

    [Command(requiresAuthority = false)]
    public void CmdInitPhase() {
        GameManagerScript.instance.isDuckDragPhase = true;
    }

    /* --CARD EFFECTS-- */
    [Command(requiresAuthority = false)]

    public void CmdApplySpecialEffects(int cardID, int index) {
        Card card = GameManagerScript.instance.cardDatabase[cardID];
        if(isDuck){
            if (card.character){ 
                if(GameManagerScript.instance.fieldDuck.Count < 5){ 
                    GameManagerScript.instance.fieldDuck.Add(cardID);
                    GameManagerScript.instance.handDuck.RemoveAt(index);

                    if (cardID == 10){ //King Duck
                        AudioManager.instance.Play("supercards");
                        for (int i =0 ; i <GameManagerScript.instance.fieldDuck.Count - 1; i++){
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]].attack += 1;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]].Clone();

                            // emptyPositions[i] = cardsArray[i].transform.position;
                        }
                        // animationAtkAddLoops(emptyPositions, 1, GameManagerScript.instance.fieldDuck.Count - 1);
                    }
                    else if (cardID == 11){ // Queen Duck
                        AudioManager.instance.Play("supercards");
                        int cardIndex = rnd.Next(GameManagerScript.instance.fieldDuck.Count-1);
                        int statBuff = rnd.Next(5);
                        
                        if (statBuff == 0 || statBuff ==1){
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]].attack += 2;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]].Clone();
                            // animationAtkAdd(cardsArray[cardIndex].transform.position, 2);
                        }
                        else if (statBuff == 2 || statBuff == 3){
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]].health += 2;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]].Clone();
                            // animationAdd(cardsArray[cardIndex].transform.position, 2);
                        }
                        else{
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]].attack += 2;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]].health += 2;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[cardIndex]].Clone();
                            // animationQuack(cardsArray[cardIndex].transform.position, 2,2, 0);

                        }
                    }
                    else if (cardID > 11 && cardID < 15){ // Soldier duck
                        for (int i =0 ; i <GameManagerScript.instance.fieldDuck.Count - 1; i++){
                            if (GameManagerScript.instance.fieldDuck[i] < 10 && GameManagerScript.instance.fieldDuck[i] > 6){
                                AudioManager.instance.Play("healing");
                                GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]].health += 1;
                                GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]].Clone();
                                // counter++;
                                //emptyPositions[counter] = cardsArray[i].transform.position;
                            }
                            // animationAddLoops(emptyPositions, 1, counter);
                        }
                    }
                    if (cardID == 16 || cardID == 17){ //flock
                        GameManagerScript.instance.activeSpellId = cardID;
                    }

                }
            } 
            else { // if(card.spell)

                if (cardID == 23 || cardID == 24 || cardID == 26 || cardID == 28 || cardID == 29){ //target select spells (rest, rest, drown, sleep eye open, qwack)
                    GameManagerScript.instance.activeSpellId = cardID;
                    //lists.hand.RemoveAt(index); 
                }
                else { //whole field effect spells
                
                    if (cardID == 22){ //Waddle
                        CmdDraw();
                    }
                    else if(cardID == 25){ //Fence
                        CmdChangeHunterHealth(-2);
                    }
                    else if(cardID == 27){

                        for (int i =0 ; i <GameManagerScript.instance.fieldDuck.Count; i++){ //Bread
                            AudioManager.instance.Play("healing");  
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]].health += 1;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]].Clone();
                            // emptyPositions[i] = cardsArray[i].transform.position;
                        }

                        // animationAddLoops(emptyPositions, 1, lists.field.Count);
                    }
                }   
                GameManagerScript.instance.handDuck.RemoveAt(index);
            }
        } else { // if(isHunter)
            if (card.character){ 
                if(GameManagerScript.instance.fieldHunter.Count < 5){ 
                    GameManagerScript.instance.fieldHunter.Add(cardID);
                    GameManagerScript.instance.handHunter.RemoveAt(index);

                    if (cardID == 40){ //Master hunter
                        AudioManager.instance.Play("supercards");
                    }
                    else if (cardID == 41){ //Artemis
                        AudioManager.instance.Play("supercards");
                        for (int i =0 ; i <GameManagerScript.instance.fieldHunter.Count -1; i++){
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].health += 1;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].attack += 1;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].Clone();
                            // animationQuack(cardsArray[i].transform.position, 1, 1, 0);
                        }
                    }
                    else if (cardID < 45 && cardID > 41){ //Beagle
                        AudioManager.instance.Play("suspend");
                        for (int i =0 ; i <GameManagerScript.instance.fieldHunter.Count -1; i++){
                            if (GameManagerScript.instance.fieldHunter[i] < 37 && GameManagerScript.instance.fieldHunter[i] > 33){
                                GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].attack += 1;
                                GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].Clone();
                                // animationAtkAdd(cardsArray[i].transform.position, 1);
                            }
                        }    
                    }
                    else if(cardID == 45){ //Recreational hunter
                        CmdChangeHunterHealth(-3);
                    }

                    if (cardID == 46 || cardID == 47 || cardID == 48 || cardID == 49){ //duck tolling retreiver x2, trap setter x2
                        GameManagerScript.instance.activeSpellId = cardID;
                    }
                }
            } 
            else { // if(card.spell)

                if (cardID == 53 || cardID == 54 || cardID == 55 || cardID == 58 || cardID == 59){ //target select spells (hunting season x2, trap, gunpowder, swap)
                    GameManagerScript.instance.activeSpellId = cardID;
                    //lists.hand.RemoveAt(index); 
                }
                else { //whole field effect spells
                
                    if (cardID == 52){ //Expedition
                        CmdDraw();
                    }
                    else if (cardID == 56){
                        GameManagerScript.instance.camoBool = !GameManagerScript.instance.camoBool;
                        Debug.Log(GameManagerScript.instance.camoBool);
                    }
                    else if (cardID == 57){
                        AudioManager.instance.Play("suspend");
                        for (int i =0 ; i <GameManagerScript.instance.fieldHunter.Count; i++){
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].attack += 1;
                            GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]] = (Card)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].Clone();
                            //animationAtkAdd(cardsArray[i].transform.position, 1);
                        }
                    }
                }
            GameManagerScript.instance.handHunter.RemoveAt(index);
            }
        }
    }

    /* --CARD EFFECTS-- */
    [Command(requiresAuthority = false)]
    public void targetSpellEffects(int selectedId, int spellID) {
        Debug.Log(selectedId);
        if (isDuck) {
            //ducks select spells (can be done both on yourself and enemy)
                if (spellID == 16 || spellID == 17){ //Flock
                    AudioManager.instance.Play("healing");
                    int extraHealth = GameManagerScript.instance.fieldDuck.Count - 1;
                    GameManagerScript.instance.cardDatabase[selectedId].health += extraHealth;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationAdd(thisCard.transform.position, extraHealth);

                }
                else if (spellID == 23 || spellID == 24){ //rest
                    Debug.Log("rest");
                    AudioManager.instance.Play("healing");
                    GameManagerScript.instance.cardDatabase[selectedId].health += 2;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();                    // animationAdd(thisCard.transform.position, 2);
                }
                else if (spellID == 26){ //Drown
                        Debug.Log("Drown");
                        GameManagerScript.instance.cardDatabase[selectedId].health = 0;
                        GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationMinus(thisCard.transform.position, (int) CardDatabase.cardList[selectedId].health);
                }
                else if(spellID == 28){ //Sleep with one eye open
                    AudioManager.instance.Play("healing");
                    GameManagerScript.instance.cardDatabase[selectedId].health += 10;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationAdd(thisCard.transform.position, 10);
                }
                else if (spellID == 29){ // QUACK
                    int randAtk = rnd.Next(6);
                    int change = rnd.Next(2);
                    AudioManager.instance.Play("suspend");
                    if (change == 0){
                        GameManagerScript.instance.cardDatabase[selectedId].health += randAtk;
                        GameManagerScript.instance.cardDatabase[selectedId].attack += randAtk;                        
                        GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                        // animationQuack(thisCard.transform.position, randAtk, randAtk, 0);
                        
                    }
                    else{
                        GameManagerScript.instance.cardDatabase[selectedId].health -= randAtk;
                        GameManagerScript.instance.cardDatabase[selectedId].attack -= randAtk;                        
                        GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                        // animationQuack(thisCard.transform.position, randAtk, randAtk, 1);
                    }
                        
                }
        }
        else { // if(isHunter)
            if (spellID == 46 || spellID == 47){ //Duck Tolling Retriever
                    int extraAttack = GameManagerScript.instance.fieldDuck.Count;
                    AudioManager.instance.Play("suspend");
                    GameManagerScript.instance.cardDatabase[selectedId].attack += extraAttack;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationAtkAdd(thisCard.transform.position, extraAttack);
                    Debug.Log(GameManagerScript.instance.cardDatabase[selectedId].health);
                }
                else if (spellID == 48 || spellID == 49){// Trap Setter
                    GameManagerScript.instance.cardDatabase[selectedId].health -= 2;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationMinus(thisCard.transform.position, 2);
                }
                else if (spellID == 53 || spellID == 54){ //Hunting Season
                    AudioManager.instance.Play("suspend");
                    GameManagerScript.instance.cardDatabase[selectedId].health += 2;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationAtkAdd(thisCard.transform.position, 2);
                }
                else if (spellID == 55){ //Trap
                    GameManagerScript.instance.cardDatabase[selectedId].health /= 2;
                    GameManagerScript.instance.cardDatabase[selectedId].attack /= 2;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationQuack(thisCard.transform.position, (int) (CardDatabase.cardList[selectedId].attack - CardDatabase.cardList[selectedId].attack/2), (int) (CardDatabase.cardList[selectedId].health - CardDatabase.cardList[selectedId].health/2), 1);
                }
                else if (spellID == 58){ //Gunpowder
                    AudioManager.instance.Play("suspend");
                    GameManagerScript.instance.cardDatabase[selectedId].attack += 5;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                    // animationAtkAdd(thisCard.transform.position, 5);
                }
                else if (spellID == 59){ //Swap
                    int? atk = GameManagerScript.instance.cardDatabase[selectedId].attack;
                    // animationSwap(thisCard.transform.position, (int) atk, (int) CardDatabase.cardList[selectedId].health);
                    GameManagerScript.instance.cardDatabase[selectedId].attack = GameManagerScript.instance.cardDatabase[selectedId].health;                
                    GameManagerScript.instance.cardDatabase[selectedId].health = atk;
                    GameManagerScript.instance.cardDatabase[selectedId] = (Card)GameManagerScript.instance.cardDatabase[selectedId].Clone();
                }
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdChangeActiveSpellId(int val) {
        GameManagerScript.instance.activeSpellId = val;
    }
}