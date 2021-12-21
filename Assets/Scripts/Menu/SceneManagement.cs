using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    // code for test
    private DataToPreserve playerData;
    private void Awake() {
        playerData = FindObjectOfType<DataToPreserve>();
    }
    public void SceneTransition(){
        playerData.playAgain();
        SceneManager.LoadScene("Scene1");
        Debug.Log("Now Play!");
    }
    public void sceneToInstruction(){
        SceneManager.LoadScene("Instruction");
        Debug.Log("Go to guide");
    }

}
