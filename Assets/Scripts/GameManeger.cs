using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManeger : MonoBehaviour
{
    public float time; // 1playの秒数
    public float spart_time;
    public Text timerText;
    int seconds;

    public GameObject newPrefab; // 生成するプレハブ
    public float speed1, speed2; // プレハブの落下速度（通常時・ラストスパート時）
    bool spart = false;

    // プレハブ生成関係
    public float interval;
    public float min_interval, max_interval;
    float PrefabTimer = 0f;
    
    // スコア計算関係
    public int score1, score2;
    public Text ScoreText;
    public static int totalScore; // 合計獲得スコア

    void Start()
    {
        InvokeRepeating("CreatePrefab", 0, interval);
        totalScore = 0;
    }

    void Update(){
        // timer関係
        time -= Time.deltaTime;
        seconds = (int)time; // intにキャスト
        timerText.text = seconds.ToString(); // Stringにキャストして表示
        if(time <= spart_time && !spart){ // ラストスパートフラグがオフで残り時間が指定秒以下になったとき
            spart = true;
        }
        if(time <= 0){ // time up後リザルト画面へ
            SceneManager.LoadScene("result");
        }

        // プレハブ生成関係
        PrefabTimer += Time.deltaTime;
        if(PrefabTimer > interval){
            CreatePrefab();
            PrefabTimer = 0f;
            if(!spart){
                interval = Random.Range(min_interval, max_interval);
            }else{
                interval = Random.Range(min_interval/2, max_interval/2);
            }
        }

        // スコア表示
        ScoreText.text = totalScore.ToString();
    }

    void CreatePrefab()
    {
        // 出現位置を設定
        Vector3 spawnArea = GetComponent<SpriteRenderer>().bounds.size;
        Vector3 newPos = this.transform.position;
        newPos.x += Random.Range(-spawnArea.x/2, spawnArea.x/2);
        newPos.y += spawnArea.y/2;

        // プレハブ生成、位置指定、スピード指定
        GameObject target = Instantiate(newPrefab) as GameObject;
        target.transform.position = newPos;
        if(!spart){ // 落ちるスピードとスコアを設定
            target.GetComponent<ItemDrop>().speed = speed1;
            target.GetComponent<ItemDrop>().myPoint = score1;
        }else{
            target.GetComponent<ItemDrop>().speed = speed2;
            target.GetComponent<ItemDrop>().myPoint = score1;
        }
    }
}
