using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//make sure the login was a success here because this is only used when switching between menu and game for now
public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID) {
        SceneManager.LoadScene(sceneID);
    }
}
