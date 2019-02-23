using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	/* 課題追加箇所	*/
	//得点を表示するテキスト
	private GameObject scoreText;
	//得点保持用
	private int score = 0;

	// Use this for initialization
	void Start () {
		
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		/* 課題追加箇所	*/
		this.scoreText = GameObject.Find ("ScoreText");
		//得点を0で初期化
		this.scoreText.GetComponent<Text> ().text = "SCORE:" + this.score.ToString();
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}

	/* 課題追加箇所	*/
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision col) {
		//対象が大の星または雲の場合
		if (col.gameObject.CompareTag ("LargeStarTag") || col.gameObject.CompareTag ("LargeCloudTag")) {
			/*20点加算する	*/
			this.score += 20;
		}
		//対象が小の星または雲の場合
		else if (col.gameObject.CompareTag ("SmallStarTag") || col.gameObject.CompareTag ("SmallCloudTag")) {
			/*10点加算する	*/
			this.score += 10;
		}
		this.scoreText.GetComponent<Text> ().text = "SCORE:" + this.score.ToString();
	}
}