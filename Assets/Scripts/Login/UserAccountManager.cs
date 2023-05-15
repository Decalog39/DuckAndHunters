using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class UserAccountManager : MonoBehaviour
{

    public static UserAccountManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void CreateAccount(string username, string emailAddress, string password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(
            new RegisterPlayFabUserRequest()
            {
                Email = emailAddress,
                Password = password,
                Username = username,
                RequireBothUsernameAndEmail = true
            },
            respones =>
            {
                Debug.Log($"Successful Account Creation: {username}, {emailAddress}");
                SignIn(username, password);
            },
            error =>
            {
                Debug.Log($"Unsuccessful Account Creation: {username}, {emailAddress} \n {error.ErrorMessage}");
            }
        );
    }

    public void SignIn(string username, string password)
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
        {
            Username = username,
            Password = password
        },
        response =>
        {
            Debug.Log($"Successful Account Login: {username}");
        },
        error => {
            Debug.Log($"Unsuccessful Account Login: {username} \n {error.ErrorMessage}");
        });
    }
}