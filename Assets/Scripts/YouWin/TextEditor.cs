using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEditor : MonoBehaviour
{
    DataToPreserve PlayerData;
    public Text Scores;
    void Awake()
    {
        PlayerData = FindObjectOfType<DataToPreserve>();
    }

    // Update is called once per frame
    void Update()
    {
        Scores.text = "Scores : " + PlayerData.accumulationScores.ToString();
    }
}
