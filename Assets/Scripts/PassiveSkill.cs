using UnityEngine;

public class PassiveSkill : MonoBehaviour
{
    public NpcBase _npcBase;
    public Boss _boss;
    public GoldManager _goldManager;
    public int _npcLevel;
    public double _bossGold;
    public float _damage;

    void Start()
    {
        _npcLevel = _npcBase._level;
        _bossGold = _goldManager._obtainGold;
       _damage = _boss._subtractHpEverySecond;
    }
    public enum CharacterType
    {
        Warrior,
        Mage,
        Thief,
        Hermit,
        Bard
    }

    public CharacterType characterType;
    public int _goldCost;
    public float _damageMultiplier;
    public int _levelRequirement;

    public void UseSkill()
    {

        // レベル要件をチェック
        if (_npcLevel < _levelRequirement)
        {
            Debug.Log("Insufficient level to use this skill.");
            return;
        }

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
        _boss.SubtractHpEverySecond(Mathf.Pow(1.25f, _npcLevel - 1));
    }

    void MagePassive()
    {
        _boss.SubtractHpEverySecond(Mathf.Pow(1.25f, _npcLevel - 1));
    }

    void ThiefPassive()
    {
      _goldManager.AddEverySecond(((float)_bossGold * 0.0001f) * _npcLevel);
    }

    void HermitPassive()
    {
        Debug.Log("Skill unlocked!");
    }

    void BardPassive()
    {
        // 例えば、NPCの効果を2倍にする処理をここに記述する
        Debug.Log("NPC effects modified.");
    }
}
