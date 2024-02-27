using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovingII : MonoBehaviour
{   //Скрипт передвижения персонажей и хранения ресурсов у крестьян
    public float Speed; // Скорость юнита
    [SerializeField] private int _resoursFood; //Временные переменные для хранения ресурсов для переноски
    [SerializeField] private int _resoursWood;
    [SerializeField] private int _resoursStone;
    public Transform TargetSclad; //Точка склада
    public Transform TargetIstochnic; //Точка источника 
    private Animator _animator;
    public bool _isMau = true;
    public bool isCome = true; //Переменная для захода в тригер
    public Transform Collecting; // Место сбора

    private void Start()
    {
        _animator = GetComponent<Animator>();
        TargetSclad = GameManager.Instance.Home;
        Collecting = GameManager.Instance.ColectingPeasant;
    }
    private void FixedUpdate()
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
        if (collision.CompareTag("Collecting")) 
        {
            Speed = 0;
        }

        if (collision.CompareTag("Home")) 
        {
            if (_resoursFood == 1)
            {
                GameManager.Instance.Food += _resoursFood;
                _resoursFood = 0;
            }
            if (_resoursWood == 1)
            {
                GameManager.Instance.Wood += _resoursWood;
                _resoursWood = 0;
            }
            if (_resoursStone == 1)
            {
                GameManager.Instance.Stone += _resoursStone;
                _resoursStone = 0;
            }
            _resoursFood = 0;
            _resoursWood = 0;
            _resoursStone = 0;
            isCome = true;
        }

        if (collision.CompareTag("ResoursFood")) //Если попал в тригер камня
        {
            CollectingResourse();
            if (_resoursFood == 0)
            {
                _resoursFood += 1;
            }
        }

        if (collision.CompareTag("ResoursSheet")) //Если попал в тригер камня
        {
            CollectingResourse();
            if (_resoursStone == 0)
            {
                _resoursStone += 1;
            }
        }

        if (collision.CompareTag("ResoursWood")) //Если попал в тригер дерева
        {
            CollectingResourse();
            if (_resoursWood == 0)
            {
                _resoursWood += 1;
            }
        }
    }

    private void Moving()
    {
        if (isCome)
        {
            TurnWithoutResources(TargetIstochnic); //поворот
            if (_isMau)
            {
                MoveTransform(TargetIstochnic);
            }
        }
        if (!isCome)
        {
            _animator.SetBool("AxeBool", false);
            _isMau = true;
            TurningWithResources(TargetIstochnic); //поворот
            MoveTransform(TargetSclad);
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

    public void AddSource() //Этот метод запускается из анимации крестьянина
    {
        //_resours = 1;
        isCome = false;
    }

    public void CollectingResourse() //Метод анимации, движения и поворота персонажа при сборе ресурсов
    {
        _isMau = false;
        if (transform.position.x < GameManager.Instance.Home.position.x)
        {
            _animator.SetBool("AxeBool", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("Забрал ресурс");
        }
        else
        {
            _animator.SetBool("AxeBool", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Забрал ресурс");
        }
    }
}
