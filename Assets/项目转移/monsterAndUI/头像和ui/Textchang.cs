using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Textchang : MonoBehaviour
{
    public Text text;
    public Image image;
    public string []text2;
    public Sprite  []tupian;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chang()
    {   
        if(text2[index]=="A")
        {
            index += 1;
            image.sprite = tupian[0];
        }
        if (text2[index] == "B")
        {
            index += 1;
            image.sprite = tupian[1];
        }
        if (text2[index] == "D")
        {
            index += 1;
            image.sprite = tupian[2];
        }
        if (text2[index] == "C")
        {
           
            transform.parent.parent.gameObject.SetActive(false);
        }
        else
        {
  transform.parent.parent.gameObject.SetActive(true);
        }
        text.text = text2[index];
        index += 1;
   
    }
}
