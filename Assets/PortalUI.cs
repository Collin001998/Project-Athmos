/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelBackground;
    public Sprite background1;
    public Sprite background2;
    public Sprite background3;

    public GameObject platesCanvas;
    public GameObject platesUI;

    public bool isVisable;
    void Start()
    {
        isVisable = true;
    }
    private void Awake()
    {
        if (this.GetComponentInParent<Portal>())
        {
            if(this.GetComponentInParent<Portal>().plate.Count == 1)
            {
                panelBackground.GetComponent<Image>().sprite = background1;
            }
            else if (this.GetComponentInParent<Portal>().plate.Count == 2)
            {
                panelBackground.GetComponent<Image>().sprite = background2;
            } 
            else if (this.GetComponentInParent<Portal>().plate.Count == 3)
            {
                panelBackground.GetComponent<Image>().sprite = background3;
            }

            foreach(GameObject pla in this.GetComponentInParent<Portal>().plate)
            {
                GameObject UIElement = Instantiate(platesUI, platesCanvas.transform,false) as GameObject;
                UIElement.GetComponent<platesProtalUIIcons>().type = (platesProtalUIIcons.Type)pla.GetComponent<plateau>().type;
                UIElement.transform.parent = platesCanvas.transform;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isVisable)
        {
            this.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            this.GetComponent<Canvas>().enabled = true;
        }
    }
}
