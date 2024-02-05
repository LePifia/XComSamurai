using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField]  Image buttonIcon;
    [SerializeField] Sprite actionIcon;
    [SerializeField]  Button button;
    [SerializeField] string actionName;
    [SerializeField] string actionDescription;

    [SerializeField] GameObject selectedGameObject;

    private BaseAction baseAction;

    public void SetBaseAction(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        actionIcon = baseAction.ActionImage;
        buttonIcon.sprite = actionIcon;
        actionName = baseAction.ActionName;
        actionDescription = baseAction.ActionDescription;

        button.onClick.AddListener(() => {
            UnitActionSystem.instance.SetSelectedAction(baseAction);
        });

    }

    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = UnitActionSystem.instance.GetSelectedAction();
        selectedGameObject.SetActive(selectedBaseAction == baseAction);
    }

    public string GetActionName()
    {
        return actionName;
    }

    public string GetActionDescription()
    {
        return actionDescription;
    }

}
