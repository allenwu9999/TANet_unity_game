using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingEnemy : MonoBehaviour
{
    public float speed;
    public float chasingSpeed;
    public float distance;
    private bool movingRight = true;
    private bool turnAround = false;
    public Transform groundDetection;
    PlayerController player;
    public float detectionDistance;
    private bool isChasing = false;
    private float nor_health = 1f;
    [SerializeField] private HealthBar healthbar;
    [SerializeField] private float[] attackPower;
    public float leftPosX = 0;
    public float rightPosX = 0;
    private DataToPreserve enemyData;
    [SerializeField] private int DefeatedScores;
    public GameObject projectile;
    public float startTimeBtwShots;
    private float timeBtwShots;
    // Start is called before the first frame update
    void Awake(){
        enemyData = GameObject.FindObjectOfType<DataToPreserve>();
        player = GameObject.FindObjectOfType<PlayerController>();
    }
    void Start()
    {
       //player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //chasing after the player and moving
        if(!isChasing){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            timeBtwShots = 0f;
        }
        else{
            transform.Translate(Vector2.right * chasingSpeed * Time.deltaTime);

            //shooting
            if(timeBtwShots <= 0){
                //GameObject Clone;
                //Vector2 target = new Vector2(transform.position.x + 10, transform.position.y);
			    Instantiate(projectile, transform.position, Quaternion.identity);
                //Clone.transform.eulerAngles = new Vector3(0, 0, 0);
			    timeBtwShots = startTimeBtwShots;
		    }
		    else{
			    timeBtwShots -= Time.deltaTime;
		    }
        }
        if(System.Math.Abs(transform.position.y - player.transform.position.y) < detectionDistance && player.transform.position.x < rightPosX && player.transform.position.x > leftPosX){
            if(player.transform.position.x > transform.position.x && movingRight == false){
                turnAround = true;
            }
            else if(player.transform.position.x < transform.position.x && movingRight == true){
                turnAround = true;
            }
            else{
                turnAround = false;
            }
            isChasing = true;
        }
        else{
            isChasing = false;
        }

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false || turnAround == true){
            if(movingRight == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else{
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        if(nor_health == 0){
            gameObject.SetActive(false);
            enemyData.accumulationScores += DefeatedScores;
            Debug.Log("enemy has been defeated");
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
