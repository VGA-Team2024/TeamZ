using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 施設の基底クラス
/// abstractつけた抽象クラスなので
/// これ単体でオブジェクトにつけられない
/// </summary>
public abstract class ShopBase : MonoBehaviour
{
    [Header("太字説明がついてる物はInspectorでの設定が必須")]
    [Header("リソースマネージャーを指定")]
    public ResourceManager _resouce;
    [Header("購入アイテムの種類")]
    [Tooltip("購入アイテムの種類")]
    public Item _item;
    [Header("\"購入アイテムの値段（初期値）")]
    [Tooltip("購入アイテムの値段（初期値）")]
    public int _price;

    /// <summary>購入した施設の所持数</summary>
    public int _level = 0;
    /// <summary>今の値段</summary>
    public float _nowPrice = 0;

    private void Start()
    {
        _nowPrice = _price;
        ChildStart();
    }
    /// <summary>Start()で実行したいものを上書きしてください</summary>
    public virtual void ChildStart()
    {

    }
    /// <summary>購入した時の処理を上書きしてください</summary>
    public virtual void ItemProcess()
    {
        //CpSの計算が入る
    }
    /// <summary>購入処理。Buttonから呼び出す</summary>
    public void Purchase()
    {
        _nowPrice = (float)(Math.Pow(1.15, _level) * _price);//値段計算。_level == 0なら_priceの値がそのまま入る
        bool purchased = _resouce.UseResource(_nowPrice);//購入処理。変えたかどうかを代入
        if (purchased)
        {
            ItemProcess();
            if (_item == Item.Upgrade)//もしアップグレードだったらボタンを押せなくする。
            {
                //ここにUIを消す処理
                //おそらくアップグレードはリストとかで管理すると思う。
                //なのでリストから削除し、オブジェクトをどこかに保存する処理を行う。
            }
            else
            {
                _level++;//施設だったらレベルを上げる。
            }
        }
        else
        {
            Debug.Log("購入失敗");
        }
    }
    /// <summary>購入物の種類</summary>
    public enum Item 
    {
        /// <summary>アップグレード</summary>
        Upgrade,
        /// <summary>施設、建物</summary>
        Building,
    }
}
