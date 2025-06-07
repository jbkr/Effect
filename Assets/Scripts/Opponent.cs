using UnityEngine;

public class Opponent : MonoBehaviour
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

    [SerializeField]
    private Player player;

    void Start()
    {
        animator.Play("IDLE");
        isMoving = true;
    }

    private bool isAttack = false;

    private bool isClose;
    private float distance;
    private float chasingDistance = 3.5f;
    private float attackDistance = 2.0f;
    private bool isChasing;
    private bool isMoving;
    private bool isFinished;
    private Transform playerTransform;

    void Update()
    {
        playerTransform = player.transform;
        playerTransform = GameManager.Instance.GetPlayerTransform();
        distance = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log("Player Position : " + playerTransform.position);

        if (distance <= chasingDistance && isMoving)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction = direction.normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        Debug.Log("isAttack : " + isAttack);

        if (distance <= attackDistance && !isAttack && !isFinished)
        {
            isMoving = false;
            isChasing = false;

            isAttack = true;
            animator.Play("ATTACK");
        }


        if (isAttack)
        {
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

            if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 1f)
            {
                isAttack = false;
                isFinished = true;
            }
        }

        if (isChasing)
        {
            animator.Play("RUN");
        }

        if (!isChasing && !isAttack && isFinished)
        {
            animator.Play("IDLE");
        }



        //if (isAttack)
        //{
        //    AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //    if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 1f)
        //    {
        //        //isAttack = false;
        //    }
        //}
        //bool isMoving = false;

        //if (Input.GetKey(KeyCode.W) && isAttack == false)
        //{
        //    //characterController.Move(Vector3.forward * Time.deltaTime * speed);
        //    transform.position += Vector3.forward * Time.deltaTime * speed;
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        //    isMoving = true;
        //}
        //if (Input.GetKey(KeyCode.S) && isAttack == false)
        //{
        //    transform.position += Vector3.back * Time.deltaTime * speed;
        //    //characterController.Move(Vector3.back * Time.deltaTime * speed);
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        //    isMoving = true;
        //}
        //if (Input.GetKey(KeyCode.A) && isAttack == false)
        //{
        //    transform.position += Vector3.left * Time.deltaTime * speed;
        //    //characterController.Move(Vector3.left * Time.deltaTime * speed);
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
        //    isMoving = true;
        //}
        //if (Input.GetKey(KeyCode.D) && isAttack == false)
        //{
        //    transform.position += Vector3.right * Time.deltaTime * speed;
        //    //characterController.Move(Vector3.right * Time.deltaTime * speed);
        //    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        //    isMoving = true;
        //}

        //if (Input.GetMouseButtonDown(0) && !isAttack)
        //{
        //    isAttack = true;
        //    animator.Play("ATTACK");
        //}

        //if (isAttack)
        //{
        //    AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        //    if (animatorStateInfo.IsName("ATTACK") && animatorStateInfo.normalizedTime >= 1f)
        //    {
        //        isAttack = false;
        //    }
        //}



        //if (isMoving)
        //{
        //    animator.Play("RUN");
        //}
        //if (isMoving == false && isAttack == false)
        //{
        //    animator.Play("IDLE");
        //}

    }
}