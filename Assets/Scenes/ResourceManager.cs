using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ƒŠƒ\[ƒX‚ğŠÇ—
/// ‘”‚â‰ÁZAŒ¸Z‚·‚éƒƒ\ƒbƒh‚ğ‚Â
/// ‰ÁZ‚ÉŠÖ‚·‚é•Ï”i2‚ÂjF–ˆ•b‰ÁZ‚·‚é•Ï”EƒNƒŠƒbƒN‚Ì‚½‚Ñ‚É‰ÁZ‚·‚é•Ï”
/// </summary>
public class ResourceManager : MonoBehaviour
{
<<<<<<< HEAD
    [Tooltip("ƒŠƒ\[ƒXŠÇ—‚ğ‚·‚éƒNƒ‰ƒX‚ÌƒCƒ“ƒXƒ^ƒ“ƒX")] ResourceManager Instance = default;
=======
    [SerializeField, Tooltip("ƒŠƒ\[ƒX‚Ì‘—Ê")] public static ResourceManager Instance = default;
>>>>>>> 6d490c4 ([update] ã€ŒResourceManager.Instance.é–¢æ•°ã€ã§å‘¼ã¹ã‚‹ã‚ˆã†ã«ã—ãŸã€‚)
    [Header("ƒŠƒ\[ƒX‚Ì‘—Ê")]
    [SerializeField, Tooltip("ƒŠƒ\[ƒX‚Ì‘—Ê")] double _resourceTotalAmount = default;
    [Header("ƒeƒLƒXƒgiƒŠƒ\[ƒX‚Ì‘—Êj")]
    [SerializeField, Tooltip("ƒeƒLƒXƒgiƒŠƒ\[ƒX‚Ì‘—Êj")] Text _textRTA = default;
    [Header("–ˆ•b‰ÁZ‚·‚é‘—Ê")]
    [SerializeField, Tooltip("–ˆ•b‰ÁZ‚·‚é‘—Ê")] float _addAmountEverySecond = default;

    #region ƒvƒƒpƒeƒB
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
        // ŠÔŒo‰ß‚Æ‚Æ‚à‚É‰ÁZ
        _resourceTotalAmount += _addAmountEverySecond * Time.deltaTime;
        _textRTA.text = _resourceTotalAmount.ToString("000,000.0");
    }

    /// <summary>
    /// –ˆ•b‰ÁZ‚·‚é‚Æ‚«‚ÌA‰ÁZ—Ê‚ğ‘‚â‚·ŠÖ”
    /// </summary>
    /// <param name="value"></param>
    public void AddEverySecond(float value)
    {
        _addAmountEverySecond += value;
    }

    /// <summary>
    /// ƒNƒŠƒbƒN‘ÎÛ‚ğƒNƒŠƒbƒN‚·‚é‚Æ‚«‚ÉŒÄ‚Ô
    /// ƒNƒŠƒbƒN‚Ì‚½‚Ñ‚É‰ÁZ
    /// </summary>
    /// <param name="value"></param>
    public void AddResource(int value)
    {
        _resourceTotalAmount += value;
    }

    /// <summary>
    /// iƒVƒ‡ƒbƒv‚ÅjƒŠƒ\[ƒX‚ğÁ”ï‚·‚éˆ—
    /// Š‚µ‚Ä‚¢‚éƒŠƒ\[ƒX‚Ì‘—Ê‚ğ’´‚¦‚Ä‚¢‚½‚çA‰½‚à‚µ‚È‚¢
    /// </summary>
    /// <param name="value">Á”ï—Ê</param>
    public void UseResource(float value)
    {
        if (value <= ResourceTotalAmount)
            _resourceTotalAmount -= value;
        else
            Debug.LogWarning("ƒRƒXƒg‚ªŠ‚µ‚Ä‚¢‚éƒŠƒ\[ƒX—Ê‚ğ’´‚¦‚Ä‚¢‚Ü‚·B");
    }
}