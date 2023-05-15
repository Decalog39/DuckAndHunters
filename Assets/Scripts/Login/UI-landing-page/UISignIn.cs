using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignIn : MonoBehaviour
{
    string username, password;

    public void UpdateUsername(string _username)
    {
        username = _username;
        Debug.Log($"Username Changed : {username} (signIn)");

    }
    public void UpdatePassword(string _password)
    {
        password = _password;
        Debug.Log($"Password Changed: {password} (signIn)");
    }

    public void SignIn()
    {
        UserAccountManager.Instance.SignIn(username, password);
    }
}