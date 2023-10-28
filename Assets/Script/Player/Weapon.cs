using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Player player;
    private Element playerElememt ;
    private Move move;
    private int direction;
    [SerializeField]
    private int moveDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        move = GetComponentInParent<Move>();
    }
    private void Update()
    {
        playerElememt = player.CurrentElement;
        direction = move.facingDirection;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(playerElememt);
        switch (playerElememt)
        {
            case Element.fire:
                if (collision.CompareTag("Vine")||collision.CompareTag("Box")||collision.CompareTag("CorpseFlower"))
                {
                    Debug.Log(collision);
                    Destroy(collision.gameObject);
                }
                break;
            case Element.water:
                if (collision.CompareTag("Fire"))
                {
                    Destroy(collision.gameObject);
                }
                if (collision.CompareTag("Vine"))
                {
                    Vine vine = collision.GetComponent<Vine>();
                    vine.Growth();
                }
                break;
            case Element.wind:
                if (collision.CompareTag("Box"))
                {
                    Rigidbody2D rigBox = collision.GetComponent<Rigidbody2D>();
                    rigBox.velocity = new Vector2(direction * moveDistance, rigBox.velocity.y);
                }
                break;
            case Element.shadow:
                break;
            default:
                break;
        }
        gameObject.SetActive(false);
    }
}
