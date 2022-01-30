using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePopupScript : MonoBehaviour
{
    public Text popupText;

    public Sprite img1;
    public Sprite img2;
    public Sprite img3;

    public Image textImg;

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
        setImg(currentLevel);
        eventSystem.GetComponent<StateMachine>().setCurrentLevel(1);
    }

    private void setImg(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                textImg.sprite = img1;
                break;
            case 2:
                textImg.sprite = img2;
                break;
            case 3:
                textImg.sprite = img3;
                break;
            default:
                textImg.sprite = img1;
                break;
        }
    }

    private void setText(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                popupText.text = "�� ������� ����� ������� � ������. ������ �������� �������������� ��� � ������� �������. ������� � �������� �� �� ������� ������� � �������� � ��� � ���������� � ������ ����.";
                print("Level 1");
                break;
            case 2:
                popupText.text = "����� �� ����� �������� ������� ������ � �� � ��� �� ���������. �� �������� ���� ���������� ���, �� �� ����� ������ �����������. ������������, �� ���� ��������� � ����� ��������� ���������, � �������, ��� ������� �� ������� � ���������� ���� �������. �������� �� ������������ ������ �� ������� ������ ���� ������� ����, �� ������������ ��� ������� ����� �������� ���� �� �����.";
                print("Level 2");
                break;
            case 3:
                popupText.text = "�� ������� ������� ����, �� �� ���� ��� ����, ��� �� ��� ���� ������������. ������� ������������� ��� ������, ��� � ���� �� ���� �� ��������� ����� ���� ������������. ������ ������, ���� ������������� ���� ��� ������.";
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }
    }
}
