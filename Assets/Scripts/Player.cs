using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    //[SerializeField]
    //private AudioSource audioSource;

    public float speed = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    void Start()
    {
        animator.Play("IDLE");
    }

    bool isAttack = false;

    //[SerializeField]
    //private CharacterController characterController;
    private Transform playerTransform;

    public Transform GetTransform()
    {
        return playerTransform;
    }

    bool isJump = false;

    void Update()
    {
        playerTransform = transform;
        //Debug.Log("Player Position : " + transform.position);

        bool isMoving = false;

        if (Input.GetKeyDown(KeyCode.W) && isAttack == false)
        {
            //characterController.Move(Vector3.forward * Time.deltaTime * speed);
            //transform.position += Vector3.forward * Time.deltaTime * speed;
            //transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            isMoving = true;
            isJump = true;
            animator.Play("JUMP");
        }
        if (isJump)
        {
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (animatorStateInfo.IsName("JUMP") && animatorStateInfo.normalizedTime >= 1f)
            {
                if (animatorStateInfo.IsName("LAND") && animatorStateInfo.normalizedTime >= 1f)
                {
                    isJump = false;
                }
            }

        }
        if (Input.GetKey(KeyCode.S) && isAttack == false)
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
            //characterController.Move(Vector3.back * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A) && isAttack == false)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            //characterController.Move(Vector3.left * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            isMoving = true;

            if (!isJump)
                animator.Play("BACKWARD");
        }
        if (Input.GetKey(KeyCode.D) && isAttack == false)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            //characterController.Move(Vector3.right * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            isMoving = true;
            animator.Play("FORWARD");
        }

        if (Input.GetMouseButtonDown(0) && !isAttack)
        {
            isAttack = true;
            animator.Play("ATTACK");
        }

        if (isAttack)
        {
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 1f)
            {
                isAttack = false;
            }
        }

        //if (isMoving)
        //{
        //    animator.Play("RUN");
        //}
        if (!isMoving && !isAttack && !isJump)
        {
            animator.Play("IDLE");
        }

    }
}