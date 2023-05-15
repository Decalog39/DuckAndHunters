using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndScene : MonoBehaviour
{

    public TextMeshProUGUI duckStatus;
    public TextMeshProUGUI hunterStatus;

    // Start is called before the first frame update
    void Start()
    {

        if(GameManagerScript.instance.duckHealth <= 0) {
            duckStatus.text = "Loser";
            hunterStatus.text = "Winner";
        }

        else if(GameManagerScript.instance.hunterHealth <= 0) {
            duckStatus.text = "Winner";
            hunterStatus.text = "Loser";
        }

    
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
