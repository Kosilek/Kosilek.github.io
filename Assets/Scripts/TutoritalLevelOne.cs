using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoritalLevelOne : MonoBehaviour
{
    [SerializeField]private GameObject introductionPanel;
    [SerializeField]private GameObject tutoritalPlayer1;
    [SerializeField]private GameObject tutoritalPlayer2;
    [SerializeField] private GameObject intermediatePanel;

    private void Awake()
    {
        introductionPanel.SetActive(true);
        tutoritalPlayer1.SetActive(false);
        tutoritalPlayer2.SetActive(false);
        intermediatePanel.SetActive(false);
    }

    public void checkPathOne()
    {
        if(PathControll.i == 1)
        {
            tutoritalPlayer2.SetActive(true);
            intermediatePanel.SetActive(false);
        }
    }
}
