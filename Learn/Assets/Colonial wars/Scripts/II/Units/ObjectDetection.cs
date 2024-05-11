using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{//Скрипт для обнаружения врага
    [SerializeField] private string EnemyTag = "Enemy";
	[SerializeField] private Shooting _shoting; 
    private Transform _target; //Цель
    public Animator Animator; //Анимация 


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Debug.Log(gameObject + "Враг в тригере");
            Animator.SetBool("Trigger",true);
            Transform target = collision.transform;
            _target = target;
            _shoting.AddTarget(_target);
            //_shoting.IsTheEnemyField();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Debug.Log(gameObject + "Враг вышел из зоны");
            Animator.SetBool("Trigger", false);
            _target = null;
            //_shoting.EnemyOut();
        }
    }
}
