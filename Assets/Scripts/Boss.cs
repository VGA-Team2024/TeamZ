﻿using System.Collections;
using UnityEngine;
using TMPro;

/// <summary>
/// 敵のHPの管理 敵の出現、消滅
/// </summary>
public class Boss : MonoBehaviour
{
    [Tooltip("敵のHPの管理をするクラスのインスタンス")] private static Boss Instance = default;

    [Header("NPCが与えるダメージ")] [SerializeField, Tooltip("NPCが与えるダメージ")]
    public float _subtractHpEverySecond = default;

    [Header("敵のHPの総量")] [SerializeField, Tooltip("敵のHPの総量")]
    public double _enemyHpTotalAmount = default;

    [Header("現在のフロア")] [SerializeField, Tooltip("現在のフロア")]
    int _currentFloor = default;

    [Header("現在のベースフロア")] [SerializeField, Tooltip("現在のベースフロア")]
    int _baseFloor = default;

    [Header("敵のprefabの配列")] [SerializeField, Tooltip("敵のprefabの配列")]
    GameObject[] _enemyList = default;

    [SerializeField, Tooltip("呼び出す敵のprefab")]
    public int _currentEnemy = default;

    [Header("テキスト（敵のHP）")] [SerializeField, Tooltip("テキスト（敵のHP）")]
    TMP_Text _bossHpText = default;

    public float _timer;
    public GoldManager _gold;
    private bool _isCoroutine = false;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }

    private void Start()
    {
        _currentFloor = 0;
        _baseFloor = 0;
        _currentEnemy = -1;
        EnemyAppear();
    }

    private void Update()
    {
        _bossHpText.text = _enemyHpTotalAmount.ToString();
        if (_enemyHpTotalAmount <= 0 && _currentFloor != 31 && !_isCoroutine)
        {
            // 敵が消えてから数秒後に出現
            StartCoroutine(Coroutine());
        }
        else if (_currentFloor == 31)
        {
            EnemyDefeat();
            Debug.Log("GameClear");
        }
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= 10f)
        {
            //約10秒
            _enemyHpTotalAmount -= _subtractHpEverySecond;
            _timer = 0f;
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
        //Debug.Log(_subtractHpEverySecond);
    }

    /// <summary>
    /// 敵が出現したとき
    /// </summary>
    public void EnemyAppear()
    {
        _currentFloor++;
        if (_currentFloor % 5 == 1) // 現在のフロアがベースフロア(1,6,11,16,21,26)になったときにベースフロアを更新
        {
            _baseFloor = _currentFloor;
            _currentEnemy++; // 呼び出す敵のindexも更新
        }

        _enemyList[_currentEnemy].gameObject.SetActive(true);
        _gold.DropGold(_currentFloor);
        switch (_baseFloor) // ボスのHPの計算
        {
            case 1:
                _enemyHpTotalAmount = 100 * _currentFloor;
                break;
            case 6:
                _enemyHpTotalAmount = 1000 * (double)Mathf.Pow(1.5f, (_currentFloor - 6));
                break;
            case 11:
                _enemyHpTotalAmount = 10000 * Mathf.Pow(2, (_currentFloor - 11));
                break;
            case 16:
                _enemyHpTotalAmount = 250000 * Mathf.Pow(2, (_currentFloor - 16));
                break;
            case 21:
                _enemyHpTotalAmount = 50000000 * Mathf.Pow(2, (_currentFloor - 21));
                break;
            case 26:
                _enemyHpTotalAmount = 1000000000 * Mathf.Pow(10, (_currentFloor - 26));
                break;
        }
    }

    /// <summary>
    /// 敵が倒れたとき
    /// </summary>
    private void EnemyDefeat()
    {
        _enemyList[_currentEnemy].gameObject.SetActive(false);
        _gold.AddGold();
    }

    /// <summary>
    /// 敵が倒れた後1秒後に敵が出現します
    /// </summary>
    /// <returns></returns>
    IEnumerator Coroutine()
    {
        _isCoroutine = true;
        EnemyDefeat();
        yield return new WaitForSeconds(1);
        EnemyAppear();
        _isCoroutine = false;
    }
}