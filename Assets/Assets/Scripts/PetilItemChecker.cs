using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetilItemChecker : MonoBehaviour {

	public bool barrierFlag =false;
    private List<string> barrierList = new List<string>(){"dansa","barrierA","barrierB","barrierC","barrierD"};
    private List<string> itemList = new List<string>(){"slope","itemA","itemB","itemC","itemD"};
    private readonly List<string> partsList = new List<string>(){"KeyitemA","KeyitemB","KeyitemC"};
	private readonly string shipTagName = "ship";
	private GameObject barrierObject;
	private string destroyBarrierName="0";
	private Vector3 barrierPosition=new Vector3();
	[SerializeField] private Text messageText;

	private int ItemTotal;

	void OnTriggerEnter(Collider collider){
		string tagName = collider.gameObject.tag;
		// 障害物との判定処理	
		if (this.barrierList.Contains(collider.gameObject.tag)) {
			barrierObject=collider.gameObject;
			destroyBarrierName=collider.gameObject.tag;
			barrierPosition=collider.gameObject.GetComponent<Transform>().position;
		}
		// パーツとの判定処理
		if (this.partsList.Contains(collider.gameObject.tag)) {
			this.ItemTotal += 1;

			Texture2D texture = Resources.Load("images/"+this.ItemTotal) as Texture2D;
			Image img = GameObject.Find("ButtonCanvas/Score/Score_1").GetComponent<Image>();
			img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);


			Destroy(collider.gameObject);
			Debug.Log("" + this.ItemTotal);
			// バリアのフラグを変更はしない
			if(this.ItemTotal>=3){
			//3つ揃った
			messageText.GetComponent<Text>().text="宇宙船へ迎え！";
		 }
			return;
		}
		// 宇宙船との当たり判定スケルトン
		barrierFlag=true;


	}
	void OnCollisionEnter(Collision c) {

		if (this.shipTagName.Equals(c.gameObject.tag)) {	
			if(this.ItemTotal>=3){
				Debug.Log("クリア!");
			}
			return;
		}
	}

	void OnTriggerStay(Collider collider){
	}

	/// <summary>
    /// 障害物判定から出たときのメソッド
	/// バリアの当たり判定領域から出たらフラグをfalseに変更する
    /// /// </summary>
    /// <param name="collider"></param>
	void OnTriggerExit(Collider collider){
		if (this.barrierList.Contains(collider.gameObject.tag)) {
			barrierFlag=false;
		}
		Debug.Log("" + this.barrierFlag);
	}

	public bool getBarrierFlag(){
		return barrierFlag;
	}
	public void destroyObject(){
		Destroy(barrierObject);
	}

	public string destroyName(){
		return destroyBarrierName;
	}
	public GameObject barrierItem(){
		return barrierObject;
	}
	public Vector3 barrierPos(){
		return barrierPosition;
	}
	public float PetilPos(){
		//:TODO
		return this.transform.rotation.y;
	}
}
