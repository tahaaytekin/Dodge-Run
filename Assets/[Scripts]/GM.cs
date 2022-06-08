
using ElephantSDK;
using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject level;
    public Text level_text;
    public int currentLevel;
    public bool testMode;
    public GameObject winPanel, losePanel, IngamePanel;
    public static GM Instance;
    public void Awake()
    {
        Instance = this;
       /* Elephant.LevelStarted(currentLevel);
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            //Handle FB.Init
            FB.Init(() =>
            {
                FB.ActivateApp();
            });
        }*/

    }
    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        if (!testMode) OpenCurrentLevel();
    }
    private void OpenCurrentLevel()
    {
        level_text.text = "LEVEL " + (currentLevel + 1);

        if (currentLevel > 5)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            //  currentLevel = Random.Range(0, 4);
            level = (GameObject)Instantiate(Resources.Load("Level" + Random.Range(0, 6)));
        }
        else
        {
            level = (GameObject)Instantiate(Resources.Load("Level" + currentLevel));
        }
    }
    public void SeviyeAtlama()
    {
       
        PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public IEnumerator OpenWinPanel()
    {
        yield return new WaitForSeconds(1f);
        //  Elephant.LevelCompleted(currentLevel);
        losePanel.SetActive(false);
        IngamePanel.SetActive(false);
        winPanel.SetActive(true);
      
    }
    public IEnumerator OpenLosePanel()
    {
        yield return new WaitForSeconds(1f);
        Elephant.LevelFailed(currentLevel);
        losePanel.SetActive(true);
        IngamePanel.SetActive(false);
        winPanel.SetActive(false);
    }
}
