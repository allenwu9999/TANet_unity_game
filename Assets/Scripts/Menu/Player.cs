using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public static Player instance; 
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(this != instance){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
