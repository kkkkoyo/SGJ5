﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// y-fujiwara
/// テスト用ボタンイベント用クラス
/// </summary>
public class ConversionObstacleController : MonoBehaviour 
{

    /// <summary>
    /// メニューのスライドイン用メンバ変数
    /// </summary>
    [SerializeField]private PanelSlider slider;
    [SerializeField]private Transform returnGameButton;

    void Start(){
        //TODO:ゴリ押し
        returnGameButton.position=new Vector3(returnGameButton.position.x,returnGameButton.position.y+400,0);

    }


    /// <summary>
    /// ボタンクリック用イベント
    /// 対象の障害を削除し,障害が無いオブジェクトに差し替える
    /// </summary>
    public void OnConversionClick() 
    {
        // 対象オブジェクトとポジション取得
        var targetObjects = GameObject.FindGameObjectsWithTag("Obstacle");

        // 対象タグのオブジェクトすべてが消されていたらメソッドを抜ける
        if (targetObjects.Length == 0) return;

        var targetObject = targetObjects[0];
        var targetPosition = targetObject.transform.position;
        targetPosition.y = 0;

        // タグよりの取得が配列なので,一応全部削除
        foreach(var deleteObject in targetObjects) 
        {
            Destroy(deleteObject);
        }
        Vector3 SlopePosition=targetPosition;
        //埋まるのを回避
        SlopePosition.y+=0.111f;

        // 設定されたメンバ変数のオブジェクトを削除対象のオブジェクト位置に生成
        GameObject testObject = Instantiate(Resources.Load("Prefabs/slope_01"), SlopePosition, Quaternion.identity) as GameObject;
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
}
