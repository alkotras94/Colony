using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{//Скрипт для стрельбы из лука или еще чего нибудь
    [SerializeField] private Transform TransformArrow;// Место создания стрелы у лучника
    [SerializeField] private Transform _target;
    [SerializeField] private float _fireInSeconds;
    private Pool _pool;

    private void Start()
    {
        _pool = GetComponent<Pool>();
    }
    public void ChecShoot() //Метод создания стрелы
    {
        _pool.GetFreeElement(TransformArrow.position, _target);
    }
    public void AddTarget(Transform target) //Вызывается в компоненте ObjectDetection
    {
        _target = target;
    }
}
