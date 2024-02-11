using UnityEngine;

public class ShopUpgradeItem : ShopBase
{
    // 注意：このクラスはショップのUpgradeアイテムにくっつけるつもりで書きました変更点やご不満がある方は野田倫太郎までお申し付けください。

    /// <summary>Shopにあるアップグレードさせたいアイテムを入れる</summary>
    [Header("アップグレードさせたいObjectを入れてください(Resource全体の増加量を増やしたい場合はnullにしてください）")]
    [SerializeField] GameObject shopBuildingItemObject = null;
    /// <summary>ShopBuildingItemObjectのアイテムをどれくらいアップデートさせるか</summary>
    [Header("施設のアップグレード倍率")]
    [SerializeField] float upgradePowerBuilding = default;
    [Header("Resource全体のアップグレード倍率")]
    [SerializeField] float upgradePowerTotalAmount = default;
    ShopBuildingItem shopBuildingItem;
    void Start()
    {
        if (shopBuildingItemObject != null)
        {
            shopBuildingItem = shopBuildingItemObject.GetComponent<ShopBuildingItem>();
        }
    }
    
    void Update()
    {
        if(shopBuildingItemObject == null)
        {
            upgradePowerTotalAmount = ((float)_resouce.ResourceTotalAmount/100) * 2;
        } //全体の2%の数を取得
    }

    public void OnClickUpgradeButton(string Upgrade)
    {
        if (shopBuildingItemObject != null)
        {
            _item = Item.Upgrade;//アイテムの判別
            Purchase();//アイテムの支払い
            if (_resouce.ResourceTotalAmount >= _price)
            {
                shopBuildingItem.Upgrade(upgradePowerBuilding);//施設のアップグレード
                this.gameObject.SetActive(false);//1度使用したら使えないようにする
            }
            else
            {
                Debug.Log("Resourceが足りないよ");
            }
        }//shopBuildingItemObjectに施設のアイテムが入っていればその施設のアップグレードを行う
        else
        {
            _resouce.AddEverySecond(upgradePowerTotalAmount);
            this.gameObject.SetActive(false);//1度使用したら使えないようにする
        }//shopBuildingItemObjectに何も入っていなければ毎秒のResource増加数を全体の２％増やす
    }
}
