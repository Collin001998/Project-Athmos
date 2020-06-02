using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateau : MonoBehaviour
{
    public bool activated = false;
    public GameObject portal;
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
        if (!activated)
        {
            portal.GetComponent<Portal>().progress.Add(this.gameObject);
            portal.GetComponent<Portal>().CheckProgress();
        }
    }
}
