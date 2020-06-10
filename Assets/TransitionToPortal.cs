/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionToPortal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject portal;
    public GameObject avatar;

    public GameObject focusObject;
    void Start()
    {
        StartCoroutine(Transition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Transition()
    {
        if (avatar.GetComponent<Player>())
        {
            avatar.GetComponent<Player>().canWalk = false;
        }
        yield return new WaitForSecondsRealtime(1);
        MoveToPortal(portal, focusObject);
        yield return new WaitForSecondsRealtime(3);
        this.GetComponent<Camera>().orthographicSize = 12;
        foreach(GameObject plate in portal.GetComponent<Portal>().plate)
        {
            MoveToPlate(plate, focusObject);
            yield return new WaitForSecondsRealtime(2);
        }


        portal.transform.Find("PortalUI").gameObject.SetActive(false);
        this.GetComponent<Camera>().orthographicSize = 6;
        MoveToAvatar(avatar, focusObject);

        if(avatar.GetComponent<Player>())
        {
            avatar.GetComponent<Player>().canWalk = true;
        }
    }

    public void MoveToPortal(GameObject plate, GameObject currentFocusObject)
    {
        Vector3 distance = this.transform.position - currentFocusObject.transform.position;
        focusObject = plate;
        //TODO smooth transition
        this.transform.position = plate.transform.position + distance;
        
    }

    public void MoveToPlate(GameObject portal, GameObject currentFocusObject)
    {
        Vector3 distance = this.transform.position - currentFocusObject.transform.position;
        focusObject = portal;
        //TODO smooth transition
        this.transform.position = portal.transform.position + distance;

    }

    public void MoveToAvatar(GameObject avatar, GameObject currentFocusObject)
    {
        Vector3 distance = this.transform.position - currentFocusObject.transform.position;
        focusObject = avatar;
        //TODO smooth transition
        this.transform.position = avatar.transform.position + distance;
    }
}
