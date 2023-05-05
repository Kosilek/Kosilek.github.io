using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsFinichSelect : MonoBehaviour
{
    public static string  finishSelect= "FinishSelect";
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
        CharacterSelection.Save(finishSelect, choicePack);
    }

        public void Back()
        {
            if (choicePack != PlayerPrefs.GetInt(finishSelect))
            {
                savePanel.SetActive(true);
            }
            else if (choicePack == PlayerPrefs.GetInt(finishSelect))
            {
                MainMenuPanel.SetActive(true);
                gameObject.SetActive(false);
            }
        }
}
