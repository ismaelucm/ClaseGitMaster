using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpac : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float jetpacForce = 10f;

    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.BroadcastMessage("OnFloor", true, SendMessageOptions.DontRequireReceiver);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.BroadcastMessage("OnFloor", false, SendMessageOptions.DontRequireReceiver);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movementVector = InputManager.Instance.MovementVector;
        if (movementVector.y > 0.2f)
        {
            if (_rigidbody.linearVelocity.y < maxSpeed)
            {
                _rigidbody.AddForce(Vector2.up * jetpacForce, ForceMode2D.Force);
            }
        }
    }

    private void Update()
    {
        if (InputManager.Instance.Shooting)
            Debug.Log($"{Time.frameCount}[{Time.deltaTime}]: Shoooting!");
    }
}
