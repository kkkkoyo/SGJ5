using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // タグよりの取得が配列なので,一応全部削除
        foreach(var deleteObject in targetObjects) 
        {
            Destroy(deleteObject);
        }

        // 設定されたメンバ変数のオブジェクトを削除対象のオブジェクト位置に生成
        Instantiate(Resources.Load("Prefabs/NonObstacle"), targetPosition, Quaternion.identity);
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
