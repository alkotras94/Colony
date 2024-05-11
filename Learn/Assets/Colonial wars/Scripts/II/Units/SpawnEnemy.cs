using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ��� �������� ������ �� ����� ����
public class SpawnEnemy : MonoBehaviour
{//��� ���� ����� ������ ������� ����� ������� 3� ������ � ������ ��� ��� ������ � ���������� _enemyFieldTag
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private Camera _camera;
    [SerializeField] private string _enemyFieldTag; // ��� ���� �����, ��� �������� ������ ������ �� ��� ����

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("���� �� ���� �������� ������");
            RaycastHit hit;

            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == _enemyFieldTag)
                {
                    Debug.Log("�������� �����");
                    Instantiate(_prefabEnemy, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
