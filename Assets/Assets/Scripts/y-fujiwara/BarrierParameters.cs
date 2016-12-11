using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoPetilGo.ParrierObject { 
	/// <summary>
    /// y-fujiwara
    /// バリアを判別するのに必要なParameterを保持するクラス
    /// /// </summary>
    public class BarrierParameters {
    	/// <summary>
        /// 接触判定されたバリアオブジェクト
        /// </summary>
        /// <returns></returns>
    	public GameObject BarrierObject {get;}
    
    	/// <summary>
        /// BarrierObjectに紐づくタグ名
        /// </summary>
        /// <returns></returns>
    	public string BarrierTagName {get;}
    
    	/// <summary>
        /// BarrierObjectに紐づくPosition
        /// </summary>
        /// <returns></returns>
    	public Vector3 BarrierPosition {get;}
    
    	/// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="gameObject"></param>
    	public BarrierParameters(GameObject gameObject) {
    		this.BarrierObject = gameObject;
    		this.BarrierTagName = gameObject.tag;
    		this.BarrierPosition = gameObject.GetComponent<Transform>().position;
    	}
    }
}
