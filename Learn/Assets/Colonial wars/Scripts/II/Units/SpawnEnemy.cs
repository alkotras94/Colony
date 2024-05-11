using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт для создания врагов по клику мыши
public class SpawnEnemy : MonoBehaviour
{//Для того чтобы скрипт работал нужно создать 3д обьект и задать ему тег схожий с переменной _enemyFieldTag
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private Camera _camera;
    [SerializeField] private string _enemyFieldTag; // Тег поля врага, для создания врагов только на его поле

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Клие по полю создания врагов");
            RaycastHit hit;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == _enemyFieldTag)
                {
                    Debug.Log("Создание врага");
                    Instantiate(_prefabEnemy, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
