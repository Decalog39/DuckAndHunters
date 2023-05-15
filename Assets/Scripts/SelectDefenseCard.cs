using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDefenseCard : MonoBehaviour
{
    public bool selecting;
    public GameObject playerCards; 
    public PlayerHandDeckManager playerList;
    public GameObject oppoCards; 
    public OppoHandDeckManager oppoList;
    public int index;
    
    public GameObject c0;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;

    public int oIndex;
    public Card attackingCard;
    public Card defendingCard;

    // Start is called before the first frame update
    
    void Start()
    {
        playerCards = GameObject.Find("Deck");
        playerList = playerCards.GetComponent<PlayerHandDeckManager>();
        oppoCards = GameObject.Find("OppoDeck");
        oppoList = oppoCards.GetComponent<OppoHandDeckManager>();
        defendingCard = null;
        attackingCard = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectDefendingCard0(){
        if (selecting){
            index = c0.transform.GetSiblingIndex();
            c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

            defendingCard = GameManagerScript.instance.cardDatabase[playerList.field[index]];
            c0.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }        
    }

    public void selectDefendingCard1(){
        if (selecting) {
            index = c1.transform.GetSiblingIndex();
            c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

            defendingCard = GameManagerScript.instance.cardDatabase[playerList.field[index]];
            c1.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }

    public void selectDefendingCard2(){
        if(selecting){
            index = c2.transform.GetSiblingIndex();
            c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

            defendingCard = GameManagerScript.instance.cardDatabase[playerList.field[index]];
            c2.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }

    public void selectDefendingCard3(){
        if(selecting){
            index = c3.transform.GetSiblingIndex();
            c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

            defendingCard = GameManagerScript.instance.cardDatabase[playerList.field[index]];
            c3.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }

    public void selectDefendingCard4(){
        if(selecting){
            index = c4.transform.GetSiblingIndex();
            c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

            defendingCard = GameManagerScript.instance.cardDatabase[playerList.field[index]];
            c4.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
    }

    public void confirmDefendingCard(){
        if(selecting){
            attackingCard = GameManagerScript.instance.cardDatabase[oppoList.field[oIndex]];
            if (defendingCard == null){
                PlayerTurnManager.players[0].health = PlayerTurnManager.players[0].health - (int)attackingCard.attack;
            } 
            else
            {
                if (attackingCard.attack > defendingCard.health){
                    GameManagerScript.instance.cardDatabase[playerList.field[index]].health = 0;
                    PlayerTurnManager.players[0].health = PlayerTurnManager.players[0].health - (int)(attackingCard.attack - defendingCard.health);
                } else
                {
                    GameManagerScript.instance.cardDatabase[playerList.field[index]].health = defendingCard.health - attackingCard.attack;
                }

                if (defendingCard.attack > attackingCard.health){
                    GameManagerScript.instance.cardDatabase[oppoList.field[oIndex]].health = 0;
                } else
                {
                    GameManagerScript.instance.cardDatabase[oppoList.field[oIndex]].health = attackingCard.health - defendingCard.attack;
                }

            }
            c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
            defendingCard = null;
            attackingCard = null;
            selecting = false;
        }
    }
    
}
