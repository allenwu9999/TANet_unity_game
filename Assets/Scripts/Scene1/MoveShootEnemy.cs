using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShootEnemy : MonoBehaviour
{
    public float speed;
    PlayerController player;
    private bool isChasing = false;
    private float nor_health = 1f;
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private float[] attackPower;
    private DataToPreserve enemyData;
    [SerializeField] private int DefeatedScores;
    public GameObject projectile;
    public float startTimeBtwShots;
    private float timeBtwShots;
    // Start is called before the first frame update
    public float upDistance;
    public float downDistance;
    private bool isElevating;
    private float originalPosY;
    public float DetectionDistance;
    void Start()
    {
        originalPosY = transform.position.y;
        isElevating = false;
        timeBtwShots = 0f;
    }
    void Awake(){
        enemyData = GameObject.FindObjectOfType<DataToPreserve>();
        player = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //chasing after the player and moving
        //shooting
        float Dist = transform.position.x - player.transform.position.x;
        if(timeBtwShots <= 0 && Dist <= DetectionDistance && Dist >= 0){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else{
            timeBtwShots -= Time.deltaTime;
        }
        if(nor_health == 0){
            gameObject.SetActive(false);
            enemyData.accumulationScores += DefeatedScores;
            Debug.Log("enemy has been defeated");
        }
    }
    void FixedUpdate()
    {
        //float posYnow = transform.position.y;
        if(isElevating){
            transform.Translate(Vector2.up * speed * Time.deltaTime); 
        }
        else{
            transform.Translate(Vector2.down * speed * Time.deltaTime); 
        }

        if(originalPosY - transform.position.y >= downDistance){
            isElevating = true;
        }
        else if(transform.position.y - originalPosY >= upDistance){
            isElevating = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.gameObject.name);
        //detect hits from the player
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
    }
}
