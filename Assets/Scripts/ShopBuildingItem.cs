using UnityEngine;

public class ShopBuildingItem : ShopBase
{
    ///<summary>resourseの増加数</summary>
    [SerializeField] public float goldPlus = default;
    /// <summary>ResourceManagerがついてるObjectを取得する</summary>
    [Header("GoldManagerが入ったObjectを入れてください")]
    [SerializeField] GameObject goldManagerObject = null;
    /// <summary>"この施設によって"1秒間に生成されるResourceの数</summary>
    [Header("Publicだけどいじらないで")]public float everySecondPlusGold = default;

    void Start()
    {
        _gold = goldManagerObject.GetComponent<GoldManager>();
        //GoldManagerにアクセス
    }

    public void OnClickBuildingButton (string Building)
    {
        bool firstClick = true;
        if (_gold.GoldTotalAmount >= _price && firstClick == true)
        {
            _item = Item.Repeat;//itemの判別
            Purchase();//購入処理
            _gold.AddEverySecond(goldPlus);//ItemによるGoldの増加処理
            everySecondPlusGold += goldPlus;//このItemによる毎秒のGold増加数
            firstClick = false;
        }//最初は初期値とゴールドの総量を比較する

        if (_gold.GoldTotalAmount >= _nowPrice && firstClick == false)
        {
            _item = Item.Repeat;//itemの判別
            Purchase();//購入処理
            _gold.AddEverySecond(goldPlus);//ItemによるGoldの増加処理
            everySecondPlusGold += goldPlus;//このItemによる毎秒のGold増加数
        }

        else
        {
            Debug.Log("コストが足りません");
        }
    }

    public void Upgrade(float x)
    {
        _gold.AddEverySecond(everySecondPlusGold);
        everySecondPlusGold *= x;
    }//アップグレードアイテムを使ったときの処理
}
