using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controllers : MonoBehaviour
{
    public static Controllers SLIDER_Per_Controller;
    public Check greenerySl, energyArtSl, solarSl,pollutionSl,resourcesNatSl,resourcesArtSl, developmentSl;
    public Text greenTxt, energArtTxt, solarTxt,pollTxt,rescNatTxt,rescArtTxt,devTxt;
   
    // Start is called before the first frame update
    void Start()
    {
        SLIDER_Per_Controller = this;

       
        Invoke("DelayStart", 0.15f);
    }
    void DelayStart()
    {
        GreenSlider(0);
        SolarSlider(0);
        DevelopmentSlider(0);
        PollutionSlider(0);
       
        ResourcesNatSlider(Listing.myLists.curNatResource);
        ResourcesArtSlider(0);
       
        EnergyArtSlider(0);
    }
    // Update is called once per frame
    void Update()
    {
       /* if (Listing.myLists.curDevelop > 0)
        {
            pollutionSl.slide.maxValue = Listing.myLists.curPollut;
            pollutionSl.slide2.maxValue = Listing.myLists.curPollut;
        }*/
    }
    public void GreenSlider(int finalValue)
    {
        if (finalValue > greenerySl.maxValue)
            finalValue = (int)greenerySl.maxValue;
        greenerySl.finalValue = finalValue;
        float percentage = (greenerySl.finalValue / greenerySl.maxValue) * 100;
        greenTxt.text = ((int)percentage).ToString() + "%";
    }
    public void SolarSlider(int finalValue)
    {if (finalValue > solarSl.maxValue)
            finalValue = (int)solarSl.maxValue;
        solarSl.finalValue = finalValue;
        float percentage = (solarSl.finalValue / solarSl.maxValue) * 100;
        solarTxt.text = ((int)percentage).ToString() + "%";
    }
    public void DevelopmentSlider(int finalValue)
    {
        if (finalValue > developmentSl.maxValue)
            finalValue = (int)developmentSl.maxValue;
        developmentSl.finalValue = finalValue;
        float percentage = (developmentSl.finalValue / developmentSl.maxValue) * 100;
        devTxt.text = ((int)percentage).ToString() + "%";
    }
    public void PollutionSlider(float finalValue)
    {
        if (finalValue > pollutionSl.maxValue)
            finalValue = (int)pollutionSl.maxValue;
        pollutionSl.finalValue = finalValue;
        float percentage = (pollutionSl.finalValue / pollutionSl.maxValue) * 100;
        pollTxt.text = ((int)percentage).ToString() + "%";
    }
    public void ResourcesNatSlider(int finalValue)
    {
        if (finalValue > resourcesNatSl.maxValue)
            finalValue = (int)resourcesNatSl.maxValue;
        resourcesNatSl.finalValue = finalValue;
        float percentage = (resourcesNatSl.finalValue / resourcesNatSl.maxValue) * 100;
        rescNatTxt.text = ((int)percentage).ToString() + "%";
    }
    public void ResourcesArtSlider(int finalValue)
    {
        if (finalValue > resourcesArtSl.maxValue)
            finalValue = (int)resourcesArtSl.maxValue;
        resourcesArtSl.finalValue = finalValue;
        float percentage = (resourcesArtSl.finalValue / resourcesArtSl.maxValue) * 100;
        rescArtTxt.text = ((int)percentage).ToString() + "%";
    }
    public void EnergyArtSlider(int finalValue)
    {
        if (finalValue > energyArtSl.maxValue)
            finalValue = (int)energyArtSl.maxValue;
        energyArtSl.finalValue = finalValue;
        float percentage = (energyArtSl.finalValue / energyArtSl.maxValue) * 100;
        energArtTxt.text = ((int)percentage).ToString() + "%";
    }
   
}
