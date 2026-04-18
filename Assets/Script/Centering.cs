using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centering : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed = 5f;
    float tempSpeed;
    public float addForce = 30f;
    float tempForce;
    public LayerMask whatIsLayer;
    public Transform groundPos;
    public float radius = 0.2f;
   
    float initialScaleX;

    float curAngle;
    public Vector2 angleRange;
    public GameObject[] lights;
    bool lightOpen = false, lightClose= false;

    int onRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tempForce = addForce;
        initialScaleX = transform.localScale.x;
        onRotation = Random.Range(0, 2);
        switch (onRotation)
        {
            case 0:
                onRotation = 1;
                transform.localScale = new Vector3(initialScaleX, transform.localScale.y, 1);
                break;
            case 1:
                onRotation = -1;
                transform.localScale = new Vector3(-initialScaleX, transform.localScale.y, 1);
                break;
        }
        
        InvokeRepeating("BikeLight", 2f, 1f);
    }
    // Update is called once per frame
    private void Update()
    {
       
        float horizontal = Input.GetAxis("Horizontal");
        if (Listing.myLists.curArtEner > 0)
            tempSpeed = speed;
        else
            tempSpeed = 0;
        transform.RotateAround(Vector2.zero, new Vector3(0, 0, onRotation), -tempSpeed * Time.deltaTime);
       
           
    }
    void BikeLight()
    {
        curAngle = ReturnAngle();
        if (curAngle > angleRange.x && curAngle < angleRange.y)
        {
            if (!lightClose)
            {
                lightClose = true;
                lightOpen = false;
                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].SetActive(false);
                }
            }
        }
        else
        {
          
            if (!lightOpen)
            {
                lightOpen = true;
                lightClose = false;
                for (int i = 0; i < lights.Length; i++)
                {
                    lights[i].SetActive(true);
                }
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
    
    void FixedUpdate()
    {
        Collider2D col = Physics2D.OverlapCircle(groundPos.position, radius, whatIsLayer);
        direction = Vector2.zero - (Vector2)transform.position;
        if (col == null)
        {
            rb.AddForce(direction * addForce, ForceMode2D.Force);
        }
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundPos.position, radius);
    }
}
