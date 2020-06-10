/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Postlevel : MonoBehaviour
{
    public bool showPostLevelUI = false;
    public GameObject postLevelUI;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showPostLevelUI)
        {
            postLevelUI.SetActive(true);
            
        }
        else
        {
            postLevelUI.SetActive(false);
        }
    }

    
}
