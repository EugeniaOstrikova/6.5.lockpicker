using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolScript : MonoBehaviour
{
    public Text pinText1;
    public Text pinText2;
    public Text pinText3;

    public int stepForPin1;
    public int stepForPin2;
    public int stepForPin3;

    public Text stepText;

    void Start()
    {
        stepText.text = createStepText();
    }

    private string createStepText ()
    {
        return $"{stepForPin1}|{stepForPin2}|{stepForPin3}";
    }

    public void updatePins ()
    {
        pinText1.text = updatePin(pinText1, stepForPin1);
        pinText2.text = updatePin(pinText2, stepForPin2);
        pinText3.text = updatePin(pinText3, stepForPin3);
    }

    private string updatePin (Text pinText, int stepForPin)
    {
        int pinNewText = Convert.ToInt32(pinText.text) + stepForPin;

        if (pinNewText == 10)
            pinNewText = 0;
        else if (pinNewText == -1)
            pinNewText = 9;

        return pinNewText.ToString();
    }

    void Update()
    {
        
    }
}
