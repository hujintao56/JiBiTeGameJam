using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vine : MonoBehaviour
{
    // ���isBig = true���ǾͲ����������ø�����
    public bool isBig;

    public void Growth()
    {
        if (isBig)
            return;

        gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
    }
}
