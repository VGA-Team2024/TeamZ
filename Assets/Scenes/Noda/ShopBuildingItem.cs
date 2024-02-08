using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopBuildingItem : ShopBase
{
    /// <summary>
    /// ���ӁF���̃N���X�̓V���b�v��Building�A�C�e��Button�ɒ���t�������ŏ����܂����ύX�_�₲�s����������͖�c�ϑ��Y�܂ł��\���t�����������B
    /// </summary>

    [SerializeField] public float resoursePlus = default;
    //resourse�̑�����
    [SerializeField] float shopCost = default;
    //shop�ɂ���Item�̃R�X�g
    [SerializeField] float CostPlus = default;
    //Cost�̑����{��
    [SerializeField] GameObject resourceManagerObject = null;
    //ResourceManager�����Ă�Object���擾����
    ResourceManager resourceManager;
    //ResourceManager�̊֐����擾���邽�߂̓��ꕨ

    void Start()
    {
        resourceManager = resourceManagerObject.GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickBuildingButton (string Building)
    {
        if(resourceManager.ResourceTotalAmount >= shopCost)
        {
            resourceManager.UseResource(shopCost);
            Purchase(Item.Building);
            shopCost *= CostPlus;
            resourceManager.AddEverySecond(resoursePlus);
        }
        else
        {
            Debug.Log("�R�X�g������܂���");
        }
    }
}
