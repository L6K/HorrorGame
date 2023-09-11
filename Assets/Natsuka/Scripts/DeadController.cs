using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ���̃N���X�ł̓]���r�Ɍ�����A�]���r�ɎE���ꂽ���̎����̎��_��������ɕύX����
/// </summary>

public class DeadController : MonoBehaviour
{
    Animator _enemyAnime; //�]���r�̃A�j���[�^�[
    GameObject _me; //�J�����̐e
    GameObject _meCamera; //�J����
    Transform _meRotation; //�J�����p�x

    // Start is called before the first frame update
    void Start()
    {
        GameObject _enemy = GameObject.Find("Zombie1"); //�]���r�I�u�W�F�N�g���擾
        if (_enemy != null)
        {
            Debug.Log("�]���r������");
            _enemyAnime = _enemy.GetComponent<Animator>();
        }
        _me = GameObject.Find("FirstPersonController"); //�J�����̐e�I�u�W�F�N�g���擾
        if (_me != null)
        {
            Debug.Log("�J�����̐e������");
            Transform _childTransform = _me.transform.Find("Joint"); // �q�I�u�W�F�N�g�̖��O
            GameObject _tChiledTransform = _childTransform.GameObject();
            Transform childTransform = _tChiledTransform.transform.Find("PlayerCamera");
            if (childTransform != null)
            {
                Debug.Log("�J����������");
                _meCamera = childTransform.GameObject();
            }
        }
    }
    //_enemy�̃A�j���[�^�[��boxing�A�j���[�V�������N�������u�ԁA_meCamera�̃A�j���[�V�������~���āA�J������rotation���グ��

    // Update is called once per frame
    void Update()
    {
        if(_enemyAnime.GetCurrentAnimatorStateInfo(0).IsName("boxing")) //boxing�X�e�[�g�ɑJ�ڂ����u��
        {
            //_meCamera�̃A�j���[�V�������~������
            _meCamera.GetComponent<Animator>().enabled = false;
        }
    }
}
