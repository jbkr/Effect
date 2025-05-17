using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIBase : MonoBehaviour { }

public class UIManager : MonoSingleton<UIManager>
{
    private Transform _canvasTrasn;

    private Dictionary<string, UIBase> _container = new Dictionary<string, UIBase>();

    private string _uiPath = "Prefab/";

    private void Awake()
    {
        if (_canvasTrasn == null)
        {
            gameObject.AddComponent<Canvas>();
            gameObject.AddComponent<CanvasScaler>();
            _canvasTrasn = gameObject.transform;
        }
        else
        {
            _canvasTrasn = transform;
        }
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
}