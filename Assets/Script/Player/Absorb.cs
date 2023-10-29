using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Absorb : MonoBehaviour
{
    [HideInInspector]
    public float mouseRight ;
    private Transform target;
    public float moveSpeed = 1;

    void Update()
    {
        mouseRight = Input.GetAxis("Fire1");
        if (target != null)
        {
            Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

            // 使用Vector2.Lerp进行平滑移动
            // Vector2 newPosition = Vector2.Lerp(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
            // transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

            // 使用Vector2.MoveTowards进行直线移动
            Vector2 newPosition = Vector2.MoveTowards(targetPosition, currentPosition ,moveSpeed * Time.deltaTime);
            target.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (mouseRight != 0 && collision.CompareTag("Enemy"))
        {
            target = collision.transform;
        }
        else
        {
            target = null;
        }
    }

    
}
