using UnityEngine;
using UnityEngine.UI;

public class StageUI : UIBase
{
    [SerializeField]
    private CustomButton[] customButtons;


    private int currentIndex;

    void Start()
    {
        for (int i = 0; i < customButtons.Length; i++)
        {
            customButtons[i].setIndex(i);
            customButtons[i].onClick.AddListener(OnCustomButtonClicked);
            customButtons[i].targetGraphic.color = new Color(1, 1, 1);
        }
    }

    public void setCurrentIndex(int index)
    {
        currentIndex = index;
    }

    private void OnCustomButtonClicked()
    {
        for (int i = 0; i < customButtons.Length; i++)
        {
            customButtons[i].targetGraphic.color = new Color(1, 1, 1);
        }
        customButtons[currentIndex].targetGraphic.color = new Color(204f / 255f, 88f / 255f, 251f / 255f);
        GameManager.Instance.OnClickStageButton();
    }
}
