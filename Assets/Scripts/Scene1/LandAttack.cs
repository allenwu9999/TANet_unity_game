using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandAttack : MonoBehaviour
{
    // Start is called before the first frame update
    private bool toCountDown = false;
    public float timeToDisappear;
    private float remainingTime;
    private float halfPlatformLength = 3.1f;
    void Start()
    {
        remainingTime = timeToDisappear;
    }

    // Update is called once per frame
    void Update()
    {
        if(toCountDown){
            remainingTime -= Time.deltaTime;
            if(remainingTime <= 0){
                gameObject.SetActive(false);
            }
        }
    }
    // private void OnCollisionEnter2D(Collision2D other) {
        
    // }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            // Debug.Log(System.Math.Abs(other.transform.position.x - this.transform.position.x));
            // Debug.Log(other.transform.position.y > this.transform.position.y);
            if(other.transform.position.y > this.transform.position.y && System.Math.Abs(other.transform.position.x - this.transform.position.x) < halfPlatformLength){
                Debug.Log("it should disappear");
                toCountDown = true;
            }
        }
    }
    public void resetBrick(){
        gameObject.SetActive(true);
        toCountDown = false;
        remainingTime = timeToDisappear;
    }
}
