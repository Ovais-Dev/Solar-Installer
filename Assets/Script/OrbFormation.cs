using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbFormation : MonoBehaviour
{
    [Header("Orb")]
    public GameObject orb;
    public float moveSpeed;
    public Transform spawnPos;

    [Header("OrbTimes")]
    public Vector2 cloudFormationTime = new Vector2(10,20);
    public Vector2 waitTime = new Vector2(35, 45);
    

    float timer;
    Vector2 dirxn;
    // Start is called before the first frame update
    void Start()
    {
        timer = RandomTime(cloudFormationTime.x, cloudFormationTime.y);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }
    float RandomTime(float minRange,float maxRange)
    {
        return Random.Range(minRange, maxRange);
    }
    void Spawn()
    {
        //dirxn = transform.position.normalized;
        if (timer < 0)
        {
            timer = RandomTime(waitTime.x, waitTime.y);
            GameObject greenOrb = Instantiate(orb, spawnPos.position, Quaternion.identity);
            greenOrb.GetComponent<LifeORb>().speed = moveSpeed;
            
        }
        else
        {
            timer -= Time.deltaTime;
        }
        
    }
}
