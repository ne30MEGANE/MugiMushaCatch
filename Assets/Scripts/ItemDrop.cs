using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public float speed1, speed2;
    Rigidbody2D rbody;
    public string stage, player;

    void Start()
    {
        // Rigidbody設定
        rbody = this.GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        rbody.velocity = new Vector2(0, -speed1);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == stage){ // 床に落ちた時
            this.gameObject.SetActive(false); // 非表示にする
        }else if(collision.gameObject.name == player){ // プレイヤーが拾ったとき
            this.gameObject.SetActive(false); // 非表示にする
        }
    }
}
