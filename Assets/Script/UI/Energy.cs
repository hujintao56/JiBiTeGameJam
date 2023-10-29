using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Energy : MonoBehaviour
{
    private Player player;
    private Slider slider;
    private float energy;
    void Start()
    {
        player = FindObjectOfType<Player>();
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        energy =  player.ButtonEnergy;
        slider.value = energy * 0.01f;
    }
}
