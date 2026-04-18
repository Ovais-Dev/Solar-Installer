using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    public static ButtonManager buttManager;
    public Button panelButton, treeButton, cutTreeButton, cutPanelButton, energyButton, developButton;
    public int neededRescDev = 2;
    public int neededRescEng = 2;
    public int solarDevelop;

    Listing myList;
    // Start is called before the first frame update
    void Start()
    {
        buttManager = this;
        Invoke("DelayStarting", 0.05f);
    }
    void DelayStarting()
    {

        myList = Listing.myLists;
    }
    // Update is called once per frame
    void Update()
    {
        if (myList != null)
        {
            if (myList.curTree == myList.maxTrees && treeButton.IsInteractable())
            {
                TreeButtonEnable(false);
            }
            else if (myList.curTree < myList.maxTrees && !treeButton.IsInteractable())
            {
                TreeButtonEnable(true);
            }
            if (myList.curTree == 0 && cutTreeButton.IsInteractable())
            {
                CutTreeButtonEnable(false);
            }
            else if (myList.curTree > 0 && !cutTreeButton.IsInteractable())
            {
                CutTreeButtonEnable(true);
            }
            if (myList.curDevelop == myList.maxDevelop && developButton.IsInteractable())
            {
                DevelopmentButtonEnable(false);
            }
            else if (myList.curArtResource < neededRescDev && developButton.IsInteractable())
            {
                DevelopmentButtonEnable(false);
            }
            else if (myList.curArtResource >= neededRescDev && myList.curDevelop<myList.maxDevelop && !developButton.IsInteractable())
            {
                DevelopmentButtonEnable(true);
            }
           if (myList.curArtEner == myList.maxArtEnergy && energyButton.IsInteractable())
            {
                EnergyButtonEnable(false);
            }
            else if (myList.curArtResource < neededRescEng && energyButton.IsInteractable())
            {
                EnergyButtonEnable(false);
            }
            else if (myList.curArtResource >= neededRescEng && myList.curArtEner<myList.maxArtEnergy && !energyButton.IsInteractable())
            {
                EnergyButtonEnable(true);
            }
            if (myList.curDevelop <= 6)
                PanelButtonEnable(false);
            else if (myList.curPanel == myList.maxPanel && panelButton.IsInteractable())
                PanelButtonEnable(false);
            else if (myList.curPanel < myList.maxPanel && !panelButton.IsInteractable())
            {
                PanelButtonEnable(true);
            }
            if (myList.curPanel == 0 && cutPanelButton.IsInteractable())
                RemovePanelButtonEnable(false);
            else if (myList.curPanel > 0 && !cutPanelButton.IsInteractable())
            {
                RemovePanelButtonEnable(true);
            }
            
        }
    }
    void CutTreeButtonEnable(bool state)
    {
        cutTreeButton.interactable = state;
    }
    void RemovePanelButtonEnable(bool state)
    {
        cutPanelButton.interactable = state;
    }
    void PanelButtonEnable(bool state)
    {
        panelButton.interactable = state;
    }
    void TreeButtonEnable(bool state)
    {
        treeButton.interactable = state;
    }
    void EnergyButtonEnable(bool state)
    {
        energyButton.interactable = state;
    }
    void DevelopmentButtonEnable(bool state)
    {
       developButton.interactable = state;
    }
}
