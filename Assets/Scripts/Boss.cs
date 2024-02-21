using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 敵のHPの管理
/// </summary>
public class Boss : MonoBehaviour
{
    [Tooltip("敵のHPの管理をするクラスのインスタンス")] public static Boss Instance = default;
    [Header("NPCが与えるダメージ")]
    [SerializeField, Tooltip("NPCが与えるダメージ")] float _subtractHpEverySecond = default;
    [Header("敵のHPの総量")]
    [SerializeField, Tooltip("敵のHPの総量")] double _enemyHpTotalAmount = default;
    [Header("現在のフロア")]
    [SerializeField, Tooltip("現在のフロア")] int _currentFloor = default;
    int _timer;
    public GoldManager _gold;
    [Header("敵のprefab")]
    [SerializeField, Tooltip("敵のprefab")] GameObject _enemyPrefab = default;
    [Tooltip("子オブジェクトでボスの出現位置を決める")] Vector3 _bossPos;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        _currentFloor = 0;
        _subtractHpEverySecond = 0;
        _bossPos = transform.GetChild(0).transform.position;
        EnemyAppear();
    }

    private void Update()
    {
        if (_enemyHpTotalAmount <= 0)
        {
            EnemyDefeat();
            EnemyAppear();
        }
    }

    private void FixedUpdate()
    {
        _timer += (int)Time.deltaTime;
        // 10秒たったら呼び出す
        if (_timer >= 500)
        {
            _enemyHpTotalAmount -= _subtractHpEverySecond;
            _timer = 0;
        }
    }

    /// <summary>
    /// クリック対象をクリックするときに呼ぶ
    /// クリックのたびに敵のHPを減算
    /// </summary>
    /// <param name="value"> 減算する量 </param>
    public void SubtractHp(int value)
    {
        _enemyHpTotalAmount -= value;
    }

    /// <summary>
    /// 10秒ごとにNPCが与えるダメージを増やす関数
    /// </summary>
    /// <param name="value"></param>
    public void SubtractHpEverySecond(float value)
    {
        _subtractHpEverySecond += value;
    }

    /// <summary>
    /// 敵が出現したとき
    /// </summary>
    public void EnemyAppear()
    {
        _currentFloor++;
        Instantiate(_enemyPrefab, _bossPos, Quaternion.identity);
    }

    /// <summary>
    /// 敵が倒れたとき
    /// </summary>
    public void EnemyDefeat()
    {
        Destroy(_enemyPrefab);
        _gold.AddGold(_currentFloor);
    }

}
