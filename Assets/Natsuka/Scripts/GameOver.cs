using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //�]���r��collider�ƃh�A��collider���Փ˂�����Q�[���I�[�o�[
    //�Q�[���I�[�o�[�����玞�Ԃ��~�߂�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // �h�A�Ƃ̏Փ˂𔻒�
        if (other.gameObject.tag == "Door")
        {
            
            SceneManager.LoadScene("GameOver");
            // �����ŉ����̏������s���i�h�A���J����A�]���r���~�߂铙�j
        }
    }
}
