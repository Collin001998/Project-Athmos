/*
Authored by Collin Bradley Nieuw Beerta
Copyright 2020
Scripted updated: 10/06/2020
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartLoadLevel(string scene)
    {
        StartCoroutine(LoadLevel(scene));
    }
    public IEnumerator LoadLevel(string scene)
    {
        Animator.SetTrigger("Fade_Start");
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(scene);
    }
}
