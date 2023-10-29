using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = FindObjectOfType<Player>().GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerObj.transform.position;
    }
}
