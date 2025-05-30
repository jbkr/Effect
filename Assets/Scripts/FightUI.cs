using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightUI : UIBase
{
    [SerializeField]
    private TextMeshProUGUI m_Time;
    private int startTime;
    private int currentTime;
    private float accTime;

    [SerializeField]
    private Slider playerHPBar;
    [SerializeField]
    private Slider opponentHPBar;

    void Start()
    {
        startTime = 100;
        currentTime = startTime;
        m_Time.text = startTime.ToString();
    }

    void Update()
    {
        ShowRoundTime();

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerHPBar.value -= 0.1f;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            opponentHPBar.value -= 0.1f;
        }


    }

    void ShowRoundTime()
    {
        if (currentTime <= 0)
        {
            Debug.Log("Game Over");
            return;
        }

        accTime += Time.deltaTime;
        if (accTime >= 1.0f)
        {
            currentTime--;
            accTime = 0;
        }

        m_Time.text = currentTime.ToString();
    }
}
