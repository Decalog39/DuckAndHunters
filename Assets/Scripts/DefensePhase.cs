using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefensePhase : MonoBehaviour
{
    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    public Card defendingCard;
    public Card attackingCard;

    public GameObject c0;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;

    public GameObject at0;
    public GameObject at1;
    public GameObject at2;
    public GameObject at3;
    public GameObject at4;

    public int attIndex;
    public int index;

    // Start is called before the first frame update
    void Start()
    {   
        attackingCard = null;
        defendingCard = null;

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateDefenseUI(){

        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase){
                if (GameManagerScript.instance.incomingAttacksFromHunter[0]){ //If attack is incoming, highlight the cards in the enemy field that are attacking
                    at0.GetComponent<Image>().color = new Color32(255, 0, 0, 255);    
                } else
                {
                    at0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromHunter[1]){
                    at1.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromHunter[2]){
                    at2.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromHunter[3]){
                    at3.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromHunter[4]){
                    at4.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } 
                if (defendingCard == null){
                    c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase){
                if (GameManagerScript.instance.incomingAttacksFromDuck[0]){ //If attack is incoming, highlight the cards in the enemy field that are attacking
                    at0.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromDuck[1]){
                    at1.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromDuck[2]){
                    at2.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromDuck[3]){
                    at3.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (GameManagerScript.instance.incomingAttacksFromDuck[4]){
                    at4.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                } else
                {
                    at4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                if (defendingCard == null){
                    c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
            }
        }
    }
    public void selectDefend0(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase){
                index = c0.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                
                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]];
                c0.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase){
                index = c0.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]];
                c0.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        }
    }

    public void selectDefend1(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase){
                index = c1.transform.GetSiblingIndex();
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]];
                c1.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase){
                index = c1.transform.GetSiblingIndex();
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]];
                c1.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        }
    }

    public void selectDefend2(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase){
                index = c2.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]];
                c2.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase){
                index = c2.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]];
                c2.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        }
    }

    public void selectDefend3(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase){
                index = c3.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]];
                c3.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase){
                index = c3.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]];
                c3.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        }
    }

    public void selectDefend4(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckDefensePhase){
                index = c4.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[index]];
                c4.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        } else {
            if(GameManagerScript.instance.isHunterDefensePhase){
                index = c4.transform.GetSiblingIndex();
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);

                defendingCard = GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[index]];
                c4.GetComponent<Image>().color = new Color32(0 , 122, 254, 255);
            }
        }
    }

    public void selectAttack0(){
        playerManager.CmdselectAttackCardToDefend0(defendingCard, index);
        attackingCard = null;
        defendingCard = null;
        if(playerManager.isDuck){
            if(GameManagerScript.instance.duckHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        } else {
            if(GameManagerScript.instance.hunterHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        }
    }

    public void selectAttack1(){
        playerManager.CmdselectAttackCardToDefend1(defendingCard, index);
        attackingCard = null;
        defendingCard = null;
        if(playerManager.isDuck){
            if(GameManagerScript.instance.duckHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        } else {
            if(GameManagerScript.instance.hunterHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        }
    }

    public void selectAttack2(){
        playerManager.CmdselectAttackCardToDefend2(defendingCard, index);
        attackingCard = null;
        defendingCard = null;
        if(playerManager.isDuck){
            if(GameManagerScript.instance.duckHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        } else {
            if(GameManagerScript.instance.hunterHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        }
    }

    public void selectAttack3(){
        playerManager.CmdselectAttackCardToDefend3(defendingCard, index);
        attackingCard = null;
        defendingCard = null;
        if(playerManager.isDuck){
            if(GameManagerScript.instance.duckHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        } else {
            if(GameManagerScript.instance.hunterHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        }
    }

    public void selectAttack4(){
        playerManager.CmdselectAttackCardToDefend4(defendingCard, index);
        attackingCard = null;
        defendingCard = null;
        if(playerManager.isDuck){
            if(GameManagerScript.instance.duckHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        } else {
            if(GameManagerScript.instance.hunterHealth <= 0)
            SceneManager.LoadScene(sceneName:"EndofScene");
        }
    }

    public void endDefensePhase(){
        if (GameManagerScript.instance.activeSpellId == -1) {
            if(playerManager.isDuck){
                if(GameManagerScript.instance.isDuckDefensePhase){
                    AudioManager.instance.Play("carddead");
                for (int i = 0; i < GameManagerScript.instance.fieldHunter.Count; i++){
                    if (GameManagerScript.instance.incomingAttacksFromHunter[i]) {
                        playerManager.CmdChangeDuckHealth(-(int)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldHunter[i]].attack);
                    }
                }
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                attackingCard = null;
                defendingCard = null;
                for(int i = 0; i < 5; i++){
                    playerManager.CmdChangeIncomingAttackFromOpponentIndexToFalse(i);
                }
                playerManager.CmdDraw();
                int previous = GameManagerScript.instance.duckMaxMana;
                int next = previous + 1;
                playerManager.CmdChangeDuckMaxMana(1);
                playerManager.CmdSetDuckCurrentMana(next);
                playerManager.CmdEndDefensePhaseDuck();
            }
            } else {
                if(GameManagerScript.instance.isHunterDefensePhase){
                    AudioManager.instance.Play("carddead");
                for (int i = 0; i < GameManagerScript.instance.fieldDuck.Count; i++){
                    if (GameManagerScript.instance.incomingAttacksFromDuck[i]) {
                        if(!GameManagerScript.instance.camoBool) {
                            Debug.Log(GameManagerScript.instance.camoBool);
                            playerManager.CmdChangeHunterHealth(-(int)GameManagerScript.instance.cardDatabase[GameManagerScript.instance.fieldDuck[i]].attack);
                        }
                    }
                }
                c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                at4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                attackingCard = null;
                defendingCard = null;
                for(int i = 0; i < 5; i++){
                    playerManager.CmdChangeIncomingAttackFromOpponentIndexToFalse(i);
                }
                playerManager.CmdDraw();
                int previous = GameManagerScript.instance.hunterMaxMana;
                int next = previous + 1;
                playerManager.CmdChangeHunterMaxMana(1);
                playerManager.CmdSetHunterCurrentMana(next);
                playerManager.CmdEndDefensePhaseHunter();
                
                Debug.Log(GameManagerScript.instance.camoBool);
                GameManagerScript.instance.camoBool = false;
            }
            }
        }
    }
}
