using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //[SerializeField] private GameObject Arrow; // ������ ������
    [SerializeField] private Transform TransformArrow;// ����� �������� ������ � �������
    [SerializeField] private Transform _target;
    [SerializeField] private float _fireInSeconds;
    private float _timeCadr; //����� ��������� ����� �������
    //private bool _isEnemyFielf = false; //���� � ���� ���������?
    private Pool _pool;

    private void Start()
    {
        _pool = GetComponent<Pool>();
    }
    private void Update()
    {
        /*_timeCadr += Time.deltaTime;
        if (_isEnemyFielf)
        {
            if (_timeCadr >= _fireInSeconds)
            {
                ChecShoot();
                _timeCadr = 0;
            }
        }*/
    }
    public void ChecShoot() //����� �������� ������
    {
        _pool.GetFreeElement(TransformArrow.position, _target);
        //GameObject arrow = Instantiate(Arrow, TransformArrow);
        //Arrow ar = arrow.GetComponent<Arrow>();
        //ar.AddTarget(_target);
    }

    public void AddTarget(Transform target) //���������� � ���������� ObjectDetection
    {
        _target = target;
    }

    public void IsTheEnemyField()//���� � ���� ������, ����� ���������� � ������ ObjectDetection
    {
        //_isEnemyFielf = true;
    }
    public void EnemyOut() //���� ����� � ���� ������, ����� ���������� � ������ ObjectDetection
    {
        //_isEnemyFielf = false;
    }
}
