using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// �W�F�l���b�N���B�����߂Ɍp�����Ă��܂�
/// [System.Serializable]�������̂�Y��Ȃ�
/// </summary>
[System.Serializable]
public class SampleTable : TableBase<Story, int, SamplePair>
{


}

/// <summary>
/// �W�F�l���b�N���B�����߂Ɍp�����Ă��܂�
/// [System.Serializable]�������̂�Y��Ȃ�
/// </summary>
[System.Serializable]
public class SamplePair : KeyAndValue<Story, int>
{

    public SamplePair(Story key, int value) : base(key, value)
    {

    }
}

public class ItemList : MonoBehaviour
{

    //Inspector�ɕ\���ł���f�[�^�e�[�u��
    public SampleTable _item;

    void Awake()
    {
        //���e���
        foreach (KeyValuePair<Story, int> pair in _item.GetTable())
        {
            Debug.Log("Key : " + pair.Key + "  Value : " + pair.Value);
        }
    }

}