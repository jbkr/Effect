using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseUI1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        Debug.Log("Start waiting...");
        yield return new WaitForSeconds(3); // Waits for 3 seconds
        Debug.Log("3 seconds later!");
        this.gameObject.SetActive(false);
        yield return SceneManager.LoadSceneAsync("StartScene");
    }

}
