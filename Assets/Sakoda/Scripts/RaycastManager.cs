using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastManager
{
    public RaycastHit GetRaycastHitInfo()
    {
        //��ʒ��S����Ray���o���Փ˔�����s��
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10, Color.red);
        //ray����������object�̏����i�[����
        RaycastHit _hitObject;
        //ray���΂�����
        float _playerVisibility = 3.0f;

        if (Physics.Raycast(ray, out _hitObject, _playerVisibility))
        {
            return _hitObject;
        }
        else
        {
            return new RaycastHit(); // �q�b�g��񂪂Ȃ��ꍇ�͋�̏���Ԃ�
        }
    }
}
