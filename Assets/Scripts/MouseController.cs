using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Agent agent;
    private Ray ray;
    private RaycastHit hitInfo;

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
        {
            //int layer = LayerMask.NameToLayer("Agent");
            //bool ishit = Physics.Raycast(ray, out hitInfo, float.MaxValue, 1 << 6);
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, 1 << 6))
            {
                agent = hitInfo.collider.gameObject.GetComponent<Agent>();
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, 1 << 7))
            {
                if (agent == null)
                {
                    return;
                }
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}
