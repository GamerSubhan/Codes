using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    public Button level02button, level03button, level04button, level05button, level06button, level07button;
    int levelPassed;
    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02button.interactable = false;
        level03button.interactable = false;
        level04button.interactable = false;
        level05button.interactable = false;
        level06button.interactable = false;
        level07button.interactable = false;

        switch (levelPassed) {
            case 1: 
                level02button.interactable = true;
                break;
            case 2:
                level02button.interactable = true;
                level03button.interactable = true;
                break;
            case 3:
                level02button.interactable = true;
                level03button.interactable = true;
                level04button.interactable = true;
                break;
            case 4:
                level02button.interactable = true;
                level03button.interactable = true;
                level04button.interactable = true;
                level05button.interactable = true;
                break;
            case 5:
                level02button.interactable = true;
                level03button.interactable = true;
                level04button.interactable = true;
                level05button.interactable = true;
                level06button.interactable = true;
                break;
            case 6:
                level02button.interactable = true;
                level03button.interactable = true;
                level04button.interactable = true;
                level05button.interactable = true;
                level06button.interactable = true;
                level07button.interactable = true;
                break;

        }

    }

    public void levelToLoad(int level){
        SceneManager.LoadScene(level);
    }
}
