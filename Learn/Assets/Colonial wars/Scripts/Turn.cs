using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attak
{
    public class Turn : MonoBehaviour
    {//�������� �������� ������ ������
        public Transform _targetBarracks; //���� ������
        public Transform _targetEnemy; // ���� �� ����, ��� ����

        public void TargetEnemy(Transform target) //����� ���������� � ���������� �������� ������ ��� ��������� � ������ �����
        {
            _targetEnemy = target;
        }
        public void TurnAround() //����� ���������� � ���������� �������� ������ ��� ��������� � ������
        {
            if (transform.position.x > _targetEnemy.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0); //������� �� ����
            }
            if (transform.position.x < _targetEnemy.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
