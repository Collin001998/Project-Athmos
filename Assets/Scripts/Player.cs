using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hidden;
    private bool isCaught;

    public bool isHidden => hidden;
    void Start()
    {
        hidden = false;
        isCaught = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isCaught)
        {
            PlayGotCaught();
        }
    }

    private void PlayGotCaught()
    {
        //player loses the level
    }

    public void HidePlayer()
    {
        Debug.Log("Player got hidden.");

        //play sound

        //change shader

        //hide
        this.hidden = true;
    }
    public void UnHidePlayer()
    {
        Debug.Log("Player got unhidden.");

        //play sound

        //change shader

        //unhide
        this.hidden = false;
    }

    public void FinishedLevel()
    {
        Debug.Log("level finished without being seen.");
    }

    public void FailedLevel()
    {
        Debug.Log("level failed");
    }


}
