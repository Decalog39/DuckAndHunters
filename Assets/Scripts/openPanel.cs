using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPanel : MonoBehaviour
{
    public GameObject gameObject;
    bool active;

    public void OpenPanel()
    {
        if (active == false)
        {
            gameObject.transform.gameObject.SetActive(true);
            active = true;
        }
        else
        {
            gameObject.transform.gameObject.SetActive(false);
            active = false;
        }
    }

}
