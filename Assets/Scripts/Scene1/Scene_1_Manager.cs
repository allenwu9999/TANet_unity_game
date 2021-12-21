using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene_1_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    DataToPreserve changescenedata;
    public Text lives;
    public Text scores;
    public Text time;
    private float timeCounter;
    public float maxTime;
    public Enemy[] enemies;
    public shootingEnemy[] shootingEnemies;
    public LandAttack[] landAttacks;
    public MoveShootEnemy[] MoveShootEnemies;
    public EnemyDos[] DosEnemies;
    public EnemyDDoS DDoSEnemies;
    void Awake(){
        changescenedata = FindObjectOfType<DataToPreserve>();
    }
    void Start()
    {
        timeCounter = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;
        lives.text = "Lives : " + changescenedata.PlayerRemainingLives.ToString();
        scores.text = "Scores : " + changescenedata.accumulationScores.ToString();
        time.text = "Time : " + (System.Math.Round(timeCounter)).ToString();
        if(changescenedata.PlayerIsDead == true){
            SceneManager.LoadScene("GameOver");
            Debug.Log("You are dead!");
        }
        if(timeCounter <= 0){
            timeCounter = 0;
            SceneManager.LoadScene("Gameover");
        }
    }
    public void resetEnemy(){
        for(int i = 0 ; i < enemies.Length ; i++){
            if(enemies[i].gameObject.activeSelf == false)
                enemies[i].resetEnemy();
        }
        for(int i = 0 ; i < shootingEnemies.Length ; i++){
            if(shootingEnemies[i].gameObject.activeSelf == false)
                shootingEnemies[i].resetEnemy();
        }
        for(int i = 0 ; i < MoveShootEnemies.Length ; i++){
            if(MoveShootEnemies[i].gameObject.activeSelf == false)
                MoveShootEnemies[i].resetEnemy();
        }
        for(int i = 0 ; i < DosEnemies.Length ; i++){
            DosEnemies[i].resetEnemy();
        }
        if(DDoSEnemies.gameObject.activeSelf == false)
            DDoSEnemies.resetEnemy();
    }
    public void resetBrick(){
        for(int i = 0 ; i < landAttacks.Length ; i++){
            landAttacks[i].resetBrick();
        }
    }
    public void resetDos(){
        for(int i = 0 ; i < DosEnemies.Length ; i++){
            DosEnemies[i].resetDetection();
        }
        DDoSEnemies.resetSpawnNum();
    }
}
