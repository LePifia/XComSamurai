using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorVisibility : MonoBehaviour
{
    [SerializeField] bool dynamicFloorPosition;
    [SerializeField] List<Renderer> ignoreRendererList;

    private int frameInterval = 15;

    private Renderer[] rendererArray;
    private int floor;
    [SerializeField] float floorHeightOffset = 0.25f;

    private void Awake()
    {
        rendererArray =  GetComponentsInChildren<Renderer>(true);
    }

    private void Start()
    {
       floor =  LevelGrid.instance.GetFloor(transform.position);

        if (floor == 0 && !dynamicFloorPosition)
        {
            Destroy(this);
        }
        
    }

    private void Update()
    {

        if (dynamicFloorPosition && Time.frameCount % frameInterval == 0)
        {
            floor = LevelGrid.instance.GetFloor(transform.position);
        }

        float cameraHeight = CameraZoom.instance.GetCameraHeight();
        

        bool showObject = cameraHeight > LevelGrid.Floor_Height * floor + floorHeightOffset;

        if (showObject || floor == 0)
        {
            Show();
        }

        else
        {
            Hide();
        }
    }

    private void Show()
    {
        foreach (Renderer renderer in rendererArray)
        {
            if (ignoreRendererList.Contains(renderer)) continue;
            renderer.enabled = true;
        }
    }

    private void Hide()
    {
        foreach (Renderer renderer in rendererArray)
        {
            if (ignoreRendererList.Contains(renderer)) continue;
            renderer.enabled = false;
        }
    }
}
