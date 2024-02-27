using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingIIArcher : MonoBehaviour
{
    public float Speed; // Скорость лучника
    private Animator _animator;
    public Transform Target; //Цель лучника
    public GameObject Arrow; // Префаб стрелы
    public Transform TransformArrow; // Место создания стрелы у лучника
    public float ArrowForce; //Скорость полета стрелы
    public string EnemyTag; //Тег врагов
    public Turn turn; //Ссылка на компонент поворота

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
            Debug.Log(gameObject + "Враг в тригере");

            ChecShoot();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            Target = null;
            Debug.Log(gameObject + "Враг вышел из зоны действий");
        }
    }
    private void MoveTransform(Transform target) //Передвижение персонажа
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }

    public void ChecShoot() //Метод создания стрелы
    {
        GameObject arrow = Instantiate(Arrow,TransformArrow.position,TransformArrow.rotation);
        Arrow Ar = arrow.GetComponent<Arrow>();
        Ar.AddTarget(Target);
    }
}
