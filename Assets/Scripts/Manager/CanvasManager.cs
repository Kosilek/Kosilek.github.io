using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Profiling;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class CanvasManager : Singelton<CanvasManager>
{
    public GameObject finishPanel;
    public GameObject failedPanel;
    public GameObject helpMainPanel;
    public Text finishTimerText;
    public Sprite[] heplSprite;
    public GameObject helpPanel;

    private float finishTimer;

    protected override void Awake()
    {
        base.Awake();
        finishPanel.SetActive(false);
        failedPanel.SetActive(false);
        helpMainPanel.SetActive(false);
        Event.OnFinishTimer.AddListener(FinishTimer);
        Event.OnFinish.AddListener(Finish);
        Event.OnFailed.AddListener(Failed);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        int level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene($"Level{level}");
    }

    public void NextLevel()
    {
        int level = PlayerPrefs.GetInt("Level") + 1;
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene($"Level{level}");
    }

    public void Failed()
    {
        failedPanel.SetActive(true);
    }

    public void Finish()
    {
        finishPanel.SetActive(true);
        finishTimerText.text = ("Ваше время" + finishTimer.ToString());
    }

    public void FinishTimer(float timer)
    {
        finishTimer = timer;
    }

    public void Help()
    {
        int i;
        i = PlayerPrefs.GetInt("Level") - 2;
        helpPanel.GetComponent<Image>().sprite = heplSprite[i];
    }
}
