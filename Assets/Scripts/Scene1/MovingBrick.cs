using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBrick : MonoBehaviour
{
    // Start is called before the first frame update
    public float upDistance;
    public float downDistance;
    public float speed;
    private bool isElevating;
    private float originalPosY;
    void Start()
    {
        originalPosY = transform.position.y;
        isElevating = false;
    }

    // Update is called once per frame
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
}
