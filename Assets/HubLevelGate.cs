using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubLevelGate : MonoBehaviour
{
    public int level;
    public string prefixSceneLevel;
    public GameObject eventSystem;
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
        eventSystem.GetComponent<LevelDetailUI>().ShowLevelDetails(level, 0,0);
    }
    private void OnTriggerExit(Collider other)
    {
        eventSystem.GetComponent<LevelDetailUI>().HideLevelDetails();
    }

    
}
