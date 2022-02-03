using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolScript : MonoBehaviour
{
    [SerializeField] private Text _pinText1;
    [SerializeField] private Text _pinText2;
    [SerializeField] private Text _pinText3;

    [SerializeField] private int _stepForPin1;
    [SerializeField] private int _stepForPin2;
    [SerializeField] private int _stepForPin3;

    [SerializeField] private Text _stepText;

    private void Start()
    {
        _stepText.text = CreateStepText();
    }

    public void UpdatePins()
    {
        _pinText1.text = UpdatePin(_pinText1, _stepForPin1);
        _pinText2.text = UpdatePin(_pinText2, _stepForPin2);
        _pinText3.text = UpdatePin(_pinText3, _stepForPin3);
    }
    private string CreateStepText()
    {
        return $"{_stepForPin1}|{_stepForPin2}|{_stepForPin3}";
    }

    private string UpdatePin(Text pinText, int stepForPin)
    {
        int pinNewText = Convert.ToInt32(pinText.text) + stepForPin;

        if (pinNewText == 10)
            pinNewText = 0;
        else if (pinNewText == -1)
            pinNewText = 9;

        return pinNewText.ToString();
    }

}
