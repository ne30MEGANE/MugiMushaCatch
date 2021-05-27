using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacterControler : MonoBehaviour
{
    public string right, left;
    public float speed;
    float vx = 0;
    bool RightFlag = true; // 右向きの時True
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
        vx = 0;
        if(Input.GetKey("right")){
            RightFlag = true;
            vx = speed;
        }
        if(Input.GetKey("left")){
            RightFlag = false;
            vx = -speed;
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
}
