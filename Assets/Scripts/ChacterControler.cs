using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterControler : MonoBehaviour
{
    public string right, left;
    public float speed;
    float vx = 0;
    bool RightFlag = true; // 右向きの時True
    bool Moving = false; // 動いているかどうか
    SpriteRenderer character_SR;
    Rigidbody2D rbody;
    Sprite character_r, character_l;

    void Start()
    {
        // 左右向きの画像をそれぞれ取得する
        character_r = Resources.Load<Sprite>(right);
        character_l = Resources.Load<Sprite>(left);
        // 右向きで初期化
        character_SR = this.GetComponent<SpriteRenderer>();
        character_SR.sprite = character_r;
        // Rigidbody2Dの設定
        rbody = this.GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void Update()
    {
        if(Moving){ // 右側か左側が入力されているとき
            if(RightFlag){ // 右
                vx = speed;
            }else{ // 左
                vx = -speed;
            }
        }
    }

    void FixedUpdate()
    {
        if(RightFlag){ // 右向き
            character_SR.sprite = character_r;
        }else{ // 左向き
            character_SR.sprite = character_l;
        }
        rbody.velocity = new Vector2(vx, 0);
    }

    public void MoveRight()
    {
        Moving = true;
        RightFlag = true;
        Debug.Log(Moving + " right"); // for debug
    }

    public void MoveLeft()
    {
        Moving = true;
        RightFlag = false;
        Debug.Log(Moving + " left"); // for debug
    }
    
    public void ButtonRelease()
    {
        Moving = false;
        vx = 0;
        Debug.Log(Moving + " release"); // for debug
    }
}
