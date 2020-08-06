using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public int asteroidScore = 0;
    public int asteroidAim = 0;
    public Scene scene;
    public int levelConditions = 0;
    public int condition;
    static public PlayManager instance;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("LevelConditions"))
            levelConditions = PlayerPrefs.GetInt("LevelConditions");
    }
    void Start()
    {
        if(PlayManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PlayManager.instance = this;
    }

    void Update()
    {
        // Проверка сохранений
        //if (Input.GetKeyDown(KeyCode.Backspace))
        //    if (PlayerPrefs.HasKey("LevelConditions"))
        //        Debug.Log(condition = PlayerPrefs.GetInt("LevelConditions"));

        //if (Input.GetKeyDown(KeyCode.Escape)) PlayerPrefs.DeleteAll();

        if (PlayerController.shipLives > 0)
            if (asteroidScore == asteroidAim)
                switch (UIManager.instance.chosenLevel)
                {
                    case 1:
                        Time.timeScale = 0f;
                        levelConditions = 1;
                        PlayerPrefs.SetInt("LevelConditions", levelConditions);
                        UIManager.instance.panelWin.SetActive(true);
                        SoundManager.instance.backgroundMusic.Stop();
                        SoundManager.instance.winSound.Play();
                        StartCoroutine(LevelReload());
                        break;
                    case 2:
                        Time.timeScale = 0f;
                        levelConditions = 2;
                        PlayerPrefs.SetInt("LevelConditions", levelConditions);
                        UIManager.instance.panelWin.SetActive(true);
                        SoundManager.instance.backgroundMusic.Stop();
                        SoundManager.instance.winSound.Play();
                        StartCoroutine(LevelReload());
                        break;
                    case 3:
                        Time.timeScale = 0f;
                        levelConditions = 3;
                        PlayerPrefs.SetInt("LevelConditions", levelConditions);
                        UIManager.instance.panelWin.SetActive(true);
                        SoundManager.instance.backgroundMusic.Stop();
                        SoundManager.instance.winSound.Play();
                        StartCoroutine(LevelReload());
                        break;
                }
        if (PlayerController.shipLives == 0)
        {
            UIManager.instance.panelLose.SetActive(true);
            SoundManager.instance.backgroundMusic.Stop();
            SoundManager.instance.loseSound.Play();
            Time.timeScale = 0f;
            StartCoroutine(LevelReload());
        }
    }
    IEnumerator LevelReload()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
