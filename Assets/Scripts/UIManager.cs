using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour { }

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Transform _canvasTrasn;

    private Dictionary<string, UIBase> _container = new Dictionary<string, UIBase>();

    private string _uiPath = "Prefab/";

    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private static UIManager _instance;

    public static void Initialize()
    {
        UIManager res = Resources.Load<UIManager>("Prefab/UIManager");
        _instance = Instantiate(res);
        DontDestroyOnLoad(_instance.gameObject);
    }

    public void CreateUI<T>() where T : UIBase
    {
        GameObject resGO = Resources.Load<GameObject>(_uiPath + typeof(T).ToString());
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        T comp = sceanGO.GetComponent<T>();

        _container.Add(typeof(T).ToString(), comp);
    }

    public void RemoveUI<T>() where T : UIBase
    {
        UIBase uiBase;
        bool result = _container.TryGetValue(typeof(T).ToString(), out uiBase);

        if (result)
        {
            Destroy(uiBase.gameObject);
            _container.Remove(typeof(T).ToString());
        }
        else
        {
            Debug.Log("failed remove");
        }
    }

    public T GetUI<T>() where T : UIBase
    {
        UIBase uiBase;
        bool result = _container.TryGetValue(typeof(T).ToString(), out uiBase);

        T t;
        if (result)
        {
            t = uiBase as T;
            if (t != null)
            {
                return t;
            }
        }
        return null;
    }

    public void AddScore()
    {
        //GetUI<ScoreUI>().ChangeScore(20000);
    }

    public void PlayerHPDown()
    {
        GetUI<FightUI>().PlayerDamaged();
    }
}