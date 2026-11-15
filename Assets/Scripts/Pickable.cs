using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Pickable : MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    internal void OnPick(GameObject newParent)
    {
        this.transform.parent = newParent.transform;
        this.transform.localPosition = Vector2.zero;
        _rb.isKinematic = true;
        _rb.Sleep();
        
    }
    internal void OnDrop(Vector3 position)
    {
        _rb.isKinematic = false;
        _rb.WakeUp();
        this.transform.SetParent(null);
    }
}
