using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField]
    GameObject EffectGO;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(EffectGO, Vector3.zero, Quaternion.identity);
        }
    }
}
