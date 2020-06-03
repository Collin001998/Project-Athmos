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

    
    void Start()
    {
        
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
                panelBackground.GetComponent<Image>().sprite = background2;
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
        
    }
}
