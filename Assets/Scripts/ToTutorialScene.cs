using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//same as ChangeScene script, only for moving to TutorialScene
public class ToTutorialScene : MonoBehaviour
{
    public void MoveToScene()
    {
        SceneManager.LoadScene(sceneName: "TutorialScene");
    }
}