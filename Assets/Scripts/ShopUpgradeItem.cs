using UnityEngine;

public class ShopUpgradeItem : ShopBase
{
    /// <summary>
    /// 注意：このクラスはショップのUpgradeアイテムButtonにくっつけるつもりで書きました変更点やご不満がある方は野田倫太郎までお申し付けください。
    /// </summary>

    [SerializeField] GameObject ShopBuildingItemObject = null;
    //Shopにあるアップグレードさせたいアイテムを入れる
    ShopBuildingItem shopBuildingItem;
    void Start()
    {
        shopBuildingItem = ShopBuildingItemObject.GetComponent<ShopBuildingItem>();
    }
    
    void Update()
    {
        
    }

    public void OnClickUpgradeButton(string Upgrade)
    {
        shopBuildingItem.resoursePlus *= 2;
        Purchase();
    }
}
