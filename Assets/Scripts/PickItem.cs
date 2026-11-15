using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItem : MonoBehaviour
{
    private Pickable _itemPicked = null;
    private bool _justPicked = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (_itemPicked==null)
        {
            Pickable anItem = other.GetComponent<Pickable>();
            if (anItem != null)
            {
                _itemPicked = anItem;
                _itemPicked.OnPick(gameObject);
                _justPicked = true;
            }   
        }
    }

    internal void OnDrop(Vector3 position)
    {
        if (_itemPicked!=null)
        {
            _itemPicked.OnDrop(position);
            _itemPicked = null;
        }
    }

    void Update()
    {
        if (InputManager.Instance.Shoot)
        {
            OnDrop(transform.position);
        }
    }
}
