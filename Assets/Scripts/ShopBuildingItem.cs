using UnityEngine;

public class ShopBuildingItem : ShopBase
{
    // 注意：このクラスはショップの施設のアイテムに張り付けるつもりで書きました変更点やご不満がある方は野田倫太郎までお申し付けください。

    ///<summary>resourseの増加数</summary>
    [SerializeField] public float resoursePlus = default;
    /// <summary>ResourceManagerがついてるObjectを取得する</summary>
    [Header("ReaourceManagerが入ったObjectを入れてください")]
    [SerializeField] GameObject resourceManagerObject = null;
    /// <summary>"この施設によって"1秒間に生成されるResourceの数</summary>
    [Header("Publicだけどいじらないで")]public float everySecondPlusResource = default;

    void Start()
    {
        _resouce = resourceManagerObject.GetComponent<ResourceManager>();
        //ResourceManagerにアクセス
    }

    public void OnClickBuildingButton (string Building)
    {
        bool firstClick = true;
        if (_resouce.ResourceTotalAmount >= _price && firstClick == true)
        {
            _item = Item.Repeat;//itemの判別
            Purchase();//購入処理
            _resouce.AddEverySecond(resoursePlus);//ItemによるResourceの増加処理
            everySecondPlusResource += resoursePlus;//このItemによる毎秒のResource増加数
            firstClick = false;
        }//最初は初期値とリソースの総量を比較する

        if (_resouce.ResourceTotalAmount >= _nowPrice && firstClick == false)
        {
            _item = Item.Repeat;//itemの判別
            Purchase();//購入処理
            _resouce.AddEverySecond(resoursePlus);//ItemによるResourceの増加処理
            everySecondPlusResource += resoursePlus;//このItemによる毎秒のResource増加数
        }

        else
        {
            Debug.Log("コストが足りません");
        }
    }

    public void Upgrade(float x)
    {
        _resouce.AddEverySecond(everySecondPlusResource);
        everySecondPlusResource *= x;
    }//アップグレードアイテムを使ったときの処理
}
