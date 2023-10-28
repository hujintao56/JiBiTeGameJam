using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public enum Element
{
    nothing = 0,
    fire = 1,
    water = 2,
    wind = 3,
    shadow = 4,
}

public class Player : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 10f;
    // 小技能的参数
    public float smallSkillRange = 5f;
    public LayerMask grassObstacleLayer;

    // 技能强化的参数
    public float enhancedSkillRange = 10f;
    public LayerMask hardObstacleLayer;


    public int _StrongSkillEnegy = 0;
    [HideInInspector]
    public int ButtonEnegy { get; set; }
    //[HideInInspector]
    public Element CurrentElement { get; set; }
    void Start()
    {
        CurrentElement = Element.fire;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack(CurrentElement);
        }
    }

    private void Attack(Element element)
    {
        switch (element)
        {
            case Element.nothing:
                break;
            case Element.fire:
                if (ButtonEnegy < _StrongSkillEnegy)
                {
                    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, smallSkillRange, grassObstacleLayer);
                    foreach (Collider2D col in hitColliders)
                    {
                        Invoke("DelayDestroy", 3f);
                    }
                }
                else
                {
                    GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);

                    // 设置火球的初始速度和方向
                    Rigidbody2D fireballRigidbody = fireball.GetComponent<Rigidbody2D>();
                    fireballRigidbody.velocity = transform.right * fireballSpeed;

                }
                break;
            case Element.water:
                break;
            case Element.wind:
                break;
            case Element.shadow:
                break;
            default:
                break;
        }
    }
    private void DelayDestroy(GameObject obj)
    {
        Destroy(obj);
    }

}
