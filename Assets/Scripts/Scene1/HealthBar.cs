using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    Transform bar;
    void Start()
    {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(1f, 1f);
    }
    public void setSize(float nor_size){
        bar.localScale = new Vector3(nor_size, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
