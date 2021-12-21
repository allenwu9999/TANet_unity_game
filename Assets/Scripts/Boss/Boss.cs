using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float upDistance;
    public float downDistance;
    public float speed;
    private bool isElevating;
    private float originalPosY;
    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    public float frameRate;
    private SpriteRenderer BossSprite;
    private float nor_health = 1f;
    private HealthBar healthbar;
    public float[] attackPower;
    public float firstHeight;
    public float firstWidth;
    private bool isRaging = false;
    private bool isDead = false;
    public float RagingThreshold;
    public float secondHeight;
    public float secondWidth;
    private Scene_Boss_Manager transitionscene;
    public GameObject[] EnemyBullet;
    private float timeBtwShots;
    public float startTimeBtwShots;

    void Awake(){
        BossSprite = gameObject.GetComponent<SpriteRenderer>();
        healthbar = GameObject.FindObjectOfType<HealthBar>();
        transitionscene = GameObject.FindObjectOfType<Scene_Boss_Manager>();
    }
    void Start()
    {
        originalPosY = transform.position.y;
        isElevating = false;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= frameRate){
            timer -= frameRate;
            if(!isDead){
                if(!isRaging){
                    currentFrame = (currentFrame + 1) % 2;
                    transform.localScale = new Vector2(firstHeight, firstWidth);
                }
                else{
                    currentFrame = (currentFrame + 1) % 2 + 2;
                    transform.localScale = new Vector2(secondHeight, secondWidth);
                }
            }
            else{
                currentFrame = 4;
            }                  
            BossSprite.sprite = frameArray[currentFrame];
        }

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

        //Raging
        if(nor_health < RagingThreshold){
            if(nor_health == 0){
                isRaging = false;
                isDead = true;
                speed = 0;
            }
            isRaging = true;
        }
        if(isDead){
            transitionscene.ToWin();
        }
        if(timeBtwShots <= 0){
            if(isRaging){
                Instantiate(EnemyBullet[0], transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else{
                Instantiate(EnemyBullet[1], transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else{
            timeBtwShots -= Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("Boss is hit by " + other.gameObject.name);
        //detect hits from the player
        if(other.gameObject.name == "bullet(Clone)"){
            nor_health = System.Math.Max(nor_health - attackPower[0], 0);
            healthbar.setSize(nor_health);
        }
        else if(other.gameObject.name == "antivirus(Clone)"){
            nor_health = System.Math.Max(nor_health - attackPower[1], 0);
        }
        else if(other.gameObject.name == "firewall(Clone)"){
            nor_health = System.Math.Max(nor_health - attackPower[2], 0);
        }
    }

}
