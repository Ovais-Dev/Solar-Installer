using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{

    public int noOfObj = 4;
    public GameObject[] spawnable;
    public float distance;

    public Transform planet;

    [Header("Initially Spawner")]
    public bool initiallySpawn = false;
    public string funcName = "SpawnTree";
    public int repeatTime = 3;

    int randomValue = 0;
    float planetAngle;
    [Space(3)]
    [Header("Extras")]
    public GameObject bike;
    public List<GameObject> bikeList;

    Controllers sliderCtrl;
    Listing myList;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayCalling", 0.1f);
        if (initiallySpawn)
        {
            for (int i = 0; i < repeatTime; i++)
            {
                Invoke(funcName,0.2f);
            }
        }
    }
    void DelayCalling()
    {
        sliderCtrl = Controllers.SLIDER_Per_Controller;
        myList = Listing.myLists;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Energy()
    {
        myList.curArtResource -= 1;
        myList.curArtEner += 1;
        sliderCtrl.ResourcesArtSlider(myList.curArtResource);
        sliderCtrl.EnergyArtSlider(myList.curArtEner);
    }
    public void SpawnTree()
    {
        for (int i = 0; i < noOfObj; i++)
        {
            if ((myList.maxTrees - myList.curTree) > 0)
            {
                Spawn(myList.trees, myList.treesAngle, Random.Range(0, 360), 5f);
                myList.curNatResource+=1;
                sliderCtrl.ResourcesNatSlider(myList.curNatResource);
                myList.curTree += 1;
                sliderCtrl.GreenSlider(myList.curTree);
            }
        }
        if (myList.curDevelop > 0)
        {
            sliderCtrl.PollutionSlider(myList.curPollut * ((float)(myList.maxTrees - myList.curTree) / myList.maxTrees));
        }
        else
        {
            sliderCtrl.PollutionSlider(myList.curPollut);
        }
    }
    public void SpawnPanel()
    {
        for (int i = 0; i < noOfObj; i++)
        {
            if ((myList.maxPanel - myList.curPanel) > 0)
            {
                Spawn(Listing.myLists.panels, Listing.myLists.panelAngle, Random.Range(0, 360), 10f);
                myList.curPanel += 1;

                sliderCtrl.SolarSlider(myList.curPanel);
               
                myList.curArtResource -= 1;
                sliderCtrl.ResourcesArtSlider(myList.curArtResource);
            }
        }
        myList.curNatResource -= 1;
        sliderCtrl.ResourcesNatSlider(myList.curNatResource);
    }
    public void SpawnBuilding()
    {
       int k = 0;
        float newAngle = 0;
        int count = myList.buildings.Count;
       // Debug.Log(count - 1);
        for (int i = 0; i < noOfObj; i++)
        {
            if (myList.curDevelop < 6)
            {
                
                Spawn(Listing.myLists.buildings, Listing.myLists.buildingAngle, Random.Range(0, 360), 60f,1);
                if (myList.curDevelop == 5)
                    ButtonManager.buttManager.neededRescDev = 4;
                myList.curArtResource -= 2;
                myList.curPollut += 5;
            }
            else if(myList.curDevelop>=6 && myList.curDevelop < 9)
            {
                //noOfObj = 2;
                myList.curArtResource -= 4;
                myList.curPollut -= 2;
                myList.curNatResource -= 1;
                while (count>0)
                {
                    count--;
                    
                    if (myList.buildings[count].tag != "House3")
                    {
                      
                        continue;
                    }
                    if (k < 2)
                    {
                        // int index = myList.buildings[count];
                        k++;
                       // Debug.Log(count);
                        Vector3 dir = myList.buildings[count].transform.position.normalized;
                        newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        Destroy(myList.buildings[count].gameObject);

                        myList.buildings.RemoveAt(count);
                        myList.buildingAngle.RemoveAt(count);

                        
                        Spawn(Listing.myLists.buildings, Listing.myLists.buildingAngle, newAngle, 0f, 2);
                        if (myList.curDevelop == 9)
                            ButtonManager.buttManager.neededRescDev = 10;
                        SpawnBike();
                    }
                    
                }
                if (myList.curDevelop == 8)
                    ButtonManager.buttManager.neededRescDev = 10;
            }
            else
            {
                myList.curArtResource -= 10;
                myList.curPollut -= 6;
                 myList.curNatResource -= 1;
                while (count > 0)
                {
                    count--;

                    if (myList.buildings[count].tag != "House2")
                    {

                        continue;
                    }
                    if (k < 3)
                    {
                        // int index = myList.buildings[count];
                        k++;
                      //  Debug.Log(count);
                        Vector3 dir = myList.buildings[count].transform.position.normalized;
                        newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        Destroy(myList.buildings[count].gameObject);

                        myList.buildings.RemoveAt(count);
                        myList.buildingAngle.RemoveAt(count);


                        Spawn(Listing.myLists.buildings, Listing.myLists.buildingAngle, newAngle, 0f, 3);


                    }

                }
                if (myList.curDevelop == 10)
                {
                    foreach (GameObject bike in bikeList)
                    {
                        bike.GetComponent<BikeUpgrade>().upgrade = true;
                        myList.curPollut -= 2;
                    }
                }
                    
            }
           
        }
        myList.curDevelop += 1;
        sliderCtrl.ResourcesNatSlider(myList.curNatResource);
        sliderCtrl.DevelopmentSlider(myList.curDevelop);
        if (myList.curDevelop > 0)
        {
            sliderCtrl.PollutionSlider(myList.curPollut * ((float)(myList.maxTrees-myList.curTree)/myList.maxTrees));
        }
        else
        {
            sliderCtrl.PollutionSlider(myList.curPollut);
        }
        sliderCtrl.ResourcesArtSlider(myList.curArtResource);
    }
    void SpawnBike()
    {
        GameObject obj = Instantiate(bike);
        float randomAngle = Random.Range(0, 360f);
        float radian = randomAngle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
        obj.transform.rotation = Quaternion.Euler(0, 0, randomAngle - 90f);
        obj.transform.position = dir * (distance+5f);
        obj.transform.SetParent(planet);
        obj.transform.position += new Vector3(0, 0, 0.1f);
        bikeList.Add(obj);
    }
    void Spawn(List<GameObject> objects, List<float>angleInList, float randomAngle,float incAngle,int precise = 0)
    {
        /*Gamemanager.G_manager.cuttingTrees = false;
        Gamemanager.G_manager.panelRemoving = false;*/

        planetAngle = planet.transform.rotation.z;
        if (precise == 0)
        {
            randomValue = Random.Range(0, spawnable.Length);
        }
        else
        {
            randomValue = precise-1;
        }
       // Listing newList = Listing.myLists;
        GameObject obj = Instantiate(spawnable[randomValue]);
        
        randomAngle += planetAngle;

        if (angleInList.Count != 0)
        {
            float nearestAngle = NearestAngle(angleInList, randomAngle);
            while (randomAngle >= nearestAngle - incAngle&& randomAngle <= nearestAngle + incAngle)
            {
                Debug.Log("Times");
                randomAngle += incAngle;
                nearestAngle = NearestAngle(angleInList, randomAngle);
            }
        }
        objects.Add(obj);
        angleInList.Add(randomAngle);
        float radian = randomAngle * Mathf.Deg2Rad;
        Vector2 dir = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)).normalized;
        obj.transform.rotation = Quaternion.Euler(0, 0, randomAngle - 90f);
        obj.transform.position = dir * distance;
        obj.transform.SetParent(planet);
        obj.transform.position += new Vector3(0, 0, 0.1f);
    }
    float NearestAngle(List<float> angles, float angle)
    {
        float value = Mathf.Infinity;
        foreach (float ang in angles)
        {
            if (Mathf.Abs(angle-ang) < value)
            {
                value = ang;
            }
        }

        return value;
    }
}
