using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>�{�݂̊��N���X</summary>
public class ShopBase : MonoBehaviour
{
    /// <summary>�w�������{�݂̏�����</summary>
    int _level = 0; 
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    /// <summary>�w�������{�݂�A�b�v�O���[�h�̏������㏑�����Ă�������</summary>
    public virtual void ItemProcess()
    {

    }
    /// <summary>�w�������BButton����Ăяo��</summary>
    public void Purchase(Item item)
    {
        //�����Ƀ��\�[�X����������\��
        if (item == Item.Upgrade)//�����A�b�v�O���[�h��������
        {
            //������UI����������
        }
        else
        {
            _level++;
        }
    }
    /// <summary>�w�����̎��</summary>
    public enum Item 
    {
        /// <summary>�A�b�v�O���[�h</summary>
        Upgrade,
        /// <summary>�{�݁A����</summary>
        Building,
    }
}
