using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{//������ ��� �������� �� ���� ��� ��� ���� ������
    [SerializeField] private Transform TransformArrow;// ����� �������� ������ � �������
    [SerializeField] private Transform _target;
    [SerializeField] private float _fireInSeconds;
    private Pool _pool;

    private void Start()
    {
        _pool = GetComponent<Pool>();
    }
    public void ChecShoot() //����� �������� ������
    {
        _pool.GetFreeElement(TransformArrow.position, _target);
    }
    public void AddTarget(Transform target) //���������� � ���������� ObjectDetection
    {
        _target = target;
    }
}
