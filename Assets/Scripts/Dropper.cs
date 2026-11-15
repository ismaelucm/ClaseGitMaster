using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickItem player = collision.gameObject.GetComponentInChildren<PickItem>();
        if (player!=null)
        {
            player.OnDrop(gameObject.transform.position);
        }
    }
}
