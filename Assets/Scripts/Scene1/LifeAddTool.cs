using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAddTool : MonoBehaviour
{
    // Start is called before the first frame update
    DataToPreserve lifedata;
    void Start()
    {
        lifedata = GameObject.FindObjectOfType<DataToPreserve>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            lifedata.PlayerRemainingLives += 1;
            gameObject.SetActive(false);
        }  
        else if(other.gameObject.tag == "MovingPlatform"){
            this.transform.parent = other.transform;
        }
    }
}
