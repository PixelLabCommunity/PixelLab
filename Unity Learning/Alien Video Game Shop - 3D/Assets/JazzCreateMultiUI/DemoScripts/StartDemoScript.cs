using UnityEngine;
using System.Collections;
using UnityEngine.UI; // needed for scripting to Unity UI elements


public class StartDemoScript : MonoBehaviour
{
    //Menu canvas and panels declared below 
    public GameObject MenuCanvas;
    public GameObject UI_DisplayOne;
    public GameObject UI_DisplayTwo;
    public GameObject UI_DisplayThree;


    //Game panels and object declared below
    public GameObject Player;
    public GameObject HudCanvas;
    public GameObject EnemySpawner;

    void Start()
    {
        //At start make sure game objects are set to be non-active
        HudCanvas.SetActive(false);
        Player.SetActive(false);
        EnemySpawner.SetActive(false);

        //At start make sure menu objects are set to active , except previous and next display panel
        MenuCanvas.SetActive(true);
        UI_DisplayOne.SetActive(true);
        UI_DisplayTwo.SetActive(false);
        UI_DisplayThree.SetActive(false);

    }

    //for the PLAY button, to activate the game objects and deactivate menu panels
public void StartDemoBtn()
    {
        HudCanvas.SetActive(true);
        Player.SetActive(true);
        EnemySpawner.SetActive(true);
        MenuCanvas.SetActive(false);
    }


    //We have to return after each - if statement, else can't ever get to UI_Display two because other conditions become met on the first if statement. 
    //for the NEXT button, to go to next UI diplay panel.
    public void NextUI_Panel()
    {
        if(UI_DisplayOne.activeInHierarchy == true && UI_DisplayTwo.activeInHierarchy == false && UI_DisplayThree.activeInHierarchy == false)
        {
            UI_DisplayOne.SetActive(false);
            UI_DisplayTwo.SetActive(true);
            UI_DisplayThree.SetActive(false);
            return;
        }
        if(UI_DisplayOne.activeInHierarchy == false && UI_DisplayTwo.activeInHierarchy == true && UI_DisplayThree.activeInHierarchy == false)
            {
                UI_DisplayOne.SetActive(false);
                UI_DisplayTwo.SetActive(false);
                UI_DisplayThree.SetActive(true);
            return;
            }
        if(UI_DisplayOne.activeInHierarchy == false && UI_DisplayTwo.activeInHierarchy == false && UI_DisplayThree.activeInHierarchy == true)
        {
            Debug.Log("try using previous button instead");
        }
        }

    //for the PREV button to go to previous UI display panel
public void PrevUI_Panel()
    {
        if (UI_DisplayOne.activeInHierarchy == false && UI_DisplayTwo.activeInHierarchy == false && UI_DisplayThree.activeInHierarchy == true)
        {
            UI_DisplayOne.SetActive(false);
            UI_DisplayThree.SetActive(false);
            UI_DisplayTwo.SetActive(true);
            return;
        }
        if(UI_DisplayOne.activeInHierarchy == false && UI_DisplayThree.activeInHierarchy == false)
        {
            UI_DisplayTwo.SetActive(false);
            UI_DisplayThree.SetActive(false);
            UI_DisplayOne.SetActive(true);
            return;
        }
        if(UI_DisplayOne.activeInHierarchy == true && UI_DisplayTwo.activeInHierarchy == false && UI_DisplayThree.activeInHierarchy == false)
        {
            Debug.Log("try using the next button instead");
        }
    }
}
