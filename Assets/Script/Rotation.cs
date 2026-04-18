using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform rotatObj;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //  transform.rotation = Quaternion.Euler(0f, 0f, 1);
       
       rotatObj.Rotate(new Vector3(0f, 0f, 1f) * speed * Time.deltaTime,Space.World);
    }
}
