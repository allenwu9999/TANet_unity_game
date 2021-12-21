using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 target;
    public float flyingDistance;
    public bool isMovingRight;
    private Vector3 Scaler;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player.transform.position.x >= transform.position.x){
            target = new Vector2(transform.position.x + flyingDistance, transform.position.y);
            //Debug.Log("Now the enemy's bullet is moving right");
        }
        else{
            target = new Vector2(transform.position.x - flyingDistance, transform.position.y);
            //Debug.Log("Now the enemy's bullet is moving left");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

         if(transform.position.x == target.x && transform.position.y == target.y){
             DestroyProjectile();
         }
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            //Debug.Log("a bullet has collided on the player!");
            DestroyProjectile();
        }
        else if(other.gameObject.tag == "MovingPlatform"){
            DestroyProjectile();
        }
    }
}
