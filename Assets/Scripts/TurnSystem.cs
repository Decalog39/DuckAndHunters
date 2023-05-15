using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    public bool isMyTurn;
    public bool playerStart;
    public int turnCount;
    public Text turnCountText;
    public Text manaText;
    public Text turnText;
    public int maxMana;
    public int currentMana;
    public Text enemyManaText;
    public int enemyMaxMana;
    public int enemyCurrentMana;
    public GameObject listss;
    public PlayerHandDeckManager lists;
    public GameObject attackP; 
    public AttackPhase attackPhase; //Reference to the attackPhase so we can change attack phase boolean


    // Start is called before the first frame update
    void Start(){
        
        System.Random rnd = new System.Random();
        maxMana = 1;
        currentMana = 1;
        manaText.text = currentMana + "/" + maxMana;
        enemyMaxMana = 1;
        enemyCurrentMana = 1;
        enemyManaText.text = enemyCurrentMana + "/" + enemyMaxMana;
        listss = GameObject.Find("Deck");
        lists = listss.GetComponent<PlayerHandDeckManager>();
        attackP = GameObject.Find("AttackPhase");
        attackPhase = attackP.GetComponent<AttackPhase>();
        int x = rnd.Next(0, 2); //generates random number - who has the first turn is random
        turnCount = 1;
        if (x == 0){ //player starts
            isMyTurn = true;
            playerStart = true;
            playerManager.CmdDraw();
        } 
        else{ //enemy starts
            isMyTurn = false;
            playerStart = false;
        }
    }

    // Update is called once per frame
    void Update(){
        //display texts (mana, turns...)
        if(isMyTurn){
            turnText.text = "your turn";
        } else {
            turnText.text = "Opponent turn";
        }
        manaText.text = currentMana + "/" + maxMana;
        enemyManaText.text = enemyCurrentMana + "/" + enemyMaxMana;
        turnCountText.text = "Turn " + turnCount;
    }

    public void endTurn(){
        if(isMyTurn){ //if player turn is over:
            isMyTurn = false;
            if (playerStart == false){
                turnCount++;
            }
            enemyMaxMana++;
            enemyCurrentMana = enemyMaxMana;

        } else { //if opponent turn is over
            isMyTurn = true;
            if (playerStart){
                turnCount++;
            }
            maxMana++;
            currentMana = maxMana;
            if(lists.hand.Count < 10){ //only 10 cards can be in hand at maximum
                playerManager.CmdDraw(); //a card is drawn to the player's hand
            }
        }
    }
}
