using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskScript : MonoBehaviour
{
    [SerializeField] private Text _taskText;
    [SerializeField] private GameObject _eventSystem;

    public void AfterNavigate()
    {
        int currentLevel = _eventSystem.GetComponent<StateMachine>().GetCurrentLevel();
        SetText(currentLevel);
    }

    private void SetText(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                _taskText.text = "Взломай замок, чтобы проникнуть в дом.";
                print("Level 1");
                break;
            case 2:
                _taskText.text = "Взломай замок, чтобы войти в комнату.";
                print("Level 2");
                break;
            case 3:
                _taskText.text = "Взломай сейф, чтобы получить драгоценности.";
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }
    }
}
