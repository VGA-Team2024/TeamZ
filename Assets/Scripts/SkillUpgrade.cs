using UnityEngine;

public class SkillUpgrade : NpcBase
{
    /// <summary>Shopにあるアップグレードさせたいアイテムを入れる</summary>
    [Header("アップグレードさせたいObjectを入れてください(Resource全体の増加量を増やしたい場合はnullにしてください）")]
    [SerializeField] GameObject NpcSkillUpgradeObject = null;
    /// <summary>ShopBuildingItemObjectのアイテムをどれくらいアップデートさせるか</summary>
    [Header("施設のアップグレード倍率")]
    [SerializeField] float upgradePowerBuilding = default;
    /// <summary>毎秒のResource増加数全体の2%</summary>
    float upgradePowerTotalAmount = default;
    Skill skillUpgrade;
    void Start()
    {
        if (NpcSkillUpgradeObject)
        {
            skillUpgrade = NpcSkillUpgradeObject.GetComponent<Skill>();
        }
    }

    public void OnClickUpgradeButton(string Upgrade)
    {
        if (NpcSkillUpgradeObject)
        {
            _npc = Npc.Upgrade;//アイテムの判別
            if (_gold.GoldTotalAmount >= _price)
            {
                Purchase();//アイテムの支払い
                skillUpgrade.Upgrade(upgradePowerBuilding);//Skillのアップグレード
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
