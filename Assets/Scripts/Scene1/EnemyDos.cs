using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDos : MonoBehaviour
{
    // Start is called before the first frame update
    public float chasingSpeed;
    public float detectiondDistance;
    PlayerController player;
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private float[] attackPower;
    private float nor_health = 1f;
    [SerializeField] private int DefeatedScores;
    //private Vector2 target;
    DataToPreserve enemyData;
    private bool EnemyHasDetected = false;
    public Sprite Laughing;
    public Sprite Angrying;
    [SerializeField] private SpriteRenderer EnemySprite;
    private Vector2 startPoint;
    void Start()
    {
        enemyData = FindObjectOfType<DataToPreserve>();
        player = FindObjectOfType<PlayerController>();
        EnemySprite.sprite = Angrying;
        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerIsDetected()){
            //if(PlayerIsLookingAt() == false){
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chasingSpeed * Time.deltaTime);
            //    EnemySprite.sprite = Angrying;
            //    EnemySprite.transform.localScale = new Vector2(1f, 1f);
            //} 
            //else{
            //    EnemySprite.sprite = Laughing;
            //    EnemySprite.transform.localScale = new Vector2(0.5f, 0.5f);
            //    transform.position = transform.position;
            //}
        }
        if(nor_health == 0){
            gameObject.SetActive(false);
            enemyData.accumulationScores += DefeatedScores;
            Debug.Log("enemy has been defeated");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "bullet(Clone)"){
            nor_health = System.Math.Max(nor_health - attackPower[0], 0);
            healthbar.setSize(nor_health);
        }
        else if(other.gameObject.name == "antivirus(Clone)"){
            nor_health = System.Math.Max(nor_health - attackPower[1], 0);
            healthbar.setSize(nor_health);
        }
        else if(other.gameObject.name == "firewall(Clone)"){
            nor_health = System.Math.Max(nor_health - attackPower[2], 0);
            healthbar.setSize(nor_health);
        }
    }
    public void resetEnemy(){
        gameObject.SetActive(true);
        nor_health = 1f;
        healthbar.setSize(nor_health);
        resetDetection();
    }
    private bool PlayerIsDetected(){
        if(Vector2.Distance(transform.position, player.transform.position) < detectiondDistance || EnemyHasDetected == true){
            EnemyHasDetected = true;
            return true;
        }
        else{
            return false;
        }
    }
    private bool PlayerIsLookingAt(){
        //Debug.Log("enemy : " + transform.position.x + "player : " + player.transform.position.x);
        if((player.IsFacingRight() && transform.position.x - player.transform.position.x >= 0) || (!player.IsFacingRight() && transform.position.x - player.transform.position.x <= 0)){
            return true;
        }
        else{
            return false;
        }
    }
    public void resetDetection(){
        EnemyHasDetected = false;
        transform.position = startPoint;
    }
}
