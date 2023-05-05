using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayerSelect : MonoBehaviour
{
    public static string playerSelect = "PlayerSelect";
    int choicePack;
    public GameObject savePanel;
    public GameObject MainMenuPanel;

    public void SelectPack(int x)
    {
        CharacterSelection.SelectPack(x);
        choicePack = CharacterSelection.ChoiceSkin;
    }

    public void Save()
    {
        CharacterSelection.Save(playerSelect, choicePack);
    }
  public void Back()
        {
            if (choicePack != PlayerPrefs.GetInt(playerSelect))
            {
                savePanel.SetActive(true);
            }
            else if (choicePack == PlayerPrefs.GetInt(playerSelect))
            {
                MainMenuPanel.SetActive(true);
                gameObject.SetActive(false);
            }
        }
}
