using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRetry : MonoBehaviour
{
    // Start is called before the first frame update
    public void sceneRetry(){
        SceneManager.LoadScene("Menu");
        Debug.Log("Now try again!");
    }
}
