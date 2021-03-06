﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Item.Data;
using GoPetilGo.BarrierObject;
using System.Linq;
/// <summary>
/// y-fujiwara
/// テスト用ボタンイベント用クラス
/// </summary>
public class ConversionObstacleController : MonoBehaviour 
{

    # region ■privateメンバ変数■
    private List<string> barrierList = new List<string>(){"dansa","barrierA","barrierB","barrierC","barrierD"};
    private List<string> itemList = new List<string>(){"slope","itemA","itemB","itemC","itemD"};
    private int itemNumber=0;
    #endregion

    #region ■SerializeFieldメンバ変数■
    /// <summary>
    /// メニューのスライドイン用メンバ変数
    /// </summary>
    [SerializeField]private PanelSlider slider;
    [SerializeField]private Transform returnGameButton;
    [SerializeField]private Image ConversionObjectImage;
    [SerializeField]private PetilItemChecker itemChecker;
    #endregion

    void Start(){
        //TODO:ゴリ押し
        //returnGameButton.position=new Vector3(returnGameButton.position.x,returnGameButton.position.y+400,0);
    }

    /// <summary>
    /// ボタンクリック用イベント
    /// 対象の障害を削除し,障害が無いオブジェクトに差し替える
    /// </summary>
    public void OnConversionClick() 
    {
        Vector3 rotate=Vector3.zero;
        if(itemList.IndexOf(itemList[itemNumber])!=barrierList.IndexOf(itemChecker.destroyName())){
            Debug.Log(itemList.IndexOf(itemList[itemNumber]));
            Debug.Log(barrierList.IndexOf(itemChecker.destroyName()));

            return;
        }
        // 対象オブジェクトとポジション取得
         GameObject targetObject = itemChecker.barrierItem();
        if(itemChecker.getBarrierFlag()){

            if(itemList.IndexOf(itemList[itemNumber])==barrierList.IndexOf(itemChecker.destroyName())){

               rotate =itemChecker.destroyObject();
            }
        }
        Vector3 barrierPosition=itemChecker.barrierPos();
        //埋まるのを回避
        if(itemNumber==0) { 
            barrierPosition.y=0.111f; 
        }
        else {
            barrierPosition.y=0.5f;
        }
        Vector3 barrierRotate=new Vector3(0,itemChecker.PetilPos(),0);
        
        if(itemNumber==0){
            barrierRotate.y=barrierRotate.y;
        }
        // 障害がないオブジェクトを削除対象のオブジェクト位置に生成
        GameObject testObject = Instantiate(Resources.Load("Prefabs/"+itemList[itemNumber]),barrierPosition,Quaternion.identity) as GameObject;
        if(itemNumber==0){
          testObject.transform.localScale = new Vector3(2,1,2);
          testObject.transform.rotation = Quaternion.Euler(rotate);
          if(rotate.y==90){
              testObject.transform.position = new Vector3(testObject.transform.position.x+5.21f,
              testObject.transform.position.y,testObject.transform.position.z);
          }
        }else if(itemNumber==3){
            testObject.transform.rotation = Quaternion.Euler(new Vector3(90,0,0));
            //testObject.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));
            //testObject.transform.position = new Vector3(-58.37f,0.111f,48.15f);
        }
    }

    /// <summary>
    /// メニュー表示用ボタンクリック時イベントメソッド
    /// </summary>
    public void OnShowMenuClick() 
    {
        this.slider.SlideIn();
    }

    /// <summary>
    /// メニュー閉じるボタンクリック
    /// </summary>
    public void OnCloseMenuClick()
    {
        this.slider.SlideOut();
    }

    /// <summary>
    /// アイテム右ボタン
    /// </summary> 
    public void OnMenuLeftClick()
    { 
        itemNumber  = itemNumber <= 0 ? itemList.Count-1 : itemNumber-1 ;
        Texture2D texture = Resources.Load("images/"+itemList[itemNumber]) as Texture2D;
        Image img = GameObject.Find("ButtonCanvas/ConversionObjectButton").GetComponent<Image>();
        img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    /// <summary>
    /// アイテム左ボタン
    /// </summary> 
    public void OnMenuRightClick()
    {
        //TODO:
        itemNumber  = itemNumber >= itemList.Count-1 ? 0 : itemNumber+1 ;
        Texture2D texture = Resources.Load("images/"+itemList[itemNumber]) as Texture2D;
        Image img = GameObject.Find("ButtonCanvas/ConversionObjectButton").GetComponent<Image>();
        img.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    /// <summary>
    /// 宇宙船のPartsを取得するコールバック関数
    /// </summary>
    public void PartsGetCallBack()
    {

    }
}
