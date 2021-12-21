using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    // Start is called before the first frame update
    DataToPreserve data;
    public SpriteRenderer eyes;
    public SpriteRenderer mouth;
    void Awake(){
        data = FindObjectOfType<DataToPreserve>();
    }
    void Start()
    {
        eyes.color = data.eyeColor;
        mouth.color = data.eyeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
