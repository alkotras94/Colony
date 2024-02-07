using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingII : MonoBehaviour
{   //Скрипт передвижения персонажей и хранения ресурсов у крестьян
    public float Speed; // Скорость юнита
    [SerializeField] private int _resours; // временная ячейка для хранения переноски листа 
    public Transform TargetSclad; //Точка склада
    public Transform TargetIstochnic; //Точка источника 
    private Animator _animator;
    bool _isMau = true;
    public Transform Collecting; // Место сбора
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        TargetSclad = GameManager.Instance.Home;
        Collecting = GameManager.Instance.ColectingPeasant;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

        if (TargetIstochnic == null)
        {
            MoveTransform(Collecting);
            //Debug.Log("Источника нет");
        }
        else
        {
            Moving();
            //Debug.Log("Источник есть");
        }
            
    }

    //При входе в тригер персонаж останавливается, воспроизводит анимацию забирает ресурс и уходи на склад
    //У обьекта должен быть коллайдер с галочуой Тригер
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collider")) //Чтобы голова не находилась сзади туловища другого персонажа
        {
            _spriteRenderer.sortingOrder = 2;
            Debug.Log("Колайдер соприкоснулся");
        }
        if (collision.CompareTag("Collecting")) 
        {
            Speed = 0;
        }

        if (collision.CompareTag("Home")) 
        {
            _resours = 0;
        }

        if (collision.CompareTag("ResoursSheet")) //Если попал в тригер камня
        {
            CollectingResourse();
        }

        if (collision.CompareTag("ResoursWood")) //Если попал в тригер дерева
        {
            CollectingResourse();
        }
    }

    private void Moving()
    {
        if (_resours == 0)
        {
            TurnWithoutResources(TargetIstochnic); //поворот
            if (_isMau)
            {
                MoveTransform(TargetIstochnic);
            }
        }
        if (_resours == 1)
        {
            _animator.SetBool("AxeBool", false);
            _isMau = true;
            TurningWithResources(TargetIstochnic); //поворот
            MoveTransform(TargetSclad);

            /*if (transform.position == TargetSclad.position)
            {
                //_resoursList.AddList(_resours);
                _resours = 0;
                Debug.Log("Принес лист");
            }*/
        }
    }

    private void MoveTransform(Transform target) //Передвижение персонажа
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }
    
    public void TurnWithoutResources(Transform source) //Поворот обекта без ресурсов
    {
            if (transform.position.x > source.position.x)
             {
                transform.rotation = Quaternion.Euler(0,180,0); //поворот персонажа
             }
             else
             {
                 transform.rotation = Quaternion.Euler(0, 0, 0);
             }
    }

    public void TurningWithResources(Transform source) //Поворот обекта с ресурсами
    {
            if (transform.position.x < source.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
    }

    public void AddSource()
    {
        _resours = 1;
    }

    public void CollectingResourse() //Метод анимации, движения и поворота персонажа при сборе ресурсов
    {
        _isMau = false;
        if (transform.position.x < GameManager.Instance.Home.position.x)
        {
            _animator.SetBool("AxeBool", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("Забрал лист");
        }
        else
        {
            _animator.SetBool("AxeBool", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Забрал лист");
        }
    }
}
