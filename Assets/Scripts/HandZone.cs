using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandZone : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public int cursorCheck = 0;

    public void OnPointerEnter(PointerEventData eventData){
        cursorCheck = 1;
    }

    public void OnPointerExit(PointerEventData eventData){
        cursorCheck = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
