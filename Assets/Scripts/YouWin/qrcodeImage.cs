using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qrcodeImage : MonoBehaviour
{
    private SpriteRenderer qrCode;
    DataToPreserve gameOverData;
    [SerializeField] private Sprite[] qrCodeArray;
    public int ScoreLine1, ScoreLine2;
    private int finalScores;
    // Start is called before the first frame update
    void Start()
    {
        qrCode = gameObject.GetComponent<SpriteRenderer>();
        gameOverData = FindObjectOfType<DataToPreserve>();
        finalScores = gameOverData.accumulationScores;
    }

    // Update is called once per frame
    void Update()
    {
        if(finalScores < ScoreLine1){
            qrCode.sprite = qrCodeArray[0];
        }
        else{
            if(finalScores < ScoreLine2){
                qrCode.sprite = qrCodeArray[1];
            }
            else{
                qrCode.sprite = qrCodeArray[2];
            }
        }
    }
}
