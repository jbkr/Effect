using UnityEngine;
using UnityEngine.UIElements;

public class Agent : MonoBehaviour
{
    void Start()
    {

    }

    private bool isMove;
    private Vector3 destination;
    private float distance;
    private Vector3 direction;
    private float speed = 5.0f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isMove = true;
        }

        if (isMove)
        {
            transform.position += destination * Time.deltaTime * 5.0f;
            distance = Vector3.Distance(transform.position, destination);
            Debug.Log(distance);
            if ((distance >= 0 && distance <= 0.1f))
            {
                isMove = false;
            }
        }
    }

    public bool MoveToDestination(Vector3 destination)
    {
        direction = destination - transform.position;
        direction = direction.normalized;

        transform.position += direction * Time.deltaTime * speed;
        distance = Vector3.Distance(transform.position, destination);
        Debug.Log(distance);
        if ((distance >= 0 && distance <= 0.1f))
        {
            return false;
        }

        return true;
    }

    //public void SetIndex(int index)
    //{
    //    this.index = index;
    //}
}
