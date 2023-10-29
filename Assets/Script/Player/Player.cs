using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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
    private GameObject bornObj;
    public int _StrongSkillEnegy = 0;
    public int ReduceEnergy = 0;
    public int ButtonEnergy;
    public Element CurrentElement;
    private Transform weapenObj;
    private Move move;
    private FireManager firemng;
    public Camera mainCamera;
    public bool PlayerState = false;

    void Start()
    {
        weapenObj = transform.Find("weapon");
        CurrentElement = Element.shadow;
        move = GetComponentInChildren<Move>();
        firemng = FindObjectOfType<FireManager>();
        bornObj = GameObject.FindGameObjectWithTag("born");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
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
                if (ButtonEnergy < _StrongSkillEnegy)
                {
                    weapenObj.gameObject.SetActive(true);
                    Invoke("ShutdownWeapon", 1f);
                }
                else
                {
                    ButtonEnergy -= ReduceEnergy;
                    GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.LookRotation(transform.forward));

                    // 设置火球的初始速度和方向
                    Rigidbody2D fireballRigidbody = fireball.GetComponent<Rigidbody2D>();
                    fireballRigidbody.velocity = new Vector2(move.facingDirection, 0) * fireballSpeed;

                }
                break;
            case Element.water:
                if (ButtonEnergy < _StrongSkillEnegy)
                {
                    weapenObj.gameObject.SetActive(true);
                    Invoke("ShutdownWeapon", 1f);
                }
                else
                {
                    ButtonEnergy -= ReduceEnergy;
                    firemng.checkAllOut();
                }
                break;
            case Element.wind:
                if (ButtonEnergy < _StrongSkillEnegy)
                {
                    weapenObj.gameObject.SetActive(true);
                    Invoke("ShutdownWeapon", 1f);
                }
                else
                {
                    ButtonEnergy -= ReduceEnergy;
                    Rect cameraView = mainCamera.rect;

                    // 将视口范围转换为世界坐标范围
                    Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(cameraView.xMin, cameraView.yMin, 0));
                    Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(cameraView.xMax, cameraView.yMax, 0));

                    // 检索范围内的所有Collider2D对象
                    Collider2D[] colliders = Physics2D.OverlapAreaAll(bottomLeft, topRight);

                    // 遍历所有Collider2D对象
                    foreach (Collider2D collider in colliders)
                    {
                        if (collider.CompareTag("Box"))
                        {
                            Rigidbody2D rigBox = collider.GetComponent<Rigidbody2D>();
                            rigBox.velocity = new Vector2(move.facingDirection * 10, rigBox.velocity.y);
                        }
                        move.WindWashself();
                    }
                }
                break;
            case Element.shadow:
                PlayerState = true;
                Invoke("SWPlayerState", 5f);
                break;
            default:
                break;
        }
    }
    private void ShutdownWeapon()
    {
        weapenObj.gameObject.SetActive(false);
    }
    private void SWPlayerState()
    {
        PlayerState = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("CorpseFlower"))
        {
            transform.position = bornObj.transform.position;
        }
    }


}
