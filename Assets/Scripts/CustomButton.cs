using UnityEngine;
using UnityEngine.UI;

public class CustomButton : Button
{
    private StageUI stageUI;

    private int index;

    protected override void Start()
    {
        stageUI = GetComponentInParent<StageUI>();
        onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        stageUI.setCurrentIndex(index);
        Debug.Log("current index : " + index);
    }

    public void setIndex(int index)
    {
        this.index = index;
    }
}
