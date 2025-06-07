using UnityEngine;

public enum PlayerState { Idle, Running, Jumping, Attacking }

public class PlayerTest : MonoBehaviour
{
    private Animator animator;
    private PlayerState currentState = PlayerState.Idle;
    private Transform playerTransform;
    public float speed = 1.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = transform;
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        bool isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
            SetState(PlayerState.Jumping);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
            SetState(PlayerState.Running);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
            SetState(PlayerState.Running);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
            SetState(PlayerState.Running);
        }
        if (Input.GetMouseButtonDown(0))
        {
            SetState(PlayerState.Attacking);
        }

        if (!isMoving && currentState != PlayerState.Attacking && currentState != PlayerState.Jumping)
        {
            SetState(PlayerState.Idle);
        }
    }

    void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * speed;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void SetState(PlayerState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
            animator.SetTrigger(newState.ToString());
        }
    }
}