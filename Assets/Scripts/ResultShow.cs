using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultShow : MonoBehaviour
{
    public Text Score;
    
    void Start()
    {
        Score.text = GameManeger.totalScore.ToString() + " Pt";
    }
}
