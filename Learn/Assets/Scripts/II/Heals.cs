using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heals : MonoBehaviour
{//��������� ������ ����������
    [SerializeField] private int _healts;

    public void Die() //����� ������ ������
    {
        Destroy(gameObject);
    }
    public void TakeDamage(int damage) //����� ��������� ����� ������, ���������� � ������ ���������� ���������� ����
    {
        _healts -= damage;
        if (_healts == 0)
        {
            Die();
        }
    }
}
