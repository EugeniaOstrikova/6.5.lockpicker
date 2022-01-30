using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text timerText;
    public float timerTime = 30;
    private float timeRemaining;

    public Text pinText1;
    public Text pinText2;
    public Text pinText3;

    public int startPinText1;
    public int startPinText2;
    public int startPinText3;

    private bool isGame = false;

    public GameObject eventSystem;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    private StateMachine stateMachine;

    void Start()
    {
        stateMachine = eventSystem.GetComponent<StateMachine>();

        startGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (pinText1.text == pinText2.text && pinText1.text == pinText3.text)
        {
            winLevel();
        }
        
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.FloorToInt(timeRemaining).ToString();
        }
        else if (timeRemaining <= 0 && isGame)
        {
            loseGame();
            isGame = false;
        }
    }

    public void startGame()
    {
        int currentLevel = eventSystem.GetComponent<StateMachine>().getCurrentLevel();
        isGame = true;

        timeRemaining = timerTime;
        timerText.text = timerTime.ToString();

        setStartPins(currentLevel);
    }

    private void setStartPins(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                startPinText1 = 9;
                startPinText2 = 5;
                startPinText3 = 5;
                print("Level 1");
                break;
            case 2:
                startPinText1 = 0;
                startPinText2 = 4;
                startPinText3 = 6;
                print("Level 2");
                break;
            case 3:
                startPinText1 = 1;
                startPinText2 = 3;
                startPinText3 = 7;
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }

        pinText1.text = startPinText1.ToString();
        pinText2.text = startPinText2.ToString();
        pinText3.text = startPinText3.ToString();
    }

    private void winLevel()
    {
        stateMachine.ChangeState(winCanvas);
        winCanvas.GetComponent<WinPopupScript>().afterNavigate();
    }

    private void loseGame()
    {
        stateMachine.ChangeState(loseCanvas);
        loseCanvas.GetComponent<LosePopupScript>().afterNavigate();
    }
}
