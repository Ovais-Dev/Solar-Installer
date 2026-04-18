using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listing : MonoBehaviour
{
    public static Listing myLists;

    public List<GameObject> trees;
    public List<float> treesAngle;

    public List<GameObject> panels;
    public List<float> panelAngle;

    public List<GameObject> buildings;
    public List<float> buildingAngle;

    public int maxTrees = 15, maxPanel = 8,maxDevelop = 11, maxPollution = 30,maxNatResources = 24,maxArtResources = 50
        ,maxArtEnergy = 50;
    public int curTree, curPanel, curDevelop, curPollut, curArtResource,curNatResource,  curArtEner;
    


    // Start is called before the first frame update
    void Start()
    {
        myLists = this;
        curArtEner = 0;
        curNatResource = 9;
        Invoke("DelayCalling", 0.05f);
    }
    void DelayCalling()
    {
        Controllers.SLIDER_Per_Controller.greenerySl.maxValue = maxTrees;
        Controllers.SLIDER_Per_Controller.solarSl.maxValue = maxPanel;
        Controllers.SLIDER_Per_Controller.developmentSl.maxValue = maxDevelop;
        Controllers.SLIDER_Per_Controller.pollutionSl.maxValue = maxPollution;
        Controllers.SLIDER_Per_Controller.resourcesArtSl.maxValue = maxArtResources;
        Controllers.SLIDER_Per_Controller.energyArtSl.maxValue = maxArtEnergy;
        Controllers.SLIDER_Per_Controller.resourcesNatSl.maxValue = maxNatResources;
 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
