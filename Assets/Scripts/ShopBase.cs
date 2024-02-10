using System;
using UnityEngine;
using UnityEngine.UI;
/// <summary>施設の基底クラス</summary>
public abstract class ShopBase : MonoBehaviour
{
    public delegate bool PurchaseEvent(float resouce);
    PurchaseEvent _method = null;

    [Tooltip("購入アイテムの種類")]
    public Item _item;
    [Tooltip("購入アイテムの値段（初期値）")]
    public int _price;

    /// <summary>購入した施設の所持数</summary>
    public int _level = 0;
    /// <summary>今の値段</summary>
    public float _nowPrice = 0;

    public ResourceManager _resouce;

    //以下は開発用
    [SerializeField] Text _text;
    private void Start()
    {
        //_resouceにGetConpornentする処理と、_methodにUseResouceを追加する処理
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
        _method(_nowPrice);//購入処理。戻り値がboolになったらこの後にif分岐を作る。

        //以下は

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
    /// <summary>購入物の種類</summary>
    public enum Item 
    {
        /// <summary>アップグレード</summary>
        Upgrade,
        /// <summary>施設、建物</summary>
        Building,
    }
}
