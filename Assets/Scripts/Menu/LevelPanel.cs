using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelPanel : MonoBehaviour
{
    public Font font;

    private void Start()
    {
        CreatButtonLevel(6); // изменить цифру при увеличении уровней (Создать доп панели или прокрутку при кол-во уровней превышающем длину экрана)
    }

    void StartLevel(int x)
    {
        PlayerPrefs.SetInt("Level", x);
        SceneManager.LoadScene($"Level{x}");
    } 

    private void CreatButtonLevel(int level)
    {
       // float rightPosition = 0;
        float levelPosition = -700f;
        for (int i = 0; i < level; i++)
        {
            CreateButton((i + 1).ToString(), (i + 1).ToString(), levelPosition, i+1);            levelPosition += 150;
            if (levelPosition >= 500)
            {
             //   gameObject.GetComponent<RectTransform>().right = new Vector3 (rightPosition - 150f, 0, 0);
              //  rightPosition -= 150;
            }
        }
    }
    private void CreateButton(string nameButton, string textButton,  float x, int level)
    {
        GameObject newButton = new GameObject(nameButton, typeof(Image), typeof(Button), typeof(LayoutElement));
        newButton.transform.SetParent(gameObject.transform);
        // newButton.GetComponent<LayoutElement>().minHeight = 35;
        newButton.GetComponent<RectTransform>().position = new Vector3(x, 0f, 0f);
        RectTransform rtButton = newButton.GetComponent<RectTransform>();
        rtButton.anchorMin = new Vector2(0.5f, 0.5f);
        rtButton.anchorMax = new Vector2(0.5f, 0.5f);
        rtButton.anchoredPosition = new Vector2(x, 0);
        rtButton.sizeDelta = new Vector2(100f, 100f);
        CreateText($"Text{nameButton}", textButton, newButton.transform);        
        newButton.GetComponent<Button>().onClick.AddListener(delegate { StartLevel(level); });
    }

    private void CreateText(string nameText, string textText, Transform spawnBlock)
    {
        GameObject newText = new GameObject(nameText, typeof(Text));
        newText.transform.SetParent(spawnBlock);
        newText.GetComponent<Text>().text = textText;
        newText.GetComponent<Text>().font = font;
        newText.GetComponent<Text>().resizeTextForBestFit = true;
        newText.GetComponent<Text>().resizeTextMaxSize = 100;
        newText.GetComponent<Text>().resizeTextMinSize = 14;
        RectTransform rt = newText.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(1, 1);
        rt.anchoredPosition = new Vector2(0, 0);
        rt.sizeDelta = new Vector2(0, 0);
        newText.GetComponent<Text>().color = Color.black;
        newText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
    }
}
