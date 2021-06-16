using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayStart : MonoBehaviour
{
    public string sceneName;

    void Update()
    {
        foreach (Touch t in Input.touches)
        {
            if(t.phase == TouchPhase.Began){ // タッチされた瞬間に
                var ray = Camera.main.ScreenToWorldPoint(t.position); // タッチの位置からレイを飛ばす
                var hit = Physics2D.Raycast(ray, Vector2.zero); // 2D用のレイキャスト（ぶつかったオブジェクトの情報とか持ってる）
                if(hit.collider.gameObject.name ==this.name){ // ぶつかったオブジェクトの名前が自分と同じだったら
                    SceneManager.LoadScene(sceneName); // シーン遷移
                }
            }
        }
    }
}
