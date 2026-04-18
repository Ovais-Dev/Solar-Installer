using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeUpgrade : MonoBehaviour
{
    public bool upgrade = false;
    public SpriteRenderer render;
    public Sprite newBike;
    public Light l1, l2;
    public Color c1, c2;
    public GameObject exhaust;

    int energyCon = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnergyDecrease", 10f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (upgrade)
        {
            energyCon = 0;
            render.sprite = newBike;
            l1.color = c1;
            l2.color = c2;
            exhaust.SetActive(false);
            upgrade = false;
        }
    }
    public void EnergyDecrease()
    {
        if (energyCon == 1 && Listing.myLists.curArtEner>0)
        {
            Listing.myLists.curArtEner -= 1;
            Controllers.SLIDER_Per_Controller.EnergyArtSlider(Listing.myLists.curArtEner);
        }
    }
}
