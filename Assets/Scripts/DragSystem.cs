using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class DragSystem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    public GameObject spellCard;
    public GameObject thisCard;
    public GameObject field;
    public GameObject listss;
    public FieldZone fieldZone;
    private GameObject duplicate;
    public int cardID;
    public int index;
    public List<int> asd;
    public PlayerHandDeckManager lists;
    public static bool dragPhase;
    public int currentCanvasChildren;
    public int canvasChildren;
    public int spellID;
    public GameObject ps;
    public bool drag;

    System.Random rnd = new System.Random();
    public int counter = 0;
    public int selectedId;

    public GameObject field1;
    public GameObject field2;
    public GameObject field3;
    public GameObject field4;
    public GameObject field5;
    public GameObject efield1;
    public GameObject efield2;
    public GameObject efield3;
    public GameObject efield4;
    public GameObject efield5;


    public void OnBeginDrag(PointerEventData eventData){
        if (GameManagerScript.instance.activeSpellId == -1) {
            if(playerManager.isDuck){
                if (currentCanvasChildren == canvasChildren){
                if(GameManagerScript.instance.isDuckDragPhase){
                    //gets the ID of the card which is dragged
                    if(playerManager.isDuck){
                        cardID = GameManagerScript.instance.handDuck[index]; 
                    } 
                    duplicate = Instantiate(thisCard); //creates a duplicate of the card on the mouse (this duplicate will be dragged instead)
                    thisCard.transform.localScale = new Vector3(0, 0, 0); //the real card is turned off (invisible)
                    duplicate.GetComponent<CanvasGroup>().blocksRaycasts = false; //allows the mouse to detect the field when hovering
                    duplicate.transform.SetParent(this.transform.parent.parent);  //sets the current location as the return location if placed anywhere outside of the field
                    duplicate.transform.localScale = new Vector3(0.4103771f, 0.4103771f, 0); //resizes the duplicate to be the same size as the original card
                    drag = true;
                }
            }
            } else {
                if (currentCanvasChildren == canvasChildren){
                if(GameManagerScript.instance.isHunterDragPhase){
                    //gets the ID of the card which is dragged
                    if(!playerManager.isDuck){
                        cardID = GameManagerScript.instance.handHunter[index]; 
                    } 
                    duplicate = Instantiate(thisCard); //creates a duplicate of the card on the mouse (this duplicate will be dragged instead)
                    thisCard.transform.localScale = new Vector3(0, 0, 0); //the real card is turned off (invisible)
                    duplicate.GetComponent<CanvasGroup>().blocksRaycasts = false; //allows the mouse to detect the field when hovering
                    duplicate.transform.SetParent(this.transform.parent.parent);  //sets the current location as the return location if placed anywhere outside of the field
                    duplicate.transform.localScale = new Vector3(0.4103771f, 0.4103771f, 0); //resizes the duplicate to be the same size as the original card
                    drag = true;
                }
            }
            }
        }
    }

    public void OnDrag(PointerEventData eventData){
        if (drag){
            if(playerManager.isDuck){
                if(GameManagerScript.instance.isDuckDragPhase){
                duplicate.transform.position = eventData.position; //allows the card (duplicate) to be dragged
                }
            } else {
                if(GameManagerScript.instance.isHunterDragPhase){
                duplicate.transform.position = eventData.position; //allows the card (duplicate) to be dragged
                }
        }
        }
    }
    
     public void OnEndDrag(PointerEventData eventData){
        if(playerManager.isDuck){
            if (drag){
                if(GameManagerScript.instance.isDuckDragPhase){
                    if (GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[index]].cost <= playerManager.currentMana){
                        duplicate.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Destroy(duplicate); //destroys the duplicate
                        thisCard.transform.localScale = new Vector3(0.4103771f, 0.4103771f, 0); //display (turn back on) the real card
                        if(((GameManagerScript.instance.fieldDuck.Count != 0 && GameManagerScript.instance.fieldHunter.Count != 0) &&
                            (cardID == 23 || cardID == 24 || cardID == 26 || cardID == 28 || cardID == 29) && fieldZone.cursorCheck == 1) ||
                         (fieldZone.cursorCheck == 1 && (cardID != 23 && cardID != 24 && cardID != 26 && cardID != 28 && cardID != 29))){ //When you drop it in the field zone (1). The cursorCheck checks where the card is placed (1 = field = anywhere else)
                            playerManager.currentMana = playerManager.currentMana - GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handDuck[index]].cost;
                            AudioManager.instance.Play("cardplaced");
                            play(cardID); // if in field, play() is called. Else, card is returned to its original position in the hand
                        }
                    } 
                    else{
                        Destroy(duplicate); //destroys the duplicate
                        thisCard.transform.localScale = new Vector3(0.4103771f, 0.4103771f, 0); 
                    }
                }
            }
        } else {
            if (drag){
                if(GameManagerScript.instance.isHunterDragPhase){
                    if (GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[index]].cost <= playerManager.currentMana){
                        duplicate.GetComponent<CanvasGroup>().blocksRaycasts = true;
                        Destroy(duplicate); //destroys the duplicate
                        thisCard.transform.localScale = new Vector3(0.4103771f, 0.4103771f, 0); //display (turn back on) the real card
                        if(((GameManagerScript.instance.fieldDuck.Count != 0 && GameManagerScript.instance.fieldHunter.Count != 0) &&
                            (cardID == 53 || cardID == 54 || cardID == 55 || cardID == 58 || cardID == 59) && fieldZone.cursorCheck == 1) ||
                         (fieldZone.cursorCheck == 1 && (cardID != 53 && cardID != 54 && cardID != 55 && cardID != 58 && cardID != 59))){ //When you drop it in the field zone (1). The cursorCheck checks where the card is placed (1 = field = anywhere else)
                            playerManager.currentMana = playerManager.currentMana - GameManagerScript.instance.cardDatabase[GameManagerScript.instance.handHunter[index]].cost;
                            AudioManager.instance.Play("cardplaced");
                            play(cardID); // if in field, play() is called. Else, card is returned to its original position in the hand
                        }
                    } 
                    else{
                        Destroy(duplicate); //destroys the duplicate
                        thisCard.transform.localScale = new Vector3(0.4103771f, 0.4103771f, 0); 
                    }
                }
            }
        }
      drag = false;
     }
    

    
    // Start is called before the first frame update
    void Start()
    {
        field = GameObject.Find("Field Panel");
        listss = GameObject.Find("Deck");
        fieldZone = field.GetComponent<FieldZone>();
        lists = listss.GetComponent<PlayerHandDeckManager>();
        index = this.transform.GetSiblingIndex();
        asd = lists.hand;
        ps = GameObject.Find("Main Canvas");
        canvasChildren = ps.transform.childCount;
        drag = false;
    }

    // Update is called once per frame
    void Update()
    {
         currentCanvasChildren = ps.transform.childCount; 
    }

    public void play(int cardID){

        playerManager.CmdApplySpecialEffects(cardID, index);

        
    }

    public void spellTarget(GameObject thisCard){
        spellID = GameManagerScript.instance.activeSpellId;
        //Debug.Log(spellID);
        if (spellID != -1){
            if (playerManager.isDuck && GameManagerScript.instance.isDuckDragPhase) {
                if (thisCard == field1){
                        selectedId = GameManagerScript.instance.fieldDuck[0];
                }
                else if (thisCard == field2){
                    selectedId = GameManagerScript.instance.fieldDuck[1];
                }
                else if (thisCard == field3){
                    selectedId = GameManagerScript.instance.fieldDuck[2];
                }
                else if (thisCard == field4){
                    selectedId = GameManagerScript.instance.fieldDuck[3];
                }
                else if (thisCard == field5){
                    selectedId = GameManagerScript.instance.fieldDuck[4];
                }
                else if (thisCard == efield1){
                    selectedId = GameManagerScript.instance.fieldHunter[0];
                }
                else if (thisCard == efield2){
                    selectedId = GameManagerScript.instance.fieldHunter[1];
                }
                else if (thisCard == efield3){
                    selectedId = GameManagerScript.instance.fieldHunter[2];
                }
                else if (thisCard == efield4){
                    selectedId = GameManagerScript.instance.fieldHunter[3];
                }
                else if (thisCard == efield5){
                    selectedId = GameManagerScript.instance.fieldHunter[4];
                }
                playerManager.targetSpellEffects(selectedId, spellID);
                playerManager.CmdChangeActiveSpellId(-1);
            }
            else if(!playerManager.isDuck && GameManagerScript.instance.isHunterDragPhase) {
                if (thisCard == field1){
                        selectedId = GameManagerScript.instance.fieldHunter[0];
                }
                else if (thisCard == field2){
                    selectedId = GameManagerScript.instance.fieldHunter[1];
                }
                else if (thisCard == field3){
                    selectedId = GameManagerScript.instance.fieldHunter[2];
                }
                else if (thisCard == field4){
                    selectedId = GameManagerScript.instance.fieldHunter[3];
                }
                else if (thisCard == field5){
                    selectedId = GameManagerScript.instance.fieldHunter[4];
                }
                else if (thisCard == efield1){
                    selectedId = GameManagerScript.instance.fieldDuck[0];
                }
                else if (thisCard == efield2){
                    selectedId = GameManagerScript.instance.fieldDuck[1];
                }
                else if (thisCard == efield3){
                    selectedId = GameManagerScript.instance.fieldDuck[2];
                }
                else if (thisCard == efield4){
                    selectedId = GameManagerScript.instance.fieldDuck[3];
                }
                else if (thisCard == efield5){
                    selectedId = GameManagerScript.instance.fieldDuck[4];
                }
                playerManager.targetSpellEffects(selectedId, spellID);
                playerManager.CmdChangeActiveSpellId(-1);
            }
            
            
        }             
    }


    public void endDragPhase(){
        if (GameManagerScript.instance.activeSpellId == -1) {
            if (playerManager.isDuck)
            {
                playerManager.CmdEndDragPhaseDuck();
            } else
            {
                playerManager.CmdEndDragPhaseHunter();
            }
        }
    }
}
