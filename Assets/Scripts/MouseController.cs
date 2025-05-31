using UnityEngine;

public class MouseController : MonoBehaviour
{


    private bool isPlayerSelected;
    private Agent currentAgent;
    private bool isMove;
    private Vector3 destination;

    void Start()
    {

    }
    void Update()

    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    //Input.GetTouch()
        //    //Ray hit;


        //}

        if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //int layer = LayerMask.NameToLayer("Agent");

            RaycastHit hitInfo;

            //bool ishit = Physics.Raycast(ray, out hitInfo, float.MaxValue, 1 << 6);
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, 1 << 6))
            {
                Debug.Log("is Hit Plane : " + hitInfo.point);

                currentAgent = hitInfo.collider.gameObject.GetComponent<Agent>();

                isPlayerSelected = true;
            }

            RaycastHit planeHit;

            if (isPlayerSelected && Physics.Raycast(ray, out planeHit, float.MaxValue, 1 << 7))
            {
                isMove = true;
                Debug.Log(planeHit.point);
                destination = planeHit.point;
            }

        }

        if (isMove)
        {
            isMove = currentAgent.MoveToDestination(destination);
        }
    }
}
