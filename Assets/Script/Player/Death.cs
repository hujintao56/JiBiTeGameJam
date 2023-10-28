using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Absorb absorb;
    private void Start()
    {
        absorb = GetComponentInParent<Absorb>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && absorb.mouseRight != 0)
        {
            Destroy(collision.gameObject);
        }
    }
}
