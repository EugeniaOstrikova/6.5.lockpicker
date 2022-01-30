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
                popupText.text = "“ы слишком долго возилс€ с замком. —оседи услышали подозрительный шум и вызвали полицию.  ажетс€ в выходные ты не сможешь сходить с друзь€ми в бар и рассказать о легком деле.";
                print("Level 1");
                break;
            case 2:
                popupText.text = "«амок на двери оказалс€ слишком хитрым и ты с ним не справилс€. “ы осмотрел весь оставшийс€ дом, но не нашел ничего интересного. –асстроенный, ты ушел прихватив с собой небольшую статуэтку, в надежде, что сможешь ее продать и заработать хоть немного. ¬озможно на заработанные деньги ты сможешь купить пару бокалов пива, но рассказывать эту историю своим коллегам €вно не стоит.";
                print("Level 2");
                break;
            case 3:
                popupText.text = "“ы пыталс€ открыть сейф, но не учел тот факт, что на нем есть сигнализаци€. ѕолици€ отреагировала так быстро, что у теб€ не было ни малейшего шанса уйти незамеченным. ¬есьма обидно, ведь драгоценности были так близко.";
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }
    }
}
