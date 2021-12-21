using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBrickLR : MonoBehaviour
{
    // Start is called before the first frame update
    public float LeftDistance;
    public float RightDistance;
    public float speed;
    private bool isMovingRight;
    private float originalPosX;
    void Start()
    {
        originalPosX = transform.position.x;
        isMovingRight = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float posXnow = transform.position.y;
        if(isMovingRight){
            transform.Translate(Vector2.right * speed * Time.deltaTime); 
        }
        else{
            transform.Translate(Vector2.left * speed * Time.deltaTime); 
        }

        if(originalPosX - transform.position.x >= LeftDistance){
            isMovingRight = true;
        }
        else if(transform.position.x - originalPosX >= RightDistance){
            isMovingRight = false;
        }
    }
}
