using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;


public class CardClick : MonoBehaviour, IPointerClickHandler
{   
    public GameObject Card;
    //private bool alreadyClicked;
    private GameObject duplicate;
    public bool counter;
    public HandZone handZone;
    public FieldZone fieldZone;
    public GameObject ps; 
    public int currentCanvasChildren;
    public int canvasChildren;


    public void OnPointerClick(PointerEventData eventData) {
        if (handZone.cursorCheck == 1){
            
                if (eventData.button == PointerEventData.InputButton.Right){
                    if (counter){     
                        if (currentCanvasChildren == canvasChildren){                
                            duplicate = Instantiate(Card, new Vector3(800, 600, 0), transform.rotation );  //creates a duplicate of the card on the mouse (this duplicate will be dragged instead)
                            duplicate.transform.SetParent(this.transform.parent.parent);  //sets the current location as the return location if placed anywhere outside of the field
                            duplicate.transform.localScale = new Vector3 (1f, 1f, 0);
                            Card.GetComponent<Image>().color = new Color32(0 , 254 , 111, 255 );
                            duplicate.GetComponent<CanvasGroup>().blocksRaycasts = false;
                            counter = false;
                        }
                    }
                    else if (counter == false){
                        Destroy(duplicate);
                        counter = true;
                        Card.GetComponent<Image>().color = new Color32(202, 144, 60 , 255);
                    }
                
        }
        }

    }

    public void onClick() {
        /*
        if (handZone.cursorCheck == 1){
            if (currentCanvasChildren == canvasChildren){
                if (!alreadyClicked) {
                    Card.transform.position += new Vector3(0, 180, 0);
                    alreadyClicked = true;
                } else{
                    Card.transform.position += new Vector3(0, -180, 0);
                    alreadyClicked = false;
                }
            }
        }*/
        
    }
    
    
    void Start(){
        //alreadyClicked = false;
        counter = true;
        ps = GameObject.Find("Main Canvas");
        canvasChildren = ps.transform.childCount;
    }

    void Update(){
        currentCanvasChildren = ps.transform.childCount; 
    }
}

