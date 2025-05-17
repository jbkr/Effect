using UnityEngine;

public class Starter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager.Instance.CreateUI<StartUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
