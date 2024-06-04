using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectionInfantrymen : MonoBehaviour
{//������ ��� ����������� ����� � ����� ���������� (������� � ���������)
    [SerializeField] private string EnemyTag = "Enemy";
    private Transform _target; //����
    public Animator Animator; //�������� 
    public Moving Moving;
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangedSpread;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Debug.Log(gameObject + "���� � ������� �������");
            Attack(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Debug.Log(gameObject + "���� ����� �� ���� �������");
            Animator.SetBool("Trigger", false);
            _target = null;
            Moving.AddTarget(_target);
        }
    }

    void Attack(Collider2D collision)
    {
        Transform target = collision.transform;
        _target = target;
        Moving.AddTarget(_target);
        if (Vector2.Distance(transform.position,_target.position) < 0.1)
        {
            Animator.SetBool("Trigger", true);
            Moving.SpeedStop();
        }
    }
}
