using UnityEngine;
using UnityEngine.UI;

public class StageUI : UIBase
{
    [SerializeField]
    private Button stage1Button;

    [SerializeField]
    private Button stage2Button;

    [SerializeField]
    private Button stage3Button;

    [SerializeField]
    private Button stage4Button;

    void Start()
    {

        if (stage1Button != null)
        {
            stage1Button.onClick.AddListener(GameManager.Instance.OnClickStage1Button);
        }
    }
}
