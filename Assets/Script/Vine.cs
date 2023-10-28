using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    // 如果isBig = true，那就不能再生长得更大了
    public bool isBig;

    public void Growth()
    {
        if (isBig)
            return;

        gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
    }
}
