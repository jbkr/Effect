using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    //[SerializeField]
    //private Transform _canvasTrasn;

    public bool _isPlay = false;

    private Action _sceneLoadComplete;

    private Enemy1 _player;

    private Opponent _opponent;

    public Enemy1 GetPlayer()
    {
        return _player;
    }

    public Opponent GetOpponent()
    {
        return _opponent;
    }

    void Start()
    {

    }

    public void OnPlayerHit()
    {
        UIManager.Instance.PlayerHPDown();
    }

    public void PlayerLose()
    {
        UIManager.Instance.CreateUI<LoseUI>();
        GetPlayer().SetPlayable(false);

        StartCoroutine(StartMainMenu());
    }

    public IEnumerator StartMainMenu()
    {
        Debug.Log("Start waiting...");
        yield return new WaitForSeconds(3); // Waits for 3 seconds
        Debug.Log("3 seconds later!");
        UIManager.Instance.RemoveUI<LoseUI>();
        UIManager.Instance.RemoveUI<FightUI>();
        yield return SceneManager.LoadSceneAsync("StartScene");
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
        realGO.transform.rotation = Quaternion.Euler(0, 210, 0);

        realGO.GetComponent<Enemy1>().SetPlayable(false);
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
        _player = playerGO.GetComponent<Enemy1>();
        //_isPlay = true;

        _player.SetPlayable(true);

        GameObject opponentRes = Resources.Load<GameObject>("Prefab/Opponent");
        GameObject opponentGO = Instantiate(opponentRes);
        _opponent = opponentGO.GetComponent<Opponent>();
        opponentGO.transform.position = new Vector3(2, 0, -1.0f);
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