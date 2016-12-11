using System.Collections;
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
        returnGameButton.position=new Vector3(returnGameButton.position.x,returnGameButton.position.y+400,0);
    }

    /// <summary>
    /// ボタンクリック用イベント
    /// 対象の障害を削除し,障害が無いオブジェクトに差し替える
    /// </summary>
    public void OnConversionClick() 
    {
       List<BarrierParameters> barrierObjects = itemChecker.destroyObjects();
       GameObject targetObject = null;
       BarrierParameters targetParams = null;
       bool returnFlag = false;
       int removeIndex = 0;

       // Listから削除する対象を把握するために普通のfor文を利用
        for (int i = 0; i < barrierObjects.Count(); i++ ) {
            removeIndex = i;
            var x = barrierObjects[i];
            // 使おうとしている対象のアイテムが判定範囲に存在するバリアに対応しているかどうかチェック
            if (itemList.IndexOf(itemList[itemNumber]) == barrierList.IndexOf(x.BarrierTagName) ) { 
                returnFlag = true;
                targetObject = x.BarrierObject;
                targetParams = new BarrierParameters(targetObject); 
                // 一つでも存在すれば次の処理に移る
                break;
            }
        }
       // Debug.Log(@"リストの長さ" + barrierObjects.Count() + "," + barrierObjects[removeIndex].BarrierTagName  + "," + removeIndex);

        // アイテムに対応するバリアが判定内に一つもない場合は終了
        // nullチェックも行っている
        if (!returnFlag || targetParams == null || targetObject == null) {
            Debug.Log(@"削除対象なし");
            return;
        }

        // 対象オブジェクトとポジション取得
        if(itemChecker.getBarrierFlag()){
            if(itemList.IndexOf(itemList[itemNumber]) == barrierList.IndexOf(targetParams.BarrierTagName)){
                itemChecker.destroyObject(targetObject); 
                // Listから削除 
                itemChecker.removeListElements(removeIndex);
            }
        }
        Vector3 barrierPosition= targetParams.BarrierPosition;
        //埋まるのを回避
        if(itemNumber==0) { 
            barrierPosition.y=0.111f; 
        }
        else {
            barrierPosition.y=0.5f;
        }
        Vector3 barrierRotate=new Vector3(0,itemChecker.PetilPos(),0);
        
        if(itemNumber==0){
            barrierRotate.y=-90+barrierRotate.y;
        }
        // 障害がないオブジェクトを削除対象のオブジェクト位置に生成
        GameObject testObject = Instantiate(Resources.Load("Prefabs/"+itemList[itemNumber]),barrierPosition, Quaternion.Euler(barrierRotate)) as GameObject;
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
