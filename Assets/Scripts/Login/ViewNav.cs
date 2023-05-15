using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewNav : MonoBehaviour
{
    //public GameObject InitialPageCanvas;
    public CanvasGroup mainMenuPanel;
    public CanvasGroup loginPanel;
    public CanvasGroup registerPanel;
    public CanvasGroup testContainer;

    //private void Awake()
    //{
    //    goToMainMenuPanel();
    //}

    public void goToMainMenuPanel()
    {
        Debug.Log("goToMainMenuPanel clicked");
        mainMenuPanel.alpha = 1;
        loginPanel.alpha = 0;
        registerPanel.alpha = 0;

        mainMenuPanel.interactable = true;
        loginPanel.interactable = false;
        registerPanel.interactable = false;

        mainMenuPanel.blocksRaycasts = true;
        loginPanel.blocksRaycasts = false;
        registerPanel.blocksRaycasts = false;
    }

    public void goToLoginPanel()
    {
        Debug.Log("goToLoginPanel clicked");
        mainMenuPanel.alpha = 0;
        loginPanel.alpha = 1;
        registerPanel.alpha = 0;


        mainMenuPanel.interactable = false;
        loginPanel.interactable = true;
        registerPanel.interactable = false;

        mainMenuPanel.blocksRaycasts = false;
        loginPanel.blocksRaycasts = true;
        registerPanel.blocksRaycasts = false;
    }

    public void goToRegisterPanel()
    {
        Debug.Log("goToRegisterPanel clicked");
        mainMenuPanel.alpha = 0;
        loginPanel.alpha = 0;
        registerPanel.alpha = 1;


        mainMenuPanel.interactable = false;
        loginPanel.interactable = false;
        registerPanel.interactable = true;


        mainMenuPanel.blocksRaycasts = false;
        loginPanel.blocksRaycasts = false;
        registerPanel.blocksRaycasts = true;

    }

    bool flag = true;
    public void buttonTest()
    {
        flag = !flag;
        if (!flag)
        {
            testContainer.interactable = false;
            testContainer.blocksRaycasts = true;
            testContainer.alpha = 0;
        }
        else
        {
            testContainer.interactable = true;
            testContainer.blocksRaycasts = false;
            testContainer.alpha = 1;
        }
        Debug.Log("button works");
    }
}