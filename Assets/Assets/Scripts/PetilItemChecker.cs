using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetilItemChecker : MonoBehaviour {

	public bool barrierFlag =false;
    private List<string> barrierList = new List<string>(){"dansa","barrierA","barrierB","barrierC","barrierD"};
    private List<string> itemList = new List<string>(){"slope","itemA","itemB","itemC","itemD"};
	private GameObject barrierObject;
	private string destroyBarrierName="0";
	private Vector3 barrierPosition=new Vector3();
	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "dansa") {
			barrierObject=collider.gameObject;
			destroyBarrierName=collider.gameObject.tag;
			barrierPosition=collider.gameObject.GetComponent<Transform>().position;
		}
	barrierFlag=true;
	}

	void OnTriggerStay(Collider collider){
	}

	void OnTriggerExit(Collider collider){
		if (collider.gameObject.tag == "ItemA") {

		}
	barrierFlag=false;
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
}
