/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateau : MonoBehaviour
{
    public bool activated = false;
    public enum Type 
    { 
        Round, 
        Square, 
        Triangle
    };
    public enum State
    {
        Default,
        Accepted,
        Error
    };
    public Type type;
    public State state;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Default;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (activated)
        {
            this.GetComponent<Renderer>().materials[1].SetColor("_Color", new Color(0,255,0));
            //this.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", new Color(0, 255, 0));
        }*/
        switch (state)
        {
            case State.Default:
                this.GetComponent<Renderer>().materials[1].SetColor("_Color", new Color(255, 255, 255));
                break;
            case State.Accepted:
                this.GetComponent<Renderer>().materials[1].SetColor("_Color", new Color(0, 255, 0));
                break;
            case State.Error:
                this.GetComponent<Renderer>().materials[1].SetColor("_Color", new Color(255, 0, 0));
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            portal.GetComponent<Portal>().progress.Add(this.gameObject);
            if (!portal.GetComponent<Portal>().CheckProgress())
            {
                state = State.Error;
            }
            else
            {
                state = State.Accepted;
            }
        }
    }
}
