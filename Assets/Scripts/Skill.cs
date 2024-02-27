using UnityEngine;

public class Skill : NpcBase
{
    ///<summary>resourseの増加数</summary>
    [SerializeField] public float _goldPlus = default;

    /// <summary>ResourceManagerがついてるObjectを取得する</summary>
    [Header("GoldManagerが入ったObjectを入れてください")] 
    [SerializeField] GameObject _goldManagerObject = null;

    /// <summary>"この施設によって"1秒間に生成されるResourceの数</summary>
    [HideInInspector] [Header("Publicだけどいじらないで")] 
    public float everySecondPlusGold = default;

    bool _firstClick = true;

    void Start()
    {
        //GoldManagerにアクセス
        _gold = _goldManagerObject.GetComponent<GoldManager>();
    }

    //最初は初期値とゴールドの総量を比較する
    public void OnClickSkillButton(string Building)
    {
        if (_gold.GoldTotalAmount >= _price && _firstClick == true)
        {
            _npc = Npc.Repeat; //NPCの判別
            Purchase(); //購入処理
            _gold.AddEverySecond(_goldPlus); //ItemによるGoldの増加処理
            everySecondPlusGold += _goldPlus; //このItemによる毎秒のGold増加数
            _firstClick = false;
        }

        else if (_gold.GoldTotalAmount >= _nowPrice && _firstClick == false)
        {
            _npc = Npc.Repeat; //NPCの判別
            Purchase(); //購入処理
            _gold.AddEverySecond(_goldPlus); //ItemによるGoldの増加処理
            everySecondPlusGold += _goldPlus; //このItemによる毎秒のGold増加数
        }

        else
        {
            Debug.Log("コストが足りません");
        }
    }

    //アップグレードアイテムを使ったときの処理
    public void Upgrade(float x)
    {
        _gold.AddEverySecond(everySecondPlusGold);
        everySecondPlusGold *= x;
    }
}