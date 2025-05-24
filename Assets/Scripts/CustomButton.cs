using UnityEngine;
using UnityEngine.UI;

public class CustomButton : Button
{
    public int UIIndex;
    public StageUI stageUI;

    protected override void Start()
    {
        onClick.AddListener(OnClickCallback);
    }

    private void OnClickCallback()
    {
        //stageUI.
    }
}
