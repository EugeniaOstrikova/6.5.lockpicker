using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject menuScreen;
    private GameObject currentScreen;
    private int currentLevel = 1;

    void Start()
    {
        menuScreen.SetActive(true);
        currentScreen = menuScreen;
    }

    public void ChangeState(GameObject nextScreen)
    {
        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
            nextScreen.SetActive(true);
            currentScreen = nextScreen;
        }
    }

    public int getCurrentLevel()
    {
        return currentLevel;
    }

    public void setCurrentLevel(int nextLevel)
    {
        currentLevel = nextLevel;
    }

}
