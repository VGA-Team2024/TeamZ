using UnityEngine;

public class PassiveSkill : Boss
{
    [Header("NPCの種類")] [Tooltip("NPCの種類")] 
    public CharacterType _characterType;

    public NpcBase _npcBase;
    public GoldManager _goldManager;

    private int _npcItems;
    private double _stealGold;

    private void Start()
    {
        _npcItems = _npcBase._items;
        _stealGold = _goldManager._obtainGold;
    }

    private void Update()
    {
        _npcItems = _npcBase._items;
        _stealGold = _goldManager._obtainGold;
    }

    public enum CharacterType
    {
        Warrior,
        Mage,
        Thief,
        Hermit,
        Bard
    }

    public void UseSkill()
    {
        // スキルの種類に応じて処理を実行
        switch (_characterType)
        {
            case CharacterType.Warrior:
                WarriorPassive();
                break;
            case CharacterType.Mage:
                MagePassive();
                break;
            case CharacterType.Thief:
                ThiefPassive();
                break;
            case CharacterType.Hermit:
                HermitPassive();
                break;
            case CharacterType.Bard:
                BardPassive();
                break;
            default:
                Debug.LogError("Invalid character type.");
                break;
        }
    }

    void WarriorPassive()
    {
        SubtractHpEverySecond(Mathf.Pow(_subtractHpEverySecond * 1.25f, _npcItems - 1));
        Debug.Log(_subtractHpEverySecond);
    }

    void MagePassive()
    {
        _subtractHpEverySecond = Mathf.Pow(_subtractHpEverySecond * 1.25f, _npcItems - 1);
    }

    void ThiefPassive()
    {
        _goldManager.AddEverySecond(((float)_stealGold * 0.0001f) * _npcItems);
    }

    void HermitPassive()
    {
        UseSkill();
        Debug.Log("Skill unlocked!");
    }

    void BardPassive()
    {
        // 例えば、NPCの効果を2倍にする処理をここに記述する
    }
}