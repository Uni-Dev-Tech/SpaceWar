using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu, startButton, levelChoice, game, panelWin, panelLose;
    public Button buttonLevel1, buttonLevel2, buttonLevel3;
    public GameObject[] hearts;
    public Text asteroidTextScore;
    public byte index = 0;
    public byte chosenLevel;
    static public UIManager instance;
    public void Awake()
    {
        if(UIManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        UIManager.instance = this;
    }
    public void Start()
    {
        Time.timeScale = 0f; 
        mainMenu.SetActive(true); startButton.SetActive(true); levelChoice.SetActive(false);
        game.SetActive(false); panelWin.SetActive(false); panelLose.SetActive(false);
        switch (PlayManager.instance.levelConditions)
        {
            case 0:
                buttonLevel1.gameObject.SetActive(true);
                buttonLevel2.gameObject.SetActive(false);
                buttonLevel3.gameObject.SetActive(false);
                break;
            case 1:
                buttonLevel1.image.color = Color.green;
                buttonLevel2.gameObject.SetActive(true);
                buttonLevel3.gameObject.SetActive(false);
                break;
            case 2:
                buttonLevel1.image.color = Color.green;
                buttonLevel2.image.color = Color.green;
                buttonLevel3.gameObject.SetActive(true);
                break;
            case 3:
                buttonLevel1.image.color = Color.green;
                buttonLevel2.image.color = Color.green;
                buttonLevel3.image.color = Color.green;
                break;
        }
    }
    public void Update()
    {
        asteroidTextScore.text = PlayManager.instance.asteroidScore.ToString();
    }
    public void StartButton()
    {
        Switch(startButton, levelChoice);
    }

    public void Back()
    {
        Switch(levelChoice, startButton);
    }

    public void OnLevel1()
    {
        Switch(mainMenu, game);
        Time.timeScale = 1f;
        WorldController.timeRange = 1f;
        chosenLevel = 1;
        PlayManager.instance.asteroidAim = 20;
    }

    public void OnLevel2()
    {
        Switch(mainMenu, game);
        Time.timeScale = 1f;
        WorldController.timeRange = 0.8f;
        chosenLevel = 2;
        PlayManager.instance.asteroidAim = 40;
    }
    public void OnLevel3()
    {
        Switch(mainMenu, game);
        Time.timeScale = 1f;
        WorldController.timeRange = 0.6f;
        chosenLevel = 3;
        PlayManager.instance.asteroidAim = 60;
    }

    public void Switch(GameObject off, GameObject on)
    {
        off.SetActive(false);
        on.SetActive(true);
    }
}
