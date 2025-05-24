using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : UIBase
{
    [SerializeField]
    private Button fightButton;
    void Start()
    {
        fightButton.onClick.AddListener(GameManager.Instance.OnClickFightButton);

    }

    void Update()
    {

    }
}
