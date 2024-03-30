using UnityEngine;
public class Arrow : MonoBehaviour
{
    public int Damage; //������� ������� �����
    public float Speed; //�������� ������
    public Transform Target; //���� ������
    public string EnemyTag; //

    private void Update()
    {
        /*if (transform.position == Target.position)
        {
            Destroy(gameObject);
        }
        else
        {
            MoveTowardsArrow();
            PursuitOfTheArrow();
        }*/
        /*try
        {
            MoveTowardsArrow();
            PursuitOfTheArrow();
        }
        catch(MissingReferenceException)
        {
            Destroy(gameObject);
        }*/
        MoveTowardsArrow();
        PursuitOfTheArrow();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(EnemyTag))
        {
            Heals heals = collision.gameObject.GetComponent<Heals>();
            heals.TakeDamage(Damage);
            Destroy(gameObject);
            Debug.Log("������ �����");
        }
        Debug.Log("������ �����");
    }

    public void AddTarget(Transform target) //����� ���������� � ������ ����������
    {
        Target = target;
    }
    public void MoveTowardsArrow()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
    }

    public void PursuitOfTheArrow() //����� ������������� ������ �� ����
    {
        var direction = Target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //Debug.Log(angle);
    }
}
