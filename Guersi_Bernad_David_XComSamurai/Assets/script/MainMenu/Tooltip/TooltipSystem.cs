using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem Instance;
    [Header("Tooltip System")]
    [Space]

    [SerializeField] Tooltip tooltip;

    private void Awake()
    {
        Instance = this;
    }

    public static void Show(string content, string header = "")
    {
        Instance.tooltip.SetText(content, header);
        Instance.tooltip.gameObject.SetActive(true); 
    }

    public static void Hide()
    {
        Instance.tooltip.gameObject.SetActive(false);
    }
}
