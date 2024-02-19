using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゴールドを管理
/// 総数や加算、減算するメソッドを持つ
/// 加算に関する変数（2つ）：毎秒加算する変数・クリックのたびに加算する変数
/// </summary>
public class GoldManager : MonoBehaviour
{
    [Tooltip("リソース管理をするクラスのインスタンス")] public static GoldManager Instance = default;
    [Header("ゴールドの総量")]
    [SerializeField, Tooltip("ゴールドの総量")] double _goldTotalAmount = default;
    [Header("テキスト（ゴールドの総量）")]
    [SerializeField, Tooltip("テキスト（ゴールドの総量）")] Text _textRTA = default;
    [Header("毎秒加算する総量")]
    [SerializeField, Tooltip("毎秒加算する総量")] float _addAmountEverySecond = default;
    [Header("敵のHPの総量")]
    [SerializeField, Tooltip("敵のHPの総量")] double _enemyHpTotalAmount = default;

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
        _goldTotalAmount = 0;
        _addAmountEverySecond = 0;
    }

    void Update()
    {
        // 時間経過とともに加算
        //_goldTotalAmount += _addAmountEverySecond * Time.deltaTime;
        _textRTA.text = _goldTotalAmount.ToString("000,000.0");
    }

    /// <summary>
    /// 毎秒加算するときの、加算量を増やす関数
    /// </summary>
    /// <param name="value"></param>
    public void AddEverySecond(float value)
    {
        _addAmountEverySecond += value;
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
            Debug.LogWarning("コストが、所持しているリソース量を超えています。");
            return false;
        }
    }
}