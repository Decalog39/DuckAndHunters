using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerTurnManager : MonoBehaviour {

    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    //public static PlayerManager instance;

    public TextMeshProUGUI player0HealthText;
    public TextMeshProUGUI player1HealthText;
    public Text player0ManaText;
    public Text player1ManaText;
    public Text turnText;
    public Text turnCountText;
    public GameObject buttonObj;
    public Text buttonText;


    // public GameObject attackP; 
    // public AttackPhase attackPhase; //Reference to the attackPhase so we can change attack phase boolean


    // public GameEndUIController gameEndUI;

    public static Player[] players = new Player[2];

    // private void Awake() {
    //     instance = this;
    // }

    void Start() {

        // attackP = GameObject.Find("AttackPhase");
        // attackPhase = attackP.GetComponent<AttackPhase>();
        buttonObj = GameObject.Find("ButtonText");
        buttonText = buttonObj.GetComponent<Text>();
    }

    void Update() {
    
    }

    public void updateText(){
        updateTurnText();
        updateManaText();
        updateHealthValues();
    }

    public void initializeText(){
        buttonText.text = "Waiting...";
        turnText.text = "Waiting for players";
    }

    public void updateTurnText(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckDragPhase && !GameManagerScript.instance.isDuckAttackPhase && !GameManagerScript.instance.isDuckDefensePhase){
                buttonText.text = "Enter Attack Phase";
                turnText.text = "Your Turn to play";
            } else if (!GameManagerScript.instance.isDuckDragPhase && GameManagerScript.instance.isDuckAttackPhase && !GameManagerScript.instance.isDuckDefensePhase){
                buttonText.text = "Confirm Attack";
                turnText.text = "Select cards to attack with";
            } else if(!GameManagerScript.instance.isDuckDragPhase && !GameManagerScript.instance.isDuckAttackPhase && GameManagerScript.instance.isDuckDefensePhase){
                buttonText.text = "End Defense";
                turnText.text = "You are defending";
            } else if (!GameManagerScript.instance.isDuckDragPhase && !GameManagerScript.instance.isDuckAttackPhase && !GameManagerScript.instance.isDuckDefensePhase){
                buttonText.text = "Waiting..";
                turnText.text = "Waiting for opponent..";
            }
        } else {
            if(GameManagerScript.instance.isHunterDragPhase && !GameManagerScript.instance.isHunterAttackPhase && !GameManagerScript.instance.isHunterDefensePhase){
                buttonText.text = "Enter Attack Phase";
                turnText.text = "Your Turn to play";
            } else if (!GameManagerScript.instance.isHunterDragPhase && GameManagerScript.instance.isHunterAttackPhase && !GameManagerScript.instance.isHunterDefensePhase){
                buttonText.text = "Confirm Attack";
                turnText.text = "Select cards to attack with";
            } else if(!GameManagerScript.instance.isHunterDragPhase && !GameManagerScript.instance.isHunterAttackPhase && GameManagerScript.instance.isHunterDefensePhase){
                buttonText.text = "End Defense";
                turnText.text = "You are defending";
            } else if (!GameManagerScript.instance.isHunterDragPhase && !GameManagerScript.instance.isHunterAttackPhase && !GameManagerScript.instance.isHunterDefensePhase){
                buttonText.text = "Waiting..";
                turnText.text = "Waiting for opponent..";
            }
        }
    }

    public void updateManaText(){
        if(playerManager.isDuck){
            player0ManaText.text = GameManagerScript.instance.duckCurrentMana.ToString() + "/" + GameManagerScript.instance.duckMaxMana.ToString();
            player1ManaText.text = GameManagerScript.instance.hunterCurrentMana.ToString() + "/" + GameManagerScript.instance.hunterMaxMana.ToString();
        } else {
            player0ManaText.text = GameManagerScript.instance.hunterCurrentMana.ToString() + "/" + GameManagerScript.instance.hunterMaxMana.ToString();
            player1ManaText.text = GameManagerScript.instance.duckCurrentMana.ToString() + "/" + GameManagerScript.instance.duckMaxMana.ToString();
        }
    }

    public void updateHealthValues() {
        if(playerManager.isDuck){
            player0HealthText.text = GameManagerScript.instance.duckHealth.ToString();
            player1HealthText.text = GameManagerScript.instance.hunterHealth.ToString();
        } else {
            player0HealthText.text = GameManagerScript.instance.hunterHealth.ToString();
            player1HealthText.text = GameManagerScript.instance.duckHealth.ToString();
        }
        
    }

    public int fetchEnemyPlayerHealth(){
        if(playerManager.ID == 0){
            GameObject enemyPlayerObject = GameManagerScript.instance.players[1];
            PlayerManager enemyPlayerScript = enemyPlayerObject.GetComponent<PlayerManager>();
            return enemyPlayerScript.health;
        } else {
            GameObject enemyPlayerObject = GameManagerScript.instance.players[0];
            PlayerManager enemyPlayerScript = enemyPlayerObject.GetComponent<PlayerManager>();
            return enemyPlayerScript.health;
        }
    }

    public int[] fetchEnemyPlayerMana(){ //First element current Mana, second element max Mana
        if(playerManager.ID == 0){
            GameObject enemyPlayerObject = GameManagerScript.instance.players[1];
            PlayerManager enemyPlayerScript = enemyPlayerObject.GetComponent<PlayerManager>();
            int[] returnArray = {enemyPlayerScript.currentMana, enemyPlayerScript.maxMana};
            return returnArray;
        } else {
            GameObject enemyPlayerObject = GameManagerScript.instance.players[0];
            PlayerManager enemyPlayerScript = enemyPlayerObject.GetComponent<PlayerManager>();
            int[] returnArray = {enemyPlayerScript.currentMana, enemyPlayerScript.maxMana};
            return returnArray;
        }
    }

    // public void DamagePlayer(Player player, int damage) {
    //     player.health -= damage;
    //     if(player.health <= 0) {
    //         if(players[0] == player) {
    //             GameFinished(players[1]);
    //         } else {
    //             GameFinished(players[0]);
    //         }
    //     }
    // }

    // public void GameFinished(Player winner) {
    //     gameEndUI.gameObject.SetActive(true);
    //     gameEndUI.Initialize(winner);
    // }

}
