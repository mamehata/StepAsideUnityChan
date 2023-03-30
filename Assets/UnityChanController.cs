using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるコンポーネントを入れる（追加）
    private Rigidbody myRigidbody;
    //前方向の速度（追加）
    private float velocityZ = 16f;
    //横方向の速度（追加）
    private float velocityX = 10f;
    //左右の移動できる範囲（追加）
    private float movableRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {

        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントを取得（追加）
        this.myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //横方向の入力による速度（追加）
        float inputVelocityX = 0;

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる（追加）
        if (Input.GetKey (KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //左方向への速度を代入（追加）
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey (KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入（追加）
            inputVelocityX = this.velocityX;
        }

        //Unityちゃんに速度を与える（変更）
        this.myRigidbody.velocity = new Vector3(inputVelocityX, 0, this.velocityZ);
    }
}
