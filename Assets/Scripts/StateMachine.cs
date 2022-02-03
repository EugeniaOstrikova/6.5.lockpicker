using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject _menuScreen;

    private GameObject _currentScreen;
    private int _currentLevel = 1;

    private void Start()
    {
        _menuScreen.SetActive(true);
        _currentScreen = _menuScreen;
    }

    public void ChangeState(GameObject nextScreen)
    {
        if (_currentScreen != null)
        {
            _currentScreen.SetActive(false);
            nextScreen.SetActive(true);
            _currentScreen = nextScreen;
        }
    }

    public int GetCurrentLevel()
    {
        return _currentLevel;
    }

    public void SetCurrentLevel(int nextLevel)
    {
        _currentLevel = nextLevel;
    }

}
