using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    // 如果isBig = true，那就不能再生长得更大了
    public bool isBig;
    public Sprite sprite;
    private SpriteRenderer render;

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    public void Growth()
    {
        if (isBig)
            return;
        render.sprite = sprite;
        gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 3, 1);
    }
}
