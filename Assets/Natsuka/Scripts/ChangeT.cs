using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeT : MonoBehaviour
{

    public GameObject fpc;
    public GameObject _handPaint;
    public GameObject _zombie;
    public GameObject _thirdTrigger;
    private int _flag = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 newPosition = fpc.transform.position;  // ���݂̈ʒu���R�s�[
        newPosition.y += 3f;  // y���W���X�V
        fpc.transform.position = newPosition;  // �V�����ʒu��ݒ�
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _flag += 1;
            Debug.Log(_flag);
        }
        if (_flag == 3)
        {
            //�������[�v�O��ڈȍ~�̏���
            _handPaint.SetActive(true);
            _zombie.SetActive(true);
            _zombie.GetComponentInChildren<ChasingPlayer>().enabled = true;
            Vector3 newPosition = new Vector3(6, 3, -9);
            _zombie.GetComponent<ZombiePatrol>().transform.position = newPosition;
            _zombie.GetComponent<ZombiePatrol>().enabled = true;
            _zombie.GetComponent<ZombieWalk>().enabled = false;
            _zombie.GetComponent<GameOver>().enabled = false;
            _thirdTrigger.SetActive(true);
        }
    }
}
