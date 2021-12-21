using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector3 Scaler;
    private Vector2 target;
    public float flyingDistance;
    void Start()
    {
        Scaler = GameObject.FindGameObjectWithTag("Player").transform.localScale;
        if(Scaler.x >= 0){
            target = new Vector2(transform.position.x + flyingDistance, transform.position.y);
        }
        else{
            target = new Vector2(transform.position.x - flyingDistance, transform.position.y);
        }
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
        if(other.gameObject.tag == "Enemy"){
            DestroyProjectile();
        }
    }
}
