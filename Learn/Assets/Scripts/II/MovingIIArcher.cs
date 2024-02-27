using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingIIArcher : MonoBehaviour
{
    public float Speed; // �������� �������
    private Animator _animator;
    public Transform Target; //���� �������
    public GameObject Arrow; // ������ ������
    public Transform TransformArrow; // ����� �������� ������ � �������
    public float ArrowForce; //�������� ������ ������
    public string EnemyTag; //��� ������
    public Turn turn; //������ �� ��������� ��������

    private void Start()
    {
        turn = GetComponent<Turn>();
    }
    private void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            ChecShoot();
        }*/
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Transform transformEnemy = collision.transform;
            Target = transformEnemy;
            turn.TargetEnemy(Target);
            turn.TurnAround();
            Debug.Log(gameObject + "���� � �������");

            ChecShoot();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Target = null;
            Debug.Log(gameObject + "���� ����� �� ���� ��������");
        }
    }
    private void MoveTransform(Transform target) //������������ ���������
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    public void ChecShoot() //����� �������� ������
    {
        GameObject arrow = Instantiate(Arrow,TransformArrow.position,TransformArrow.rotation);
        Arrow Ar = arrow.GetComponent<Arrow>();
        Ar.AddTarget(Target);
    }
}
