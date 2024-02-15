using UnityEngine;

public class SkillUp : NPCBase
{
    /// <summary>ShopにあるアップグレードさせたいNPCを入れる</summary>
    [Header("アップグレードさせたいObjectを入れてください(Resource全体の増加量を増やしたい場合はnullにしてください）")]
    [SerializeField] GameObject skillUpNpcObject = null;///今回の場合仙人になる
    /// <summary>ShopBuildingItemObjectのアイテムをどれくらいアップデートさせるか</summary>
    [Header("Skillのアップグレード倍率")]
    [SerializeField] int upgradeSkillUping = default;
    /// <summary>毎秒のResource増加数全体の2%</summary>
    float upgradePowerTotalAmount = default;
    Skill SkilUping;
    void Start()
    {
        if (skillUpNpcObject)
        {
            SkilUping = skillUpNpcObject.GetComponent<Skill>();
        }
    }

    public void OnClickUpgradeButton(string Upgrade)
    {
        if (skillUpNpcObject)
        {
            _npc = Npc.Upgrade;//NPCの判別
            if (_gold.GoldTotalAmount >= _price)
            {
                Purchase();//Goldの支払い
                SkilUping.Upgrade(upgradeSkillUping);//Skillのアップグレード
                this.gameObject.SetActive(false);//1度使用したら使えないようにする
                Debug.Log("Upgrade完了");
            }
            else
            {
                Debug.Log("Resourceが足りないよ");
            }
        }//skillUpNpcObjectにNPCが入っていればそのNPCのアップグレードを行う
        else
        {
            Debug.Log("UpdateするNPCが指定されてません");
        }
    }
}
