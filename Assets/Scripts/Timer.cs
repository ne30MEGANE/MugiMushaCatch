using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time; // 1playの秒数

    void Update(){
        time -= Time.deltaTime;
        if(time <= 0){ // time up後リザルト画面へ
            SceneManager.LoadScene("result");
        }
    }
}
