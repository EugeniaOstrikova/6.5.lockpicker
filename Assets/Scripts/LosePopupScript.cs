using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePopupScript : MonoBehaviour
{
    [SerializeField] private Text _popupText;
    [SerializeField] private Image _popupImg;

    [SerializeField] private Sprite _img1;
    [SerializeField] private Sprite _img2;
    [SerializeField] private Sprite _img3;

    [SerializeField] private GameObject _eventSystem;

    public void AfterNavigate()
    {
        int currentLevel = _eventSystem.GetComponent<StateMachine>().GetCurrentLevel();
        SetText(currentLevel);
        SetImg(currentLevel);
        _eventSystem.GetComponent<StateMachine>().SetCurrentLevel(1);
    }

    private void SetImg(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                _popupImg.sprite = _img1;
                break;
            case 2:
                _popupImg.sprite = _img2;
                break;
            case 3:
                _popupImg.sprite = _img3;
                break;
            default:
                _popupImg.sprite = _img1;
                break;
        }
    }

    private void SetText(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                _popupText.text = "“ы слишком долго возилс€ с замком. —оседи услышали подозрительный шум и вызвали полицию.  ажетс€ в выходные ты не сможешь сходить с друзь€ми в бар и рассказать о легком деле.";
                print("Level 1");
                break;
            case 2:
                _popupText.text = "«амок на двери оказалс€ слишком хитрым и ты с ним не справилс€. “ы осмотрел весь оставшийс€ дом, но не нашел ничего интересного. –асстроенный, ты ушел прихватив с собой небольшую статуэтку, в надежде, что сможешь ее продать и заработать хоть немного. ¬озможно на заработанные деньги ты сможешь купить пару бокалов пива, но рассказывать эту историю своим коллегам €вно не стоит.";
                print("Level 2");
                break;
            case 3:
                _popupText.text = "“ы пыталс€ открыть сейф, но не учел тот факт, что на нем есть сигнализаци€. ѕолици€ отреагировала так быстро, что у теб€ не было ни малейшего шанса уйти незамеченным. ¬есьма обидно, ведь драгоценности были так близко.";
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }
    }
}
