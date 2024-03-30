using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingIIArcher : MonoBehaviour
{
    //��������� ����
    public float Speed; // �������� �������
    public Transform Target; //���� �������
    public GameObject Arrow; // ������ ������
    public Transform TransformArrow; // ����� �������� ������ � �������
    public string EnemyTag; //��� ������
    public float SecondCadr;
    public float SecondShoot;

    //��������� ����
    private Turn turn; //������ �� ��������� ��������
    private Animator _animator;
    private void Start()
    {
        turn = GetComponent<Turn>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SecondCadr += Time.deltaTime;
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
            if (SecondCadr > SecondShoot)
            {
                ChecShoot();
                _animator.SetBool("isEnemy", true);
                SecondCadr = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Target = null;
            _animator.SetBool("isEnemy", false);
            Debug.Log(gameObject + "���� ����� �� ���� ��������");
        }
    }
    private void MoveTransform(Transform target) //������������ ���������
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    public void ChecShoot() //����� �������� ������
    {
        GameObject arrow = Instantiate(Arrow, TransformArrow);
        Arrow Ar = arrow.GetComponent<Arrow>();
        Ar.AddTarget(Target);
    }
}
