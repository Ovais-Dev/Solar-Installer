using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject humans;
    public float distance;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        SpawnHumans();
    }
    void SpawnHumans()
    {
        dir = transform.position.normalized;
        GameObject human = Instantiate(humans);
        human.transform.position = dir * distance;
        human.transform.SetParent(transform.parent);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
