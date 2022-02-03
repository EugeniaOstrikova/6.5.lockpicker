using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private float _timerTime = 30;
    [SerializeField] private float _timeRemaining;

    [SerializeField] private Text _pinText1;
    [SerializeField] private Text _pinText2;
    [SerializeField] private Text _pinText3;

    [SerializeField] private int _startPinText1;
    [SerializeField] private int _startPinText2;
    [SerializeField] private int _startPinText3;

    [SerializeField] private GameObject _eventSystem;
    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _loseCanvas;

    private StateMachine _stateMachine;
    private bool _isGame = false;

    private void Start()
    {
        _stateMachine = _eventSystem.GetComponent<StateMachine>();

        StartGame();
    }

    private void Update()
    {
        if (_pinText1.text == _pinText2.text && _pinText1.text == _pinText3.text)
        {
            WinLevel();
        }
        
        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            _timerText.text = Mathf.FloorToInt(_timeRemaining).ToString();
        }
        else if (_timeRemaining <= 0 && _isGame)
        {
            LoseGame();
            _isGame = false;
        }
    }

    public void StartGame()
    {
        int currentLevel = _eventSystem.GetComponent<StateMachine>().GetCurrentLevel();
        _isGame = true;

        _timeRemaining = _timerTime;
        _timerText.text = _timerTime.ToString();

        SetStartPins(currentLevel);
    }

    private void SetStartPins(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                _startPinText1 = 9;
                _startPinText2 = 5;
                _startPinText3 = 5;
                print("Level 1");
                break;
            case 2:
                _startPinText1 = 0;
                _startPinText2 = 4;
                _startPinText3 = 6;
                print("Level 2");
                break;
            case 3:
                _startPinText1 = 1;
                _startPinText2 = 3;
                _startPinText3 = 7;
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }

        _pinText1.text = _startPinText1.ToString();
        _pinText2.text = _startPinText2.ToString();
        _pinText3.text = _startPinText3.ToString();
    }

    private void WinLevel()
    {
        _stateMachine.ChangeState(_winCanvas);
        _winCanvas.GetComponent<WinPopupScript>().AfterNavigate();
    }

    private void LoseGame()
    {
        _stateMachine.ChangeState(_loseCanvas);
        _loseCanvas.GetComponent<LosePopupScript>().AfterNavigate();
    }
}
