using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{   
    public bool isMyTurn;
    public int yourTurn;
    public int enemyTurn;
    public Text manaText;
    public Text turnText;
    public int maxMana;
    public int currentMana;

    // Start is called before the first frame update
    void Start(){
        isMyTurn = true;
        yourTurn = 1;
        enemyTurn = 0;
        maxMana = 1;
        currentMana = 1;
        manaText.text = currentMana + "/" + maxMana;
    }

    // Update is called once per frame
    void Update(){
        if(isMyTurn){
            turnText.text = "your turn";
        } else {
            turnText.text = "Opponent turn";
        }
        manaText.text = currentMana + "/" + maxMana;
    }

    public void endYourTurn(){
        if(isMyTurn){
            isMyTurn = false;
            enemyTurn++;
        }
    }

    public void endEnemyTurn(){
        if(!isMyTurn){
            isMyTurn = true;
            yourTurn++;
            maxMana++;
            currentMana = maxMana;
        }
    }
}
