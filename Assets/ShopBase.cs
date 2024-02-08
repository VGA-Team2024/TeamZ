using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>施設の基底クラス</summary>
public class ShopBase : MonoBehaviour
{
    /// <summary>購入した施設の所持数</summary>
    int _level = 0; 
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    /// <summary>購入した施設やアップグレードの処理を上書きしてください</summary>
    public virtual void ItemProcess()
    {

    }
    /// <summary>購入処理。Buttonから呼び出す</summary>
    public void Purchase(Item item)
    {
        //ここにリソース消費処理を作る予定
        if (item == Item.Upgrade)//もしアップグレードだったら
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
