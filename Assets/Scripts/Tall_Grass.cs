/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tall_Grass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (!player.isHidden)
            {
                player.HidePlayer();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player.isHidden)
            {
                player.UnHidePlayer();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (!player.isHidden)
            {
                player.HidePlayer();
            }
        }
    }
}
