using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRegister : MonoBehaviour
{
    string username, password, emailAddress;

    public void UpdateUsername(string _username)
    {
        username = _username;
        Debug.Log($"Username Changed: {username}");

    }
    public void UpdatePassword(string _password)
    {
        password = _password;
        Debug.Log($"Password Changed: {password}");
    }
    public void UpdateEmailAddress(string _emailAddress)
    {
        emailAddress = _emailAddress;
        Debug.Log($"email Changed: {emailAddress}");
    }

    public void CreateAccount()
    {
        UserAccountManager.Instance.CreateAccount(username, emailAddress, password);
    }
}