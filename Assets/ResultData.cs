using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultData : MonoBehaviour
{
    // Start is called before the first frame update
    public Text headerText;
    public Image star1;
    public Image star2;
    public Image star3;
    void Start()
    {
        int result = PlayerPrefs.GetInt("result_Level");
        if(result == 0)
        {
            headerText.text = "YOU CLEARED IT";
        }

        if(result == 1)
        {
            headerText.text = "YOU GOT CAUGHT";
            star1.color = Color.grey;
            star2.color = Color.grey;
            star3.color = Color.grey;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
