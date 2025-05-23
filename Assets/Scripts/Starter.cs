using UnityEngine;

public class Starter : MonoBehaviour
{
    void Start()
    {
        UIManager.Initialize();
        UIManager.Instance.CreateUI<StartUI>();
    }

    void Update()
    {

    }
}
