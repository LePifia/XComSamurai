using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private static MouseWorld instance;
    [SerializeField] LayerMask mousePlaneMask;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        transform.position = MouseWorld.GetPosition();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseScreenPosition());
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.mousePlaneMask);
        return raycastHit.point;
    }

    public static Vector3 GetPositionOnlyHitVisible()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseScreenPosition());
        RaycastHit[] raycastHitArray =  Physics.RaycastAll(ray, float.MaxValue, instance.mousePlaneMask);

        System.Array.Sort(raycastHitArray, (RaycastHit raycastHitA , RaycastHit raycastHitB) =>
            {

                return Mathf.RoundToInt( raycastHitA.distance - raycastHitB.distance);

            });

        foreach (RaycastHit raycastHit in raycastHitArray)
        {
            if (raycastHit.transform.TryGetComponent(out Renderer renderer))
            {
                if (renderer.enabled)
                {
                    return raycastHit.point;
                }
            }
        }

        return Vector3.zero;
    }

}
