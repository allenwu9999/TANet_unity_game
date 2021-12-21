using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToOver : MonoBehaviour
{
    // Start is called before the first frame update
    DataToPreserve changescenedata;
    void Awake(){
        changescenedata = FindObjectOfType<DataToPreserve>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(changescenedata.PlayerIsDead == true){
            SceneManager.LoadScene("GameOver");
            Debug.Log("You are dead!");
        }
    }
}
