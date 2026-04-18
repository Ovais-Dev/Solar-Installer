using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSizeInc : MonoBehaviour
{
    Vector3 initialSize;
    public Vector3 smallSize;
    public float lerpTime;
    // Start is called before the first frame update
    void Start()
    {
        initialSize = transform.localScale;
        transform.localScale = smallSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale!=initialSize)
        transform.localScale = Vector3.Lerp(transform.localScale, initialSize, lerpTime);

    }
   
}
