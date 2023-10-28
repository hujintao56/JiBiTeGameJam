using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    public float mouseRight ;
    // Update is called once per frame
    void Update()
    {
        mouseRight = Input.GetAxis("Fire2");
        if (mouseRight!=0)
        {

        }
    }
}
