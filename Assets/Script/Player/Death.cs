using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Absorb absorb;
    private Player player;
    private void Start()
    {
        absorb = GetComponentInParent<Absorb>();
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && absorb.mouseRight != 0)
        {
            Destroy(collision.gameObject);
            if (collision.gameObject.GetComponent<Enemy>().element != Element.nothing)
            {
                player.CurrentElement = collision.gameObject.GetComponent<Enemy>().element;
            }
            player.ButtonEnergy += 10; 
        }
    }
}
