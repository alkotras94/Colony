using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moving : MonoBehaviour
{//Скрипт ходьбы для ИИ врагов и игрока
    [SerializeField] private float _speed; // Скорость
    //[SerializeField] private Transform _target; //Цель куда нужно идти (Точка Б)
    private Animator _animator; // Для анимации ходьбы
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
		//MoveTransform(_target); // Вызов функции
    }
    
    private void MoveTransform(Transform target) //Передвижение персонажа
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
}