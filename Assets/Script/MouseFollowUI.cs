using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MouseFollowUI : MonoBehaviour
{
    //GameObject obj;
    public Vector3 location;
    public Text denoteTxt;
    // Start is called before the first frame update
    void Start()
    {
       // obj = this.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //mouseFollow = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = location; //+ new Vector3(0, 0, 10f) ;
    }
    public void TextMenuplation(string str)
    {
        denoteTxt.text = str;
    }
}
