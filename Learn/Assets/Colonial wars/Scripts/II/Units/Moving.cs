using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Moving : MonoBehaviour
{//Скрипт ходьбы для ИИ врагов и игрока
    [SerializeField] private float _speed; // Скорость
    [SerializeField] private Transform _target; //Цель куда нужно идти (Точка Б)
    [SerializeField] private Transform _targetFront; //Линия фронта

    private void Update()
    {
		MoveTransform(_target); // Вызов функции
        if (transform.position == _target.position)
        {
            SpeedStop();
        }
    }

    private void MoveTransform(Transform target) //Передвижение персонажа
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
    public void AddTarget(Transform target)//Задаем таргет нашему юниту
    {
        _target = target;
    }
    public void AddSpeedFront() //Метод добавления скорости через другие скрипты
    {
        _speed = 0.2f;
        _target = _targetFront;
    }
    public void SpeedStop()//Остановится
    {
        _speed = 0f;
    }
}