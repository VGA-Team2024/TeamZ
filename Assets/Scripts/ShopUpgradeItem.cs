using UnityEngine;

public class ShopUpgradeItem : ShopBase
{
    /// <summary>Shopにあるアップグレードさせたいアイテムを入れる</summary>
    [Header("アップグレードさせたいObjectを入れてください(Resource全体の増加量を増やしたい場合はnullにしてください）")]
    [SerializeField] GameObject shopBuildingItemObject = null;
    /// <summary>ShopBuildingItemObjectのアイテムをどれくらいアップデートさせるか</summary>
    [Header("施設のアップグレード倍率")]
    [SerializeField] float upgradePowerBuilding = default;
    /// <summary>毎秒のResource増加数全体の2%</summary>
    float upgradePowerTotalAmount = default;
    ShopBuildingItem shopBuildingItem;
    void Start()
    {
        if (shopBuildingItemObject)
        {
            shopBuildingItem = shopBuildingItemObject.GetComponent<ShopBuildingItem>();
        }
    }

    public void OnClickUpgradeButton(string Upgrade)
    {
        if (shopBuildingItemObject)
        {
            _item = Item.Upgrade;//アイテムの判別
            if (_gold.GoldTotalAmount >= _price)
            {
                Purchase();//アイテムの支払い
                shopBuildingItem.Upgrade(upgradePowerBuilding);//施設のアップグレード
                this.gameObject.SetActive(false);//1度使用したら使えないようにする
                Debug.Log("Upgrade完了");
            }
            else
            {
                Debug.Log("Resourceが足りないよ");
            }
        }//shopBuildingItemObjectに施設のアイテムが入っていればその施設のアップグレードを行う
        else
        {
            Debug.Log("Updateするアイテムが指定されてません");
        }
    }
}
