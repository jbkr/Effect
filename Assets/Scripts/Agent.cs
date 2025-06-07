using UnityEngine;

public class Agent : MonoBehaviour
{
    void Start()
    {
        destination = transform.position;
    }

    private Vector3 destination;
    private float distance;
    private Vector3 direction;
    private float speed = 5.0f;

    void Update()
    {
        MoveToDestination();
    }

    public void MoveToDestination()
    {
        distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.1f)
            return;

        direction = destination - transform.position;
        direction.Normalize();

        transform.position += direction * Time.deltaTime * speed;
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }
}
