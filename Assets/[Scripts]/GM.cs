
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
    public GameObject winPanel, losePanel;
    public static GM Instance;
    public void Awake()
    {
        Instance = this;
      /*  GameAnalytics.Initialize();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, PlayerPrefs.GetInt("Level").ToString());
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
       // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, PlayerPrefs.GetInt("Level").ToString());
        PlayerPrefs.SetInt("Tutorial", 1);
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Restart()
    {
      //  GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, PlayerPrefs.GetInt("Level").ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
