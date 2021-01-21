using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float speed = 6f;                //歩くスピード
    public float jumpForce = 0f;       //ジャンプするときに加える力
    public float jumpThreshold = 1.0f;    //ジャンプ中か判定するための閾値
    public float runForce = 10.0f;       // 走り始めに加える力
    public float runSpeed = 0.5f;       // 走っている間の速度
    public float runThreshold = 2.0f;  //速度切り替え判定のための閾値
    private bool isGround = true;      //地面と接地しているか管理するフラグ
    int key = 0;              //左右の入力管理
    float stateEffect = 1;   // 状態に応じて横移動速度を変えるための係数

    private void Start()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(inputX * speed, 0);

      
        Move(); //入力に応じて移動する
    }

    void Move()
    {
        //接地しているときにスペースを押したらジャンプ
        if (isGround )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ジャンプしているときはfalse
                rb2d.AddForce(transform.up * jumpForce);
                isGround = false;
            }
        }
        // 左右の移動。一定の速度に達するまではAddforceで力を加え、それ以降はtransform.positionを直接書き換えて同一速度で移動する
        float speedX = Mathf.Abs(this.rb2d.velocity.x);
        if (speedX < this.runThreshold)
        {
            //未入力の場合は key の値が0になるため移動しない
            this.rb2d.AddForce(transform.right * key * this.runForce * stateEffect);
        }
        else
        {
            this.transform.position += new Vector3(runSpeed * Time.deltaTime * key * stateEffect, 0, 0);
        }

       
    }

    //着地判定
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (isGround)
            {
                isGround = true;
            }
                

        }

        
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            if (isGround)
            {
                isGround = true;
            }
                
            Debug.Log(isGround);
        }
    }
}
