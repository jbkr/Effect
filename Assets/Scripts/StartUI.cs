using UnityEngine;
using UnityEngine.UI;

public class StartUI : UIBase
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button optionButton;

    [SerializeField]
    private Button quitButton;

    void Start()
    {

        if (startButton != null)
        {
            startButton.onClick.AddListener(GameManager.Instance.OnClickStartButton);
        }
    }
}