using UnityEngine;

public class AgentTest : MonoBehaviour
{
    private float _speed = 5.0f;
    private Vector3 _destination;

    void Start()
    {
        _destination = transform.position;
    }

    void Update()
    {
        MoveToDestination();
    }

    private void MoveToDestination()
    {
        float distance = Vector3.Distance(transform.position, _destination);
        if (distance < 0.1f)
            return;

        Vector3 direction = _destination - transform.position;
        direction.Normalize();
        transform.position += direction * _speed * Time.deltaTime;
    }

    public void SetDestination(Vector3 destination)
    {
        _destination = destination;
    }
}
