using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		//左矢印キーを押した時左フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.flickAngle);
		}
		//右矢印キーを押した時右フリッパーを動かす
		if (Input.GetKeyDown (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.flickAngle);
		}
		//矢印キー離された時フリッパーを元に戻す
		if (Input.GetKeyUp (KeyCode.LeftArrow) && tag == "LeftFripperTag") {
			SetAngle (this.defaultAngle);
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && tag == "RightFripperTag") {
			SetAngle (this.defaultAngle);
		}

		//タッチパネル追加処理
		foreach (Touch t in Input.touches)
		{
			switch(t.phase)
			{
				case TouchPhase.Began:		/* 画面に指が触れたとき	*/
					/* 画面左半分をタッチした場合は、左のフリッパーを弾く */
					if((t.position.x >= 0) && (t.position.x <= Screen.width/2) && (tag=="LeftFripperTag"))
							SetAngle (this.flickAngle);
					/* 画面右半分をタッチした場合は、右のフリッパーを弾く */
					if((t.position.x  > Screen.width/2) && (t.position.x  <= Screen.width) && (tag=="RightFripperTag"))
							SetAngle (this.flickAngle);
					break;
				case TouchPhase.Ended:		/* 画面から指が離れたとき	*/
				case TouchPhase.Canceled:	/* システムがタッチの追跡をキャンセル */
					/* 画面左半分から離した場合は、左のフリッパーを戻す */
					if((t.position.x  >= 0) && (t.position.x  <= Screen.width/2) && (tag=="LeftFripperTag"))
							SetAngle (this.defaultAngle);
					/* 画面右半分から離した場合は、右のフリッパーを戻す */
					if((t.position.x  > Screen.width/2) && (t.position.x  <= Screen.width) && (tag=="RightFripperTag"))
							SetAngle (this.defaultAngle);
					break;
				default:
					break;
			}
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}