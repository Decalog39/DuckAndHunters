using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionChoice : MonoBehaviour {

    public bool isDuck;
    
    void Awake() {    
        isDuck = false;
        DontDestroyOnLoad(gameObject);
    }

    public void selectDucks() {
        isDuck = true;
        disableFactionSelectionUI();
    }

    public void selectHunters()
    {
        Debug.Log("Hunters Chosen");
        isDuck = false;
        disableFactionSelectionUI();
    }

    private void disableFactionSelectionUI()
    {
        Transform[] transforms = GetComponentsInChildren<Transform>();

        foreach (Transform t in transforms)
        {
            if (t.gameObject.name != "FactionSelection")
                t.gameObject.SetActive(false);
        }
    }


}
