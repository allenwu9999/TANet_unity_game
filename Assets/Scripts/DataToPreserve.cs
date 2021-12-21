using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataToPreserve : MonoBehaviour
{
    // Start is called before the first frame update
    static DataToPreserve instance;
    public Color eyeColor;
    public int PlayerLives;
    public int PlayerRemainingLives;
    public bool PlayerIsDead = false;
    private bool IsStarted = false;
    public int accumulationScores = 0;
    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(gameObject);
            Debug.Log("A gameobject has been destroyed");
        }
        PlayerRemainingLives = PlayerLives;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerRemainingLives == 0){
            PlayerIsDead = true;
        }
    }
    public void resetLives(){
        //Debug.Log("Player lives now : " + PlayerRemainingLives);
        //Debug.Log("max lives : " + PlayerLives);
        if(!IsStarted){
            PlayerRemainingLives = PlayerLives;
            PlayerIsDead = false;
            accumulationScores = 0;
            IsStarted = true;
        }
        //Debug.Log("Now the lives remaining : " + PlayerRemainingLives);
    }
    public void playAgain(){
        IsStarted = false;
    }
}
