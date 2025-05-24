using UnityEngine;
using UnityEngine.UI;

public class StageUI : UIBase
{
    [SerializeField]
    private Button[] _stageButtons;

    private int _selectedIndex = -1;

    [SerializeField]
    private Sprite normalButtonSprite;

    [SerializeField]
    private Sprite pressedButtonSprite;

    void Start()
    {
        for (int i = 0; i < _stageButtons.Length; i++)
        {
            _stageButtons[i].onClick.AddListener(() =>
            {
                OnClickButton(i);
            });
        }

        foreach (var button in _stageButtons)
        {
            if (button != null)
            {
                //stage1Button.onClick.AddListener(GameManager.Instance.OnClickStage1Button);
                //button.onClick.AddListener(delegate { OnButtonPressed(button, buttons); });
                button.onClick.AddListener(() => OnButtonPressed(button, _stageButtons));
            }
        }
    }

    public void SelectStage(int selectedIndex)
    {
        Debug.Log("Stage index : " + selectedIndex);
    }

    private void OnClickButton(int index)
    {
        Debug.Log(index);
    }

    public void OnButtonPressed(Button _button, Button[] buttons)
    {
        Debug.Log("Button Pressed");
        _button.image.sprite = pressedButtonSprite;

        foreach (Button button in buttons)
        {
            if (button != _button)
            {
                button.image.sprite = normalButtonSprite;
            }
        }
    }
}
