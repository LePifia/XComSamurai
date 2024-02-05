using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] string content;
    [SerializeField] string header;


    ActionButtonUI buttonUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonUI = eventData.pointerCurrentRaycast.gameObject.GetComponent<ActionButtonUI>();

        header = buttonUI.GetActionName();
        content = buttonUI.GetActionDescription();

        TooltipSystem.Show(content, header);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }

}
