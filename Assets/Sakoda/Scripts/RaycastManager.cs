using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager
{
    public RaycastHit GetRaycastHitInfo()
    {
        //��ʒ��S����Ray���o���Փ˔�����s��
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        //ray����������object�̏����i�[����
        RaycastHit _hitObject;

        if (Physics.Raycast(ray, out _hitObject))
        {
            return _hitObject;
        }
        else
        {
            return new RaycastHit(); // �q�b�g��񂪂Ȃ��ꍇ�͋�̏���Ԃ�
        }
    }
}
