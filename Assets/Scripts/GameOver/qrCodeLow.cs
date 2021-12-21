using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qrCodeLow : MonoBehaviour
{
    private SpriteRenderer qrCode;
    DataToPreserve gameOverData;
    [SerializeField] private Sprite[] qrCodeArray;
    public int ScoreLine;
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
        if(finalScores < ScoreLine){
            qrCode.sprite = qrCodeArray[0];
        }
        else{
            qrCode.sprite = qrCodeArray[1];
        }
    }
}
