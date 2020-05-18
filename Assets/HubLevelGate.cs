using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HubLevelGate : MonoBehaviour
{
    public int level;
    public string prefixSceneLevel;
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
            MoveToScene(prefixSceneLevel,level);
        }
    }

    void MoveToScene(string prefix, int level)
    {
        SceneManager.LoadScene(prefix+level);
    }
}
