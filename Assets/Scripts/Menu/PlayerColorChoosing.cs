using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChoosing : MonoBehaviour
{
    // Start is called before the first frame update
    private DataToPreserve data;
    public GameObject panel;
    public SpriteRenderer head;
    public SpriteRenderer mouth;
    public Color[] colors;
    public int whatColor;
    
    public void ChangePanelState(bool state){
        panel.SetActive(state);
    }
    void Awake(){
        data = FindObjectOfType<DataToPreserve>();
    }
    void Start()
    {
        panel.SetActive(false);
        whatColor = 3;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0 ; i < colors.Length ; i++){
            if(i == whatColor){
                head.color = colors[i];
                mouth.color = colors[i];
                data.eyeColor = colors[i];
            }
        }
    }
    public void changeHeadColor(int index){
        whatColor = index;
    }
}
