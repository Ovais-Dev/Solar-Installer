using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    float curAngle;
    public Vector2 angleRange;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Energy", 0.5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Energy()
    {
        curAngle = ReturnAngle();
        if (curAngle > angleRange.x && curAngle < angleRange.y)
        {
            if (Listing.myLists.curArtEner < Listing.myLists.maxArtEnergy)
            {
                Listing.myLists.curArtEner += 1;
                Controllers.SLIDER_Per_Controller.EnergyArtSlider(Listing.myLists.curArtEner);
            }
        }
    }
    float ReturnAngle()
    {
        Vector2 pos = transform.position;
        pos.Normalize();
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        return angle;
    }
}
