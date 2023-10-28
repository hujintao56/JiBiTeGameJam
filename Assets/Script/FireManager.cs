using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    public List<Fire> strongFireList;

    public void checkAllOut()
    {
        foreach (Fire fire in strongFireList)
        {
            /*
            if (fire.isBurning)
            {
                foreach (Fire f in strongFireList)
                {
                    f.isBurning = true;
                }
                return;
            }
            */
            Destroy(fire.gameObject);
            return;
        }
    }
}
