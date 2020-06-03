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
    public Type type;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            this.GetComponent<Renderer>().materials[1].SetColor("_Color", new Color(0,255,0));
            //this.GetComponent<Renderer>().materials[1].SetColor("_EmissionColor", new Color(0, 255, 0));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            portal.GetComponent<Portal>().progress.Add(this.gameObject);
            portal.GetComponent<Portal>().CheckProgress();
        }
    }
}
