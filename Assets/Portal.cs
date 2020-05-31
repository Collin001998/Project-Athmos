using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public bool randomOrder;
    public List<GameObject> plate;
    private List<GameObject> progress;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetProgress()
    {
        progress.Clear();
    }

    public void AddProgress(GameObject plate)
    {
        progress.Add(plate);
    }
    public void CheckProgress(GameObject plate)
    {

    }
}
