using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectionInfantrymen : MonoBehaviour
{//Скрипт для обнаружения врага и атаки пехотинцев (мечника и копейщика)
    [SerializeField] private string EnemyTag = "Enemy";
    private Transform _target; //Цель
    public Animator Animator; //Анимация 
    public Moving Moving;
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangedSpread;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Debug.Log(gameObject + "Враг в тригере мечника");
            Attack(collision);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Debug.Log(gameObject + "Враг вышел из зоны мечника");
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
