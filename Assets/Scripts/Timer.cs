using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time; // 1playの秒数
    public Text timerText;
    int seconds;


    void Update(){
        time -= Time.deltaTime;
        seconds = (int)time; // intにキャスト
        timerText.text = seconds.ToString(); // Stringにキャストして表示

        if(time <= 0){ // time up後リザルト画面へ
            SceneManager.LoadScene("result");
        }
    }
}
