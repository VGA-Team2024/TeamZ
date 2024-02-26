using Unity.VisualScripting;
using UnityEngine;

public class HermitSkill : NpcBase
{
    [Header("Skillの種類")]
    [Tooltip("Skillの種類")]
    public SkillType skillType;
    public Boss _boss;
    float _damage;
    double _bossHp;
    double _stealGold;
    double _totalGold;
    public float _cooldown;
    private float _lastUsedTime;

    private void Start()
    {
        _damage = _boss._subtractHpEverySecond;
        _stealGold = _gold._obtainGold;
        _totalGold = _gold._goldTotalAmount;
        _bossHp = _boss._enemyHpTotalAmount;
    }
    private void Update()
    {
        _damage = _boss._subtractHpEverySecond;
        _stealGold = _gold._obtainGold;
        _totalGold = _gold._goldTotalAmount;
        _bossHp = _boss._enemyHpTotalAmount;
    }
    public enum SkillType
    {
        Smash,
        Steel,
        Destroy
    }

    public void UseSkill()
    {
        switch (skillType)
        {
            case SkillType.Destroy:
                if(1000 < _level)
                {
                    CheckCoolDowon();
                    _bossHp = 0;
                }
                break;
            case SkillType.Steel:
                if(100 < _level)
                {
                    CheckCoolDowon();
                    _totalGold += _stealGold * 10;
                }
                break;
            case SkillType.Smash:
                if(0 < _level)
                {
                    CheckCoolDowon();
                    _boss.SubtractHp((int)_damage * 10);
                }
                break;
        }
    }
    private void CheckCoolDowon()
    {
        // スキルのクールダウンをチェック
        if (Time.time - _lastUsedTime < _cooldown)
        {
            Debug.Log("Skill is on cooldown.");
            return;
        }
    }
}
