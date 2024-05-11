using UnityEngine;
using System;
public class Arrow : MonoBehaviour
{
    [SerializeField] private int _damage; //������� ������� �����
    [SerializeField] private float _speed; //�������� ������
    [SerializeField] private string _enemyTag; //��� ����� �������� ����� ������� ����
    private Transform _target; //���� ������
    private PoolObject _poolObject;

    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
    }
    private void Update()
    {
        try
        {
            MoveTowardsArrow();
            PursuitOfTheArrow();
        }
        catch (MissingReferenceException)
        {
            _poolObject.ReturnToPool();
        }
        if (_target == null)
        {
            _poolObject.ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_enemyTag))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(_damage);
            _poolObject.ReturnToPool();
            Debug.Log("������ �����");
        }
        Debug.Log("������ ����� �� �� ����");
    }

    public void AddTarget(Transform target) ////���������� � ���������� Shooting
    {
        _target = target;
    }
    public void MoveTowardsArrow()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void PursuitOfTheArrow() //����� ������������� ������ �� ����
    {
        var direction = _target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
