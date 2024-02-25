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
                    _bossHp = 0;
                }
                break;
            case SkillType.Steel:
                if(100 < _level)
                {
                    _totalGold += _stealGold * 10;
                }
                break;
            case SkillType.Smash:
                if(0 < _level)
                {
                    _boss.SubtractHp((int)_damage * 10);
                }
                break;
        }
    }
}
