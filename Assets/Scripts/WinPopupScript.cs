using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPopupScript : MonoBehaviour
{
    public Text popupText;

    public Sprite img1;
    public Sprite img2;
    public Sprite img3;

    public GameObject eventSystem;
    public GameObject taskCanvas;
    public GameObject manuCanvas;

    public Image textImg;

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
        eventSystem.GetComponent<StateMachine>().setCurrentLevel(++currentLevel);
    }

    public void navigateToNextScreen()
    {
        int currentLevel = eventSystem.GetComponent<StateMachine>().getCurrentLevel();

        if (currentLevel < 4)
        {
            stateMachine.ChangeState(taskCanvas);
            taskCanvas.GetComponent<TaskScript>().afterNavigate();
        } else
        {
            stateMachine.ChangeState(manuCanvas);
            eventSystem.GetComponent<StateMachine>().setCurrentLevel(1);
        }
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
                popupText.text = "Ты справляешься с замком и проходишь внутрь дома. Ты достаешь фонарик и осматриваешься. Наверняка драгоценности лежат в сейфе. Ты видишь запертую дверь и решаешь, что за ней точно должно быть что-то интересное. Правда на двери висит необычный замок...";
                print("Level 1");
                break;
            case 2:
                popupText.text = "Дверь наконец-то поддается и ты входишь в кабинет. Ты осматриваешь стол, но не находишь ничего стоящего. Внезапно твой взгляд падает на картину. Ты не особо надеясь на чудо, но решаешь проверить что находится за этой картиной. Кажется хозяева дома смотрели много фильмов как и ты и действительно спрятали сейф за картиной...";
                print("Level 2");
                break;
            case 3:
                popupText.text = "Хотя замок и был не простой ты смог с ним справится. Ты в предвкушении открываешь дверь сейфа и находишь прекрасное колье и пару браслетов с драгоценными камнями. Кажется все твои усилия неплохо окупятся. Не забудь отблагодарить своего информатора за наводку.";
                print("Level 3");
                break;
            default:
                print("Level 0");
                break;
        }
    }
}
