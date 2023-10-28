using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectWithTag("born");
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.gameObject.GetComponent<Player>().PlayerState)
        {
            collision.transform.position = obj.transform.position;
        }
    }
}
