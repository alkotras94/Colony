using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attak
{
    public class Turn : MonoBehaviour
    {//Компонет поворота боевых едениц
        public Transform _targetBarracks; //Сбор бойцов
        public Transform _targetEnemy; // Куда он идет, его цель

        public void TargetEnemy(Transform target) //Метод вызываются в компоненте движения игрока при попадании в тригер врага
        {
            _targetEnemy = target;
        }
        public void TurnAround() //Метод вызываются в компоненте движения игрока при попадании в тригер
        {
            if (transform.position.x > _targetEnemy.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0); //Поворот на лево
            }
            if (transform.position.x < _targetEnemy.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
