using UnityEngine;

public class PassiveSkill : MonoBehaviour
{
    [Header("NPCの種類")]
    [Tooltip("NPCの種類")]
    public CharacterType characterType;
    public NpcBase _npcBase;
    public Boss _boss;
    public GoldManager _goldManager;
    int _npcLevel;
    double _stealGold;
    float _inflictDamage;

    private void Update()
    {
        _npcLevel = _npcBase._level;
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
        switch (characterType)
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
        _boss.SubtractHpEverySecond(Mathf.Pow(_inflictDamage * 1.25f, _npcLevel - 1));
    }

    void MagePassive()
    {
        _boss._subtractHpEverySecond = Mathf.Pow(_inflictDamage * 1.25f, _npcLevel - 1);
    }

    void ThiefPassive()
    {
      _goldManager.AddEverySecond(((float)_stealGold * 0.0001f) * _npcLevel);
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
