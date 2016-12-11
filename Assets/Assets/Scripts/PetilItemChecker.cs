using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoPetilGo.ParrierObject;

public class PetilItemChecker : MonoBehaviour {

	public bool barrierFlag =false;
    private List<string> barrierList = new List<string>(){"dansa","barrierA","barrierB","barrierC","barrierD"};
    private List<string> itemList = new List<string>(){"slope","itemA","itemB","itemC","itemD"};
    private readonly List<string> partsList = new List<string>(){"KeyitemA","KeyitemB","KeyitemC"};
	private readonly string shipTagName = "ship";

	/*
	private GameObject barrierObject;
	private string destroyBarrierName="0";
	private Vector3 barrierPosition=new Vector3();
	*/

	/// <summary>
    /// 取得したアイテム数
    /// </summary>
	private int ItemTotal;

	/// <summary>
    /// 当たり判定にあるゲームオブジェクトリスト
    /// </summary>
	private List<BarrierParameters> collisionBarrierObjects = new List<BarrierParameters>();

	void OnTriggerEnter(Collider collider){
		string tagName = collider.gameObject.tag;
		// 障害物との判定処理	
		if (this.barrierList.Contains(collider.gameObject.tag)) {
			this.collisionBarrierObjects.Add( new BarrierParameters(collider.gameObject)); 
			// 障害物と接触した時だけフラグをtrueに
			barrierFlag=true;
		}
		// パーツとの判定処理
		if (this.partsList.Contains(collider.gameObject.tag)) {
			this.ItemTotal += 1;
			Destroy(collider.gameObject);
			Debug.Log("" + this.ItemTotal);
			// バリアのフラグを変更はしない
			return;
		}
		// 宇宙船との当たり判定スケルトン
		if (this.shipTagName.Equals(collider.gameObject.tag)) {
			return;
		}
		Debug.Log("" + this.barrierFlag);
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
