using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    Vector2 mousePos;
    bool oneTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        Invoke("Delaying", 0.1f);
    }
    void Delaying()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

    }
    private void OnDisable()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
           
        }
    }
    
}
