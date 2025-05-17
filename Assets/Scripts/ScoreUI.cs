using UnityEngine;
using TMPro;

public class ScoreUI : UIBase
{
    TextMeshProUGUI _scoreText;

    void Start()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    // ��������Ҷ��� �긦 ����� 
    public void ChangeScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // �갡 �׽�Ʈ �ڵ尡 �� 
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    ChangeScore(4885);
        //}

    }
}