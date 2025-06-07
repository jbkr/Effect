using UnityEngine;

public class MouseControllerTest : MonoBehaviour
{
    private Ray ray;
    private GameObject agent;
    private bool isAgentHit;
    private bool isBottomHit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            isAgentHit = Physics.Raycast(ray, out hitInfo, float.MaxValue, LayerMask.GetMask("Agent"));
            if (isAgentHit)
            {
                Debug.Log("Agent Selected");
                agent = hitInfo.collider.gameObject;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            isBottomHit = Physics.Raycast(ray, out hitInfo, float.MaxValue, LayerMask.GetMask("Bottom"));
            if (isAgentHit && isBottomHit)
            {
                Debug.Log("Move");
                agent.GetComponent<AgentTest>().SetDestination(hitInfo.point);
            }
        }
    }
}
