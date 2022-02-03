using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPopupScript : MonoBehaviour
{
    [SerializeField] private Text _popupText;
    [SerializeField] private Image _popupImg;

    [SerializeField] private Sprite _img1;
    [SerializeField] private Sprite _img2;
    [SerializeField] private Sprite _img3;

    [SerializeField] private GameObject _eventSystem;
    [SerializeField] private GameObject _taskCanvas;
    [SerializeField] private GameObject _menuCanvas;

    private StateMachine _stateMachine;

    private void Start()
    {
        _stateMachine = _eventSystem.GetComponent<StateMachine>();
    }

    public void AfterNavigate()
    {
        int currentLevel = _eventSystem.GetComponent<StateMachine>().GetCurrentLevel();
        SetText(currentLevel);
        SetImg(currentLevel);
        _eventSystem.GetComponent<StateMachine>().SetCurrentLevel(++currentLevel);
    }

    public void NavigateToNextScreen()
    {
        int currentLevel = _eventSystem.GetComponent<StateMachine>().GetCurrentLevel();

        if (currentLevel < 4)
        {
            _stateMachine.ChangeState(_taskCanvas);
            _taskCanvas.GetComponent<TaskScript>().AfterNavigate();
        } else
        {
            _stateMachine.ChangeState(_menuCanvas);
            _eventSystem.GetComponent<StateMachine>().SetCurrentLevel(1);
        }
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
                _popupText.text = "Ты справляешься с замком и проходишь внутрь дома. Ты достаешь фонарик и осматриваешься. Наверняка драгоценности лежат в сейфе. Ты видишь запертую дверь и решаешь, что за ней точно должно быть что-то интересное. Правда на двери висит необычный замок...";
                print("Level 1");
                break;
            case 2:
                _popupText.text = "Дверь наконец-то поддается и ты входишь в кабинет. Ты осматриваешь стол, но не находишь ничего стоящего. Внезапно твой взгляд падает на картину. Ты не особо надеясь на чудо, но решаешь проверить что находится за этой картиной. Кажется хозяева дома смотрели много фильмов как и ты и действительно спрятали сейф за картиной...";
                print("Level 2");
                break;
            case 3:
                _popupText.text = "Хотя замок и был не простой ты смог с ним справится. Ты в предвкушении открываешь дверь сейфа и находишь прекрасное колье и пару браслетов с драгоценными камнями. Кажется все твои усилия неплохо окупятся. Не забудь отблагодарить своего информатора за наводку.";
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }
    }
}
