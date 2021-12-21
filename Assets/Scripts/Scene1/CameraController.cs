using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float cameraDistance = 30f;
    private float posY;
    public float bottomPosY;
    public float topPosY;
    public float ElevatingPosX;
    void Awake(){
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height /2) / cameraDistance);
    }
    void Start()
    {
        //transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            posY = System.Math.Max(player.position.y, bottomPosY);
            if(player.position.x <= ElevatingPosX){
                posY = System.Math.Min(posY, topPosY);
            }
            transform.position = new Vector3(player.position.x, posY, -10);  
        //Debug.Log("Now the camera's position of x is" + transform.position.x);
    }
}
