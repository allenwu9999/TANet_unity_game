using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReturn_2 : MonoBehaviour
{
    // Start is called before the first frame updatepublic string SceneName;
    public string SceneName;
    public void sceneReturn(){
        SceneManager.LoadScene(SceneName);
        Debug.Log("Go to " + SceneName);
    }
}
