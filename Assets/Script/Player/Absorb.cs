using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Absorb : MonoBehaviour
{
    [HideInInspector]
    public float mouseRight ;
    private Player player;
    private Transform target;
    public float moveSpeed = 1;
    private bool OnTri;
    private SpriteRenderer render;
    public Sprite _NothingState;
    public Sprite _FireState;
    public Sprite _WaterState;
    public Sprite _WindState;
    public Sprite _ShadowState;

    private void Start()
    {
        player = GetComponentInParent<Player>();
        render = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        mouseRight = Input.GetAxis("Fire1");
        if (target != null && OnTri)
        {
            Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

            // 使用Vector2.Lerp进行平滑移动
            // Vector2 newPosition = Vector2.Lerp(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
            // transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

            // 使用Vector2.MoveTowards进行直线移动
            Vector2 newPosition = Vector2.MoveTowards(targetPosition, currentPosition, moveSpeed * Time.deltaTime);
            target.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
        OnTri = false;
        SWPlayerSpirit(player.CurrentElement);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (mouseRight != 0 && collision.CompareTag("Enemy"))
        {
            target = collision.transform;
            OnTri = true;
        }
    }

    private void SWPlayerSpirit(Element element)
    {
        switch (element)
        {
            case Element.nothing:
                render.sprite = _NothingState;
                break;
            case Element.fire:
                render.sprite = _FireState;
                break;
            case Element.water:
                render.sprite = _WaterState;
                break;
            case Element.wind:
                render.sprite = _WindState;
                break;
            case Element.shadow:
                render.sprite = _ShadowState;
                break;
            default:
                break;
        }
    }

}
