using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゴールドを管理
/// 総数や加算、減算するメソッドを持つ
/// 加算に関する変数（2つ）：毎秒加算する変数・クリックのたびに加算する変数
/// </summary>
public class GoldManager : MonoBehaviour
{
    [Tooltip("ゴールド管理をするクラスのインスタンス")] public static GoldManager Instance = default;
    [Header("ゴールドの総量")]
    [SerializeField, Tooltip("ゴールドの総量")] double _goldTotalAmount = default;
    [Header("テキスト（ゴールドの総量）")]
    [SerializeField, Tooltip("テキスト（ゴールドの総量）")] Text _textGTA = default;
    [Header("10秒ごとに増えるGold")]
    [SerializeField, Tooltip("10秒ごとに増えるGold")] float _addAmountEverySecond = default;
    int _timer;

    #region プロパティ
    /// <summary> リソースの総量 </summary>
    public double GoldTotalAmount { get => _goldTotalAmount; }
    #endregion

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _goldTotalAmount = 10000;
        _addAmountEverySecond = 0;
    }

    void Update()
    {
        _textGTA.text = _goldTotalAmount.ToString("000,000.0");
    }

    private void FixedUpdate()
    {
        _timer += (int)Time.deltaTime;
        // 10秒に一回呼び出す
        if (_timer >= 500)
        {
           _goldTotalAmount += _addAmountEverySecond;
            _timer = 0;
        }
    }

    /// <summary>
    /// 敵が倒れたときに増えるGold
    /// </summary>
    /// <param name="value">現在のフロア</param>>
    public void AddGold(int value)
    {
        double _obtainGold = 0;
        if (value <= 5)
            _obtainGold = 10000 * value;
        else if (value <= 10)
            _obtainGold = 100000 * (value - 5);
        else if (value <= 15)
            _obtainGold = 500000 * (value - 10);
        else if (value <= 20)
            _obtainGold = 10000000 * (value - 15);
        else if (value <= 25)
            _obtainGold = 5000000000 * (value - 20);
        else
            _obtainGold = 1000000000000 * (value - 25);

        _goldTotalAmount += _obtainGold;
    }

    /// <summary>
    /// 10秒ごとに増加するGoldを増やす関数
    /// </summary>
    /// <param name="value"></param>
    public void AddEverySecond(float value)
    {
        _addAmountEverySecond += value;
    }

    /// <summary>
    /// （ショップで）ゴールドを消費する処理
    /// 所持しているゴールドの総量を超えていたら、何もしない
    /// </summary>
    /// <param name="value">消費量</param>
    /// <returns>購入できたか</returns>
    public bool UseGold(float value)
    {
        if (value <= GoldTotalAmount)
        {
            _goldTotalAmount -= value;
            return true;
        }
        else
        {
            return false;
        }
    }
}