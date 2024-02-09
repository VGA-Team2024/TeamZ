using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// リソースを管理
/// 総数や加算、減算するメソッドを持つ
/// 加算に関する変数（2つ）：毎秒加算する変数・クリックのたびに加算する変数
/// </summary>
public class ResourceManager : MonoBehaviour
{
    [Tooltip("リソース管理をするクラスのインスタンス")] public static ResourceManager Instance = default;
    [Header("リソースの総量")]
    [SerializeField, Tooltip("リソースの総量")] double _resourceTotalAmount = default;
    [Header("テキスト（リソースの総量）")]
    [SerializeField, Tooltip("テキスト（リソースの総量）")] Text _textRTA = default;
    [Header("毎秒加算する総量")]
    [SerializeField, Tooltip("毎秒加算する総量")] float _addAmountEverySecond = default;

    #region プロパティ
    public double ResourceTotalAmount { get => _resourceTotalAmount; /*set => _resourceTotalAmount = value;*/ }
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
        _resourceTotalAmount = 0;
        _addAmountEverySecond = 0;
    }

    void Update()
    {
        // 時間経過とともに加算
        _resourceTotalAmount += _addAmountEverySecond * Time.deltaTime;
        _textRTA.text = _resourceTotalAmount.ToString("000,000.0");
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
    /// クリックのたびに加算
    /// </summary>
    /// <param name="value"></param>
    public void AddResource(int value)
    {
        _resourceTotalAmount += value;
    }

    /// <summary>
    /// （ショップで）リソースを消費する処理
    /// 所持しているリソースの総量を超えていたら、何もしない
    /// </summary>
    /// <param name="value">消費量</param>
    public void UseResource(float value)
    {
        if (value <= ResourceTotalAmount)
            _resourceTotalAmount -= value;
        else
            Debug.LogWarning("コストが所持しているリソース量を超えています。");
    }
}