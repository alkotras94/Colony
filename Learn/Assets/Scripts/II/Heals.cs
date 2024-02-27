using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heals : MonoBehaviour
{//Компонент жизней персонажей
    [SerializeField] private int _healts;
    public GameObject _gameObject;

    public void Die() //Метод смерти игрока
    {
        Destroy(gameObject);
    }
    public void TakeDamage(int damage) //Метод получения урона игрока, вызывается в другом компоненте наносящему урон
    {
        _healts -= damage;
        if (_healts == 0)
        {
            Die();
        }
    }
}
