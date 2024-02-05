using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : BaseAction
{
    [SerializeField] Sprite healIcon;
    [SerializeField] string actionName;
    [SerializeField] string actionDescription;

    public override Sprite ActionImage => healIcon;

    public override string ActionName => actionName;

    public override string ActionDescription => actionDescription;

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        throw new System.NotImplementedException();
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        throw new NotImplementedException();
    }
}
