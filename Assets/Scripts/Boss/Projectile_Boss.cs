using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector3 Scaler;
    private Vector2 target;
    private Vector2 initialPos;
    private Vector2 originalPos;
    public float flyingDistance;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
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
            DestroyProjectile();
        }
    }
}
