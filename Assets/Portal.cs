/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public bool randomOrder;
    public int currentLevel;
    public int scoredPoints;
    public List<GameObject> plate;
    public List<GameObject> progress;
    private bool[] completed;
    void Start()
    {
        completed = new bool[plate.Count];
        for(int i = 0; i <= plate.Count - 1; i++)
        {
            completed[i] = false;
        }
        Debug.Log(completed.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CheckCompleted())
        {
            Debug.Log("level competed");
            Player player = other.gameObject.GetComponent<Player>();
            player.FinishedLevel();
        }
        if (!CheckCompleted())
        {
            Debug.Log("level not completed");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckProgress()
    {
        if(plate[progress.Count -1] == progress[progress.Count -1])
        {
            Debug.Log("correct plate.");
            completed[progress.Count -1] = true;
            plate[progress.Count - 1].GetComponent<plateau>().activated = true;
            //plate[progress.Count - 1].GetComponent<plateau>().state = plateau.State.Accepted;
            return true;
        }
        else
        {
            Debug.Log("incorrect plate.");

            
            StartCoroutine(ResetPlates(plate));
            return false;
            /*
            foreach(GameObject gameObject in plate)
            {
                //gameObject.GetComponent<plateau>().state = plateau.State.Error;
                //gameObject.GetComponent<plateau>().activated = false;
            }*/
        }
    }
    public bool CheckCompleted()
    {
        bool canEnterPortal = true;

        for (int i = 0; i < completed.Length; i++)
        {
            if(completed[i] == false)
            {
                canEnterPortal = false;
            }
        }

        return canEnterPortal;
    }

    IEnumerator ResetPlates(List<GameObject> plate)
    {
        progress.Clear();
        yield return new WaitForSecondsRealtime(2);
        foreach (GameObject gameObject in plate)
        {
            gameObject.GetComponent<plateau>().state = plateau.State.Default;
            gameObject.GetComponent<plateau>().activated = false;
        }
    }
}
