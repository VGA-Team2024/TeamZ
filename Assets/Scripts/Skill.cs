using UnityEngine;

public class Skill : NPCBase
{
    ///<summary>resourseの増加数</summary>
    [SerializeField] public float goldPlus = default;
    /// <summary>ResourceManagerがついてるObjectを取得する</summary>
    [Header("GoldManagerが入ったObjectを入れてください")]
    [SerializeField] GameObject goldManagerObject = null;
    /// <summary>"この施設によって"1秒間に生成されるResourceの数</summary>
    [Header("Publicだけどいじらないで")] public float everySecondPlusGold = default;

    void Start()
    {
        _gold = goldManagerObject.GetComponent<GoldManager>();
        //GoldManagerにアクセス
    }
    public void OnClickSkillButton (string Building)
    {
        bool firstClick = true;
        if (_gold.GoldTotalAmount >= _price && firstClick == true)
        {
           　_npc = Npc.Repeat;//NPCの判別
            Purchase();//購入処理
            _gold.AddEverySecond(goldPlus);//ItemによるGoldの増加処理
            everySecondPlusGold += goldPlus;//このItemによる毎秒のGold増加数
            //NPCによる敵へのダメージ処理？敵を倒したときにゴールドを得る処理？
            firstClick = false;
        }

        if (_gold.GoldTotalAmount >= _nowPrice && firstClick == false)
        {
            _npc = Npc.Repeat;//NPCの判別
            Purchase();//購入処理
            _gold.AddEverySecond(goldPlus);//ItemによるGoldの増加処理
            everySecondPlusGold += goldPlus;//このItemによる毎秒のGold増加数
            //NPCによる敵へのダメージ処理？敵を倒したときにゴールドを得る処理？
        }

        else
        {
            Debug.Log("コストが足りません");
        }
    }

    public void Upgrade(float x)
    {
        //特定のNPCでスキル選択して使ったときの処理
    }
}