using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_Boss_Manager : MonoBehaviour
{
    DataToPreserve changescenedata;
    public Text lives;
    void Awake(){
        changescenedata = FindObjectOfType<DataToPreserve>();
    }
    void Start()
    {
        //Debug.Log("Player remaining lives : " + changescenedata.PlayerRemainingLives);
    }

    // Update is called once per frame
    void Update()
    {
        lives.text = "Lives : " + changescenedata.PlayerRemainingLives.ToString();
        if(changescenedata.PlayerIsDead == true){
            SceneManager.LoadScene("GameOver");
            Debug.Log("You are dead!");
        }
    }
    public void ToWin(){
        SceneManager.LoadScene("YouWin");
    }
}
