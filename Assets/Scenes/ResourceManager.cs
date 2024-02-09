using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���\�[�X���Ǘ�
/// ��������Z�A���Z���郁�\�b�h������
/// ���Z�Ɋւ���ϐ��i2�j�F���b���Z����ϐ��E�N���b�N�̂��тɉ��Z����ϐ�
/// </summary>
public class ResourceManager : MonoBehaviour
{
    [Tooltip("���\�[�X�Ǘ�������N���X�̃C���X�^���X")] public static ResourceManager Instance = default;
    [Header("���\�[�X�̑���")]
    [SerializeField, Tooltip("���\�[�X�̑���")] double _resourceTotalAmount = default;
    [Header("�e�L�X�g�i���\�[�X�̑��ʁj")]
    [SerializeField, Tooltip("�e�L�X�g�i���\�[�X�̑��ʁj")] Text _textRTA = default;
    [Header("���b���Z���鑍��")]
    [SerializeField, Tooltip("���b���Z���鑍��")] float _addAmountEverySecond = default;

    #region �v���p�e�B
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
        // ���Ԍo�߂ƂƂ��ɉ��Z
        _resourceTotalAmount += _addAmountEverySecond * Time.deltaTime;
        _textRTA.text = _resourceTotalAmount.ToString("000,000.0");
    }

    /// <summary>
    /// ���b���Z����Ƃ��́A���Z�ʂ𑝂₷�֐�
    /// </summary>
    /// <param name="value"></param>
    public void AddEverySecond(float value)
    {
        _addAmountEverySecond += value;
    }

    /// <summary>
    /// �N���b�N�Ώۂ��N���b�N����Ƃ��ɌĂ�
    /// �N���b�N�̂��тɉ��Z
    /// </summary>
    /// <param name="value"></param>
    public void AddResource(int value)
    {
        _resourceTotalAmount += value;
    }

    /// <summary>
    /// �i�V���b�v�Łj���\�[�X������鏈��
    /// �������Ă��郊�\�[�X�̑��ʂ𒴂��Ă�����A�������Ȃ�
    /// </summary>
    /// <param name="value">�����</param>
    public void UseResource(float value)
    {
        if (value <= ResourceTotalAmount)
            _resourceTotalAmount -= value;
        else
            Debug.LogWarning("�R�X�g���������Ă��郊�\�[�X�ʂ𒴂��Ă��܂��B");
    }
}