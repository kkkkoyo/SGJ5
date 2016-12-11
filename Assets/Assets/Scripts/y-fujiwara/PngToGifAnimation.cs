using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// y-fujiwara
/// PNG画像アニメーション用クラス
/// </summary>
public class PngToGifAnimation : MonoBehaviour {

	/// <summary>
    /// PNGを貼り付ける先のGameObject
    /// </summary>
	public GameObject obj;

	/// <summary>
    /// 切り替え間隔の秒数
    /// </summary>
    public float changeFrameSecond;

	/// <summary>
    /// イメージ格納先フォルダネーム
    /// </summary>
    public string folderName;

	/// <summary>
    /// イメージ名のプレフィックス
	/// 画像の物理名はheadText_1となる
    /// </summary>
    public string headText;

	/// <summary>
    /// イメージ枚数
    /// </summary>
    public int imageLength;

	/// <summary>
    /// 一枚目の数字
	/// 0からか1からかなど
    /// </summary>
    private int firstFrameNum;

	/// <summary>
    /// 経過時間
    /// </summary>
    private float dTime;

	/// <summary>
    /// 開始メソッド
	/// メンバの初期化のみ行う
    /// </summary>
    private void Start () {
        firstFrameNum = 1;
        dTime = 0.0f;
    }

	/// <summary>
    /// 更新用メソッド
	/// 毎フレームごとに呼ばれるため,本メソッドでアニメーション処理を行う
    /// </summary>
    private void Update () {
        if (firstFrameNum == this.imageLength) {
            this.FInishAnimation();
            return ;
        }

        dTime += Time.deltaTime;
        if (changeFrameSecond < dTime) {
            dTime = 0.0f;
            firstFrameNum++;
            if(firstFrameNum > imageLength) firstFrameNum = 1;
        }
        Texture tex = Resources.Load(folderName + "/" + headText + firstFrameNum) as Texture;
        obj.GetComponent<Renderer>().material.SetTexture ("_MainTex", tex);
    }

	/// <summary>
    /// 終了処理
    /// </summary>
	private void FInishAnimation() {
		SceneManager.LoadScene ("game");
	}
}
