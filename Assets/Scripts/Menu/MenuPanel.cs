using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPanel : MonoBehaviour
{
    private int level;
    private void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }
    }
    public void Play()
    {
        PathControll.i = 0;
        SceneManager.LoadScene($"Level{level}");
    }
}
