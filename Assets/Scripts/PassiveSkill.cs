using UnityEngine;

public class PassiveSkill : MonoBehaviour
{
    [Header("NPCの種類")] [Tooltip("NPCの種類")] 
    public CharacterType _characterType;

    public NpcBase _npcBase;
    public Boss _boss;
    public GoldManager _goldManager;

    private int _npcItems;
    private double _stealGold;
    private float _inflictDamage;

    private void Start()
    {
        _npcItems = _npcBase._items;
        _stealGold = _goldManager._obtainGold;
        _inflictDamage = _boss._subtractHpEverySecond;
    }

    private void Update()
    {
        _npcItems = _npcBase._items;
        _stealGold = _goldManager._obtainGold;
        _inflictDamage = _boss._subtractHpEverySecond;
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
        _boss.SubtractHpEverySecond(Mathf.Pow(_inflictDamage * 1.25f, _npcItems - 1));
        Debug.Log(_inflictDamage);
    }

    void MagePassive()
    {
        _boss._subtractHpEverySecond = Mathf.Pow(_inflictDamage * 1.25f, _npcItems - 1);
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