using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsBehaviour : MonoBehaviour
{
    public static CloudsBehaviour cloudFormation;

    public GameObject[] clouds;
    public Transform cloudsManager;
    int randomNum;
    public float distance = 23f;

    
    //Vector2 dir;
    //public float angle;
    // Start is called before the first frame update
    void Start()
    {
        cloudFormation = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    angle = Random.Range(0, 360);
        //    Clouds();
        //}
    }
    public void Clouds(Vector2 dirxn)
    {
      
        randomNum = Random.Range(0, clouds.Length);
        //float radian;
        //radian = angle * Mathf.Deg2Rad;
        //dir = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        //dir.Normalize();
        float angle = Mathf.Atan2(dirxn.y, dirxn.x) * Mathf.Rad2Deg;
        GameObject cloud = Instantiate(clouds[randomNum]);
        cloud.transform.position = dirxn * distance;
        cloud.transform.rotation = Quaternion.Euler(0, 0, angle-90f);
        cloud.transform.SetParent(cloudsManager);
    }
}
