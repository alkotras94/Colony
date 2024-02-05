using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    private bool _isMoving = false;
    private Vector3 _targetPosition;
    [SerializeField] private float _speed = 0.5f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        if (_isMoving)
        {
            Move();
        }
 
    }
    private void SetTargetPosition()
    {
        _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _targetPosition.z = transform.position.z;
        _isMoving = true;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,_targetPosition,_speed * Time.deltaTime);
        if (transform.position == _targetPosition)
        {
            _isMoving = false;
        }
    }

}
