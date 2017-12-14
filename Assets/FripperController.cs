using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FripperController : MonoBehaviour
{

    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;

    //ゲームオーバーの判定
    //private bool isGameOver = false;


    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

    }

    // Update is called once per frame
    void Update()
    {
        // Touch対応
        // 指の本数が０より大き場合
        if (Input.touchCount > 0)
        {

            // タッチしている指の本数だけ繰り返す
            foreach (Touch touch in Input.touches)
            {

                // タッチ開始時
                if (touch.phase == TouchPhase.Began)
                {
                    if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (touch.position.x > Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                }

                // タッチ終了時
                if (touch.phase == TouchPhase.Ended)
                {
                    if (touch.position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    if (touch.position.x > Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }

        //左矢印キーを押したとき左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //右矢印キーを押したとき右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離されたときフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

    }



//フリッパーの傾きを設定

public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}