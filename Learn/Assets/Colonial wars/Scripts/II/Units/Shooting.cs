using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //[SerializeField] private GameObject Arrow; // Префаб стрелы
    [SerializeField] private Transform TransformArrow;// Место создания стрелы у лучника
    [SerializeField] private Transform _target;
    [SerializeField] private float _fireInSeconds;
    private float _timeCadr; //Время прошедшее между кадрами
    //private bool _isEnemyFielf = false; //Враг в поле видимости?
    private Pool _pool;

    private void Start()
    {
        _pool = GetComponent<Pool>();
    }
    private void Update()
    {
        /*_timeCadr += Time.deltaTime;
        if (_isEnemyFielf)
        {
            if (_timeCadr >= _fireInSeconds)
            {
                ChecShoot();
                _timeCadr = 0;
            }
        }*/
    }
    public void ChecShoot() //Метод создания стрелы
    {
        _pool.GetFreeElement(TransformArrow.position, _target);
        //GameObject arrow = Instantiate(Arrow, TransformArrow);
        //Arrow ar = arrow.GetComponent<Arrow>();
        //ar.AddTarget(_target);
    }

    public void AddTarget(Transform target) //Вызывается в компоненте ObjectDetection
    {
        _target = target;
    }

    public void IsTheEnemyField()//Враг в поле зрения, метод вызывается в методе ObjectDetection
    {
        //_isEnemyFielf = true;
    }
    public void EnemyOut() //Враг вышел с поле зрения, метод вызывается в методе ObjectDetection
    {
        //_isEnemyFielf = false;
    }
}
