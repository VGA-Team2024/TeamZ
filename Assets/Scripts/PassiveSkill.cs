using UnityEngine;

public class PassiveSkill : MonoBehaviour
{
    [Header("NPCの種類")] [Tooltip("NPCの種類")] 
    public CharacterType _characterType;

    [Header("対応するManager,対応するNPC")] [Tooltip("対応するManager,対応するNPC")]
    public NpcBase _npcBase;
    public GoldManager _goldManager;
    public Boss _boss;

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
        Wizard,
        Thief,
        Hermit,
        Bard
    }

    public void UseSkill()
    {
        if(_npcItems > 0) //Level:1 からスキルが発動
        {
            // スキルの種類に応じて処理を実行
            switch (_characterType)
            {
                case CharacterType.Warrior:
                    WarriorPassive();
                    break;
                case CharacterType.Wizard:
                    WizardPassive();
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
    }

    void WarriorPassive()
    {
        _boss.SubtractHpEverySecond(Mathf.Pow(_inflictDamage * 1.25f, _npcItems));
        Debug.Log(_inflictDamage);
    }

    void WizardPassive()
    {
        _boss._subtractHpEverySecond = Mathf.Pow(_inflictDamage * 1.25f, _npcItems);
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