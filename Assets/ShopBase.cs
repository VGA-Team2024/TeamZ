using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/// <summary>施設の基底クラス</summary>
public class ShopBase : MonoBehaviour
{
    [Serializable] public class OnClickEvent : UnityEvent<float> { }

    [Header("メソッドを選ぶ時、上の方にある【Dynamic】の方を呼ぶこと！！")]
    [SerializeField] OnClickEvent _purchaseEvent = null;

    //public UnityEvent _purchaseEvent;
    [Tooltip("購入アイテムの種類")]
    [SerializeField] Item _item;
    [Tooltip("購入アイテムの値段（初期値）")]
    [SerializeField] int _price;

    /// <summary>購入した施設の所持数</summary>
    int _level = 0;

    //以下は開発用
    [SerializeField] Text _text;
    void Start()
    {
        
    }
    private void Update()
    {
        _text.text = "現在施設レベル" + _level +"　：必要リソース" + (Math.Pow(1.15, _level) * _price).ToString("F0");
    }
    /// <summary>購入した施設やアップグレードの処理を上書きしてください</summary>
    public virtual void ItemProcess()
    {

    }
    /// <summary>購入処理。Buttonから呼び出す</summary>
    public void Purchase()
    {
        //リソース消費処理
        _purchaseEvent.Invoke((float)(Math.Pow(1.15, _level) * _price));

        if (_item == Item.Upgrade)//もしアップグレードだったら
        {
            //ここにUIを消す処理
        }
        else
        {
            _level++;
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
