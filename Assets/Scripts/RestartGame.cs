using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
// using UnityEngine.NetworkManager;

public class RestartGame : MonoBehaviour {
    

    // public GameObject NetworkManagerGameObject;

    // public void reset() {

    //     Destroy(NetworkManagerGameObject);
    //     NetworkManager.Shutdown();
    //     // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    //     NetworkManager.Shutdown();
    // NetworkManager networkManager = GameObject.FindObjectOfType<NetworkManager>();
    // Destroy(networkManager.gameObject);

    // }

    // public void DestroyOnLoad() {
        // NetworkManager networkManager = GameObject.FindObjectOfType<NetworkManager>();
        // Destroy(networkManager.gameObject);
        // NetworkManager.instance.dontDestroyOnLoad = false;
        // GameManagerScript.instance.duckHealth = 0;
    // }

    public void Quit() {
        Application.Quit();
    }


}
