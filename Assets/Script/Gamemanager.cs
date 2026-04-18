using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Gamemanager : MonoBehaviour
{
    public static Gamemanager G_manager;

    //public Transform crossCur;
  /*  public bool cuttingTrees = false;
    public bool panelRemoving = false;
    Vector3 mousepos;*/
    //Ray2D ray;
   // RaycastHit2D rayHit;

   // public bool selected = false;
    //bool holdDown = false;
    bool oneTime = false;

    Listing myList;
    Controllers sliderCtrl;
    // Start is called before the first frame update
    void Start()
    {
        G_manager = this;
        //Cursor.visible = !holdDown;
        //crossCur.gameObject.SetActive(holdDown);
        Invoke("DelayCalling", 0.1f);
    }
    void DelayCalling()
    {
        sliderCtrl = Controllers.SLIDER_Per_Controller;
        myList = Listing.myLists;
    }
    void Update()
    {
       /* if (EventSystem.current.IsPointerOverGameObject())
        {
            Cursor.visible = true;
            crossCur.gameObject.SetActive(false);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            crossCur.gameObject.SetActive(false);
            cuttingTrees = false;
            panelRemoving = false;
            //oneTime = true;
        }*/
       /* if (cuttingTrees || panelRemoving)
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

          //  holdDown = true;
                Cursor.visible = false;
                crossCur.gameObject.SetActive(true);
                oneTime = true;
            

        }
        else if(!cuttingTrees || !panelRemoving && oneTime)
        {
         //   holdDown = false;
            crossCur.gameObject.SetActive(false);
            Cursor.visible = true;
            oneTime = false;
        }*/
        /*if (cuttingTrees)
        {
           
            //Ray2D ray = Physics2D.Raycast(mouspos, mouspos * 2f);
            
                rayHit = Physics2D.Raycast(mousepos, new Vector3(0, 0, 11f));
                if (Input.GetMouseButtonDown(0))
                {
                    if (rayHit.collider != null)
                    {
                        if (rayHit.collider.CompareTag("Tree"))
                        {
                            CutTree(rayHit.collider.gameObject);
                            myList.curTree -= 1;
                            myList.curArtResource += 1;
                        myList.curNatResource -= 1;
                            sliderCtrl.GreenSlider(myList.curTree);
                            sliderCtrl.ResourcesArtSlider(myList.curArtResource);
                        sliderCtrl.ResourcesNatSlider(myList.curNatResource);
                            Invoke("TreeRemoving", 0.01f);

                        }
                    }
                }
            
        }*/
        /*if (panelRemoving)
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Ray2D ray = Physics2D.Raycast(mouspos, mouspos * 2f);

            rayHit = Physics2D.Raycast(mousepos, new Vector3(0, 0, 11f));
            if (Input.GetMouseButtonDown(0))
            {
                if (rayHit.collider != null)
                {
                    if (rayHit.collider.CompareTag("Panel"))
                    {
                        myList.curPanel -= 1;
                        myList.curArtEner -= 5;
                        sliderCtrl.SolarSlider(myList.curPanel);
                        sliderCtrl.EnergyArtSlider(myList.curArtEner);
                        CutTree(rayHit.collider.gameObject);
                        Invoke("PanelRemoving", 0.01f);
                    }
                }
            }

        }*/
    }
   public void TreeRemoving()
    {
        int randomIndex = Random.Range(0, myList.trees.Count);
        CutTree(myList.trees[randomIndex]);
        int a = 0;
        foreach (GameObject obj in myList.trees)
        {
           
            if (obj == null)
            {
                a = myList.trees.IndexOf(obj);
                myList.treesAngle.RemoveAt(a);
               
            }
           
        }
       
        myList.curTree -= 1;
        myList.curArtResource += 1;
        myList.curNatResource -= 1;
        sliderCtrl.GreenSlider(myList.curTree);
        sliderCtrl.ResourcesArtSlider(myList.curArtResource);
        sliderCtrl.ResourcesNatSlider(myList.curNatResource);
        if (myList.curDevelop > 0)
        {
            sliderCtrl.PollutionSlider(myList.curPollut * ((float)(myList.maxTrees - myList.curTree) / myList.maxTrees));
        }
        else
        {
            sliderCtrl.PollutionSlider(myList.curPollut);
        }
        Invoke("DelayCutTree", 0.01f);
    }
    void DelayCutTree()
    {
        myList.trees.RemoveAll(GameObject => GameObject == null);

    }
    public void PanelRemoving()
    {
        int randomIndex = Random.Range(0, myList.panels.Count);
        CutTree(myList.panels[randomIndex]);
        int a = 0;
        foreach (GameObject obj in myList.panels)
        {
            if (obj == null)
            {
                a = myList.panels.IndexOf(obj);
                myList.panelAngle.RemoveAt(a);
                
            }
        }

        myList.curPanel -= 1;
        //myList.curArtEner -= 5;
        sliderCtrl.SolarSlider(myList.curPanel);
       // sliderCtrl.EnergyArtSlider(myList.curArtEner);

        Invoke("DelayRemovePanel", 0.01f);
    }
    void DelayRemovePanel()
    {
        myList.panels.RemoveAll(GameObject => GameObject == null);

    }
    void CutTree(GameObject obj)
    {
        if(obj.GetComponent<DestructionEffect>()!=null)
        obj.GetComponent<DestructionEffect>().EffectSpawn();
        Destroy(obj);
    }
}
