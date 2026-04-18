using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecting : MonoBehaviour
{
    public GameObject denoter;
    public string keyNam;
    public Vector2 denoterVector;


   public void Show()
    {
       
        denoter.GetComponent<MouseFollowUI>().location = denoterVector;
        denoter.GetComponent<MouseFollowUI>().TextMenuplation(keyNam);
        Invoke("Activating", 0.1f);
       
    }
    void Activating()
    {
        if (!denoter.activeInHierarchy)
        {
            denoter.SetActive(true);
        }
    }
   public void Hide()
    {
        if (denoter.activeInHierarchy)
        {
            denoter.SetActive(false);
        }
    }
}
