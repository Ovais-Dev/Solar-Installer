using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeORb : MonoBehaviour
{
    //public Vector2 dirxn;
    Vector2 initialDirxn;
    public float speed;
    public float destructionTime = 5.1f;

   // public GameObject clouds;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("OrbFade", destructionTime);
        initialDirxn = transform.position.normalized;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(initialDirxn * speed * Time.deltaTime, Space.World);
    }
    void OrbFade()
    {
        Vector2 dirxn = transform.position.normalized;
        CloudsBehaviour.cloudFormation.Clouds(dirxn);
       
        Destroy(gameObject);
    }
}
