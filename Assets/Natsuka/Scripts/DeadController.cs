using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// ���̃N���X�ł̓]���r�Ɍ�����A�]���r�ɎE���ꂽ���̎����̎��_��������ɕύX����
/// �E���ꂽ���ʂ��Ó]���A�^�C�g���ɖ߂�{�^��������Q�[���I�[�o�[��ʂ��\�������
/// </summary>

public class DeadController : MonoBehaviour
{
    Animator _enemyAnime; //�]���r�̃A�j���[�^�[
    GameObject _me; //�J�����̐e
    GameObject _meCamera; //�J����
    int flag = 0;
    public Image _blackOverlay;
    public float _fadeSpeed = 0.5f;
    public TextMeshProUGUI _gameOver;
    public Button _backToTitle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        // �}�E�X�J�[�\�������b�N
        Cursor.lockState = CursorLockMode.Locked;

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
                Animator animator = _meCamera.GetComponent<Animator>();
                animator.SetLayerWeight(1, 1);
                animator.SetLayerWeight(2, 1);
            }
        }
    }
    //_enemy�̃A�j���[�^�[��boxing�A�j���[�V�������N�������u�ԁA_meCamera�̃A�j���[�V�������~���āA�J������rotation���グ��

    // Update is called once per frame
    void Update()
    {
        if(_enemyAnime.GetCurrentAnimatorStateInfo(0).IsName("boxing")) //boxing�X�e�[�g�ɑJ�ڂ����u��
        {
            Debug.Log("keri");
            flag += 1;
            if(flag==1)
            {
                //_meCamera�̃A�j���[�V�������~������
                StartCoroutine(SwitchCameraAnimation());
            }
            Color overlayColor = _blackOverlay.color;
            overlayColor.a += _fadeSpeed * Time.deltaTime;
            overlayColor.a = Mathf.Clamp01(overlayColor.a);
            _blackOverlay.color = overlayColor;
            if(overlayColor.a >= 1f)
            {
                // �}�E�X�J�[�\����\����Ԃɂ���
                Cursor.visible = true;

                // �}�E�X�J�[�\���̃��b�N����������
                Cursor.lockState = CursorLockMode.None;
                _gameOver.gameObject.SetActive(true);
                _backToTitle.gameObject.SetActive(true);
            }


        }
    }
    IEnumerator SwitchCameraAnimation()
    {
        yield return new WaitForSeconds(0.5f);

        Animator animator = _meCamera.GetComponent<Animator>();
        animator.SetLayerWeight(2, 0);
        Debug.Log("������|��܂�");
        animator.SetBool("shake", false);
        animator.SetTrigger("falldown");

        Debug.Log("Layer 0 weight: " + animator.GetLayerWeight(0));
        Debug.Log("Layer 1 weight: " + animator.GetLayerWeight(1));
    }
}
