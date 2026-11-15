using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private bool _movingLeft = true;
    private float _leftLimit;
    private float _rightLimit;
    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main)
        {
            _leftLimit = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
            _rightLimit = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        }
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementVector = InputManager.Instance.MovementVector;
        float axis = movementVector.x;
        if (axis < 0 && !_movingLeft)
        {
            _movingLeft = true;
            gameObject.BroadcastMessage("FacingLeft", _movingLeft);
        }
        if (axis>0 && _movingLeft)
        {
            _movingLeft = false;
            gameObject.BroadcastMessage("FacingLeft", _movingLeft, SendMessageOptions.DontRequireReceiver);
        }

        if (Mathf.Abs(axis) > 0.1f)
        {
            gameObject.BroadcastMessage("Walking", true, SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            gameObject.BroadcastMessage("Walking", false, SendMessageOptions.DontRequireReceiver);
        }

        Vector3 newPosition = transform.position;
        if (newPosition.x > _rightLimit)
        {
            newPosition.x = _leftLimit;
            _rigidbody.MovePosition(newPosition);
        }
        if (newPosition.x < _leftLimit)
        {
            newPosition.x = _rightLimit;
            _rigidbody.MovePosition(newPosition);
        }

        movementVector *= speed;
        movementVector.y  = _rigidbody.linearVelocity.y;
        _rigidbody.linearVelocity = movementVector;
    }
}
