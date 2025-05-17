using UnityEngine;

public class TimeDestroyer : MonoBehaviour
{
    private float _destroyTime = 0;
    private float _accTime = 0;
    void Start()
    {
        ParticleSystem comp = GetComponent<ParticleSystem>();
        _destroyTime = comp.main.duration;
        _accTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _accTime += Time.deltaTime;

        if (_accTime > _destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
