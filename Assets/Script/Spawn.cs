using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Spawn : MonoBehaviour
{
    public static Spawn spawner;
    public Transform planet;
    public float distance = 17.2f;
    Vector2 direction;
    public GameObject[] spawnable;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        spawner = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
     /* if(Input.GetMouseButtonDown(0) && Gamemanager.G_manager.selected)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           
            direction = Vector2.zero - mousePos;
            Place(mousePos.normalized);
        }*/
    }
    void Place(Vector2 dirxn)
    {
        random = Random.Range(0, spawnable.Length);
        if (spawnable[random] != null)
        {
          
            GameObject obj = Instantiate(spawnable[random]);
            obj.transform.position = dirxn * distance;
            obj.transform.position += new Vector3(0, 0, 0.1f);
            float angle = Mathf.Atan2(dirxn.y, dirxn.x) * Mathf.Rad2Deg;
            obj.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
            obj.transform.SetParent(planet);
        }
    }
}
