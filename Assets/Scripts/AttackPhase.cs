using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackPhase : MonoBehaviour
{
    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }
    public int index;

    public GameObject c0;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void turnAttackBool0(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckAttackPhase){
                index = c0.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromDuck[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c0.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        } else {
            if(GameManagerScript.instance.isHunterAttackPhase){
                index = c0.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromHunter[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c0.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        }
    }

    public void turnAttackBool1(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckAttackPhase){
                index = c1.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromDuck[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c1.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        } else {
            if(GameManagerScript.instance.isHunterAttackPhase){
                index = c1.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromHunter[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c1.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        }
    }

    public void turnAttackBool2(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckAttackPhase){
                index = c2.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromDuck[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c2.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        } else {
            if(GameManagerScript.instance.isHunterAttackPhase){
                index = c2.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromHunter[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c2.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        }
    }

    public void turnAttackBool3(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckAttackPhase){
                index = c3.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromDuck[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c3.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        } else {
            if(GameManagerScript.instance.isHunterAttackPhase){
                index = c3.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromHunter[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c3.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        }
    }

    public void turnAttackBool4(){
        if(playerManager.isDuck){
            if(GameManagerScript.instance.isDuckAttackPhase){
                index = c4.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromDuck[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c4.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        } else {
            if(GameManagerScript.instance.isHunterAttackPhase){
                index = c4.transform.GetSiblingIndex();
                if(GameManagerScript.instance.incomingAttacksFromHunter[index]){ //Cancelling attack
                    playerManager.CmdChangeOutgoingAttackToFalse(index);
                    c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                } else {    //Confirming attack
                    playerManager.CmdChangeOutgoingAttackToTrue(index);
                    c4.GetComponent<Image>().color = new Color32(255,0,0,255);
                }
            }
        }
    }

    public void startAttack(){
        if (GameManagerScript.instance.activeSpellId == -1) {
            if (playerManager.isDuck)
            {   
                if(GameManagerScript.instance.isDuckAttackPhase){
                    AudioManager.instance.Play("attack");
                    c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                playerManager.CmdStartAttackDuck();
            } else {
                if(GameManagerScript.instance.isHunterAttackPhase){
                    AudioManager.instance.Play("attack");
                    c0.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c1.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c2.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c3.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    c4.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                }
                playerManager.CmdStartAttackHunter();
            }
        }
    }


}
