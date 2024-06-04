using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moving : MonoBehaviour
{//������ ������ ��� �� ������ � ������
    [SerializeField] private float _speed; // ��������
    [SerializeField] private Transform _target; //���� ���� ����� ���� (����� �)
    [SerializeField] private Transform _targetFront; //����� ������

    private void Update()
    {
		MoveTransform(_target); // ����� �������
        if (transform.position == _target.position)
        {
            SpeedStop();
        }
    }

    private void MoveTransform(Transform target) //������������ ���������
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
    public void AddTarget(Transform target)//������ ������ ������ �����
    {
        _target = target;
    }
    public void AddSpeedFront() //����� ���������� �������� ����� ������ �������
    {
        _speed = 0.2f;
        _target = _targetFront;
    }
    public void SpeedStop()//�����������
    {
        _speed = 0f;
    }
}