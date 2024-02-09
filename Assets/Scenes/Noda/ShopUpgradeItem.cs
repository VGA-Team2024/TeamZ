using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpgradeItem : ShopBase
{
    /// <summary>
    /// ���ӁF���̃N���X�̓V���b�v��Upgrade�A�C�e��Button�ɂ����������ŏ����܂����ύX�_�₲�s����������͖�c�ϑ��Y�܂ł��\���t�����������B
    /// </summary>

    [SerializeField] GameObject ShopBuildingItemObject = null;
    //Shop�ɂ���A�b�v�O���[�h���������A�C�e��������
    ShopBuildingItem shopBuildingItem;
    void Start()
    {
        shopBuildingItem = ShopBuildingItemObject.GetComponent<ShopBuildingItem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickUpgradeButton(string Upgrade)
    {
        shopBuildingItem.resoursePlus *= 2;
        Purchase(Item.Upgrade);
    }
}
