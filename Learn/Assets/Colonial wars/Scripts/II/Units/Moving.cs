using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moving : MonoBehaviour
{//������ ������ ��� �� ������ � ������
    [SerializeField] private float _speed; // ��������
    //[SerializeField] private Transform _target; //���� ���� ����� ���� (����� �)
    private Animator _animator; // ��� �������� ������
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
		//MoveTransform(_target); // ����� �������
    }
    
    private void MoveTransform(Transform target) //������������ ���������
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
}