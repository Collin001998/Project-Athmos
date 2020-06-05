using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDetailUI : MonoBehaviour
{
    public GameObject levelDetailCanvas;
    public Text levelText;
    public Text levelPoints;

    public Image star1;
    public Image star2;
    public Image star3;

    public Button playButton;
    public Button backButton;
    public Button forwardButton;
    // Start is called before the first frame update
    void Start()
    {
        levelDetailCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowLevelDetails(int level, int points, int stars)
    {
        levelText.text = "Level " + level;
        levelPoints.text = points.ToString();
        levelDetailCanvas.SetActive(true);
        playButton.interactable = true;
        playButton.onClick.AddListener(delegate { MoveScene(level); });

        if(stars == 0)
        {
            star1.color = new Color(89, 89, 89); //E2E2E2
            star2.color = new Color(89, 89, 890); //E2E2E2
            star3.color = new Color(89, 89, 89); //E2E2E2
        } else if(stars == 1)
        {
            star1.color = new Color(255, 208, 150); //FFD096
            star2.color = new Color(89, 89, 89); //E2E2E2
            star3.color = new Color(89, 89, 89); //E2E2E2
        } else if(stars == 2)
        {
            star1.color = new Color(255, 208, 150); //FFD096
            star2.color = new Color(255, 208, 150); //FFD096
            star3.color = new Color(89, 89, 89); //E2E2E2
        } else
        {
            star1.color = new Color(255, 208, 150); //FFD096
            star2.color = new Color(255, 208, 150); //FFD096
            star3.color = new Color(255, 208, 150); //FFD096
        }
        

    }
    void MoveScene(int level)
    {
        SceneManager.LoadScene("level_" + level);
    }
    public void HideLevelDetails()
    {
        levelDetailCanvas.SetActive(false);
        playButton.interactable = false;
    }
}
