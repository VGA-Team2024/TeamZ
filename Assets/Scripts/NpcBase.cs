using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 施設の基底クラス
/// abstractつけた抽象クラスなので
/// これ単体でオブジェクトにつけられない
/// </summary>
public abstract class NpcBase : MonoBehaviour
{
    [Header("太字説明がついてる物はInspectorでの設定が必須")]
    [Header("ゴールドマネージャーを指定")]
    public GoldManager _gold;
    [Header("NPCの種類")]
    [Tooltip("NPCの種類")]
    public Npc _npc;
    [Header("購入NPCの値段（初期値）")]
    [Tooltip("購入NPCの値段（初期値）")]
    public int _price;
    [Header("TextMeshProコンポーネントを指定")]
    [Tooltip("TextMeshProコンポーネントを指定")]
    [SerializeField] TMP_Text _tmp;
    [Header("NPCの名前")]
    [Tooltip("NPCの名前")]
    public string _text;

    /// <summary>購入したNPCの所持数</summary>
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

        bool purchased = _gold.UseGold(_nowPrice);//購入処理。買えたかどうかを代入
        if (purchased)
        {
            //アップグレードアイテム等、途中でshopから消えるアイテムは継承先で処理
            ItemProcess();
            //NPCレベルは値段に影響するので、こちらで処理
            if (_npc == Npc.Repeat)//もしリピートアイテムだったらレベルを上げる
            {
                _level++;
                //テキスト処理
                _tmp.text = _text + "　" + _nowPrice.ToString("F0") + "G";
            }
        }
        else
        {
            Debug.Log("購入失敗");
        }
    }
    /// <summary>購入物の種類</summary>
    public enum Npc
    {
        /// <summary>買い切り（現時点でアップグレードが対象）</summary>
        Upgrade,
        /// <summary>何回も購入する（現時点で施設が対象）</summary>
        Repeat,
    }
}
