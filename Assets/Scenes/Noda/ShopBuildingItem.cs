using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopBuildingItem : ShopBase
{
    /// <summary>
    /// 注意：このクラスはショップのBuildingアイテムButtonに張り付けるつもりで書きました変更点やご不満がある方は野田倫太郎までお申し付けください。
    /// </summary>

    [SerializeField] public float resoursePlus = default;
    //resourseの増加数
    [SerializeField] float shopCost = default;
    //shopにあるItemのコスト
    [SerializeField] float CostPlus = default;
    //Costの増加倍率
    [SerializeField] GameObject resourceManagerObject = null;
    //ResourceManagerがついてるObjectを取得する
    ResourceManager resourceManager;
    //ResourceManagerの関数を取得するための入れ物

    void Start()
    {
        resourceManager = resourceManagerObject.GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBuildingButton (string Building)
    {
        if(resourceManager.ResourceTotalAmount >= shopCost)
        {
            resourceManager.UseResource(shopCost);
            Purchase(Item.Building);
            shopCost *= CostPlus;
            resourceManager.AddEverySecond(resoursePlus);
        }
        else
        {
            Debug.Log("コストが足りません");
        }
    }
}
