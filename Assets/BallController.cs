using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BallController : MonoBehaviour {

    //ボールが見える可能性がのあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    private int score = 0;

    private GameObject scoreText;

    //ゲームオーバーの判定
    private bool isGameOver = false;



    // Use this for initialization
    void Start () {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");

        Debug.Log("Hello, World");
    }
	
	// Update is called once per frame
	void Update () {
       

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            this.isGameOver = true;
        }

        // ゲームオーバになった場合←これをlsson7 8-2からもってきました
        if (this.isGameOver)
        {
            // クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込む
                SceneManager.LoadScene("GameScene");
            }
            Debug.Log("GAMEOVER");
        }

        Debug.Log("Update");

    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
            this.scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
        }
        else if(other.gameObject.tag == "LargeStarTag")
        {
            score += 30;
            this.scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
        }
        else if(other.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            score += 50;
            this.scoreText.GetComponent<Text>().text = "Score:" + score.ToString();
        }

        Debug.Log("END");
        Debug.Log(score);
       
    }

}


//一つ関数をつくって、関数の引数にスコアをわたす。
//関数の中でスコアを足す処理とラベルへの反映をすると効率的(他のオブジェクトに当たった時に無駄な処理が走らない)
