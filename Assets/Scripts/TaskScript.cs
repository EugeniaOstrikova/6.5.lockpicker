using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskScript : MonoBehaviour
{
    public Text taskText;

    public GameObject eventSystem;
    private StateMachine stateMachine;

    void Start()
    {
        stateMachine = eventSystem.GetComponent<StateMachine>();
    }


    public void afterNavigate()
    {
        int currentLevel = eventSystem.GetComponent<StateMachine>().getCurrentLevel();
        setText(currentLevel);
    }

    private void setText(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                taskText.text = "Взломай замок, чтобы проникнуть в дом.";
                print("Level 1");
                break;
            case 2:
                taskText.text = "Взломай замок, чтобы войти в комнату.";
                print("Level 2");
                break;
            case 3:
                taskText.text = "Взломай сейф, чтобы получить драгоценности.";
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }
    }
}
