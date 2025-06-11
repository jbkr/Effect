using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoSingleton<GameManager>
{
    //[SerializeField]
    //private Transform _canvasTrasn;

    public bool _isPlay = false;

    private Action _sceneLoadComplete;

    private Player _player;

    public Player GetPlayer()
    {
        return _player;
    }

    void Start()
    {

    }

    public void OnPlayerHit()
    {
        UIManager.Instance.PlayerHPDown();
    }

    public void OnClickStartButton()
    {
        _sceneLoadComplete = OnLobbyLoadComplete;
        LoadScene("LobbyScene");
    }

    private void OnLobbyLoadComplete()
    {
        UIManager.Instance.RemoveUI<StartUI>();
        UIManager.Instance.CreateUI<LobbyUI>();

        GameObject resGO = Resources.Load<GameObject>("Prefab/Player");
        GameObject realGO = Instantiate(resGO);
        realGO.transform.position = new Vector3(2, 0, 15);
        //realGO.transform.Rotate(new Vector3(0, 210, 0));
        realGO.transform.rotation = Quaternion.Euler(0, 210, 0);
    }

    public void OnClickFightButton()
    {
        _sceneLoadComplete = OnStageLoadComplete;
        LoadScene("StageScene");
    }

    private void OnStageLoadComplete()
    {
        UIManager.Instance.RemoveUI<LobbyUI>();
        UIManager.Instance.CreateUI<StageUI>();
    }

    public void OnClickStageButton()
    {
        _sceneLoadComplete = OnGameLoadComplete;
        LoadScene("GameScene");
    }

    private void OnGameLoadComplete()
    {
        UIManager.Instance.RemoveUI<StageUI>();
        UIManager.Instance.CreateUI<FightUI>();

        GameObject playerRes = Resources.Load<GameObject>("Prefab/Player");
        GameObject playerGO = Instantiate(playerRes);
        playerGO.transform.position = new Vector3(-2, 0, -1.0f);
        _player = playerGO.GetComponent<Player>();
        //_isPlay = true;

        GameObject opponentRes = Resources.Load<GameObject>("Prefab/Opponent");
        GameObject opponentGO = Instantiate(opponentRes);
        opponentGO.transform.position = new Vector3(2, 0, -1.0f);
    }

    private void Update()
    {

    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName);
        _sceneLoadComplete?.Invoke();



        // �÷��̾� �������ָ� �� 
        //GameObject resGO = Resources.Load<GameObject>("Prefab/PangPlayer");
        //GameObject realGO = Instantiate(resGO);
        //realGO.transform.position = new Vector3(0, -2.66f, 0);
        //_isPlay = true;

        //// ��浵 �ε��ؾ߰ڴ�.
        //GameObject bottomRes = Resources.Load<GameObject>("Prefab/Bottom");
        //GameObject bottomGo = Instantiate(bottomRes);

        //// �Ϲ� ���� �����غ��߰ڴ�. 
        //GameObject gongRes = Resources.Load<GameObject>("Prefab/Gong");
        //GameObject gongGo = Instantiate(gongRes);
        //gongGo.transform.position = new Vector3(0, 6, 0);
        //Transform tr = realGO.transform;

        //UIManager.Instance.CreateUI<ScoreUI>();
    }



    public void CreateEffect(Vector3 pos)
    {
        // �Ϲ� ���� �����غ��߰ڴ�. 
        GameObject gongRes = Resources.Load<GameObject>("Prefab/ExplosionEffect");
        GameObject gongGo = Instantiate(gongRes);
        gongGo.transform.position = pos;
    }

    int index = 0;

    private IEnumerator TimeCheck()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);


            index++;

            Debug.Log("index : " + index);
        }
    }





    private void OnClickStageMode()
    {

    }

}