using UnityEngine;

public class Jumping : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float jumpForce = 0f;       //ジャンプするときに加える力
    float jumpThreshold = 2.0f;    //ジャンプ中か判定するための閾値
    float speed = 6f;                //歩くスピード
    float runForce = 30.0f;       // 走り始めに加える力
    float runSpeed = 0.5f;       // 走っている間の速度
    float runThreshold = 2.0f;  //速度切り替え判定のための閾値
    float stateEffect = 1;   // 状態に応じて横移動速度を変えるための係数
    int key = 0;              //左右の入力管理
    bool isGround = true;      //地面と接地しているか管理するフラグ
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
            this.rb2d.AddForce(transform.right * key * this.runForce * stateEffect); //未入力の場合は key の値が0になるため移動しない
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
                isGround = true;
        }

        
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            if (isGround)
                isGround = true;
        }
    }
}
