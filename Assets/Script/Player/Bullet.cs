using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("death", 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vine") || collision.CompareTag("Box") || collision.CompareTag("CorpseFlower") || collision.CompareTag("Rock"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void death()
    {
        Destroy(gameObject);
    }
}
