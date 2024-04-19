using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : BaseAction
{
    public event EventHandler OnHealAction;

    [Header("HealActionData")]
    [Space]

    [SerializeField] Sprite healIcon;
    [SerializeField] string actionName;
    [SerializeField] string actionDescription;

    [Space]
    [SerializeField] int actionCost = 1;

    private float timer = 0;


    public override Sprite ActionImage => healIcon;

    public override string ActionName => actionName;

    public override string ActionDescription => actionDescription;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            ActionComplete();
            timer = 0;
        }
            
        
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 0,
        };
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        GridPosition unitGridPosition = unit.GetGridPosition();

        return new List<GridPosition>
        {
            unitGridPosition
        };
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        ActionStart(onActionComplete);
        timer = 2;
        Unit targetUnit = LevelGrid.instance.GetUnitOnGridPosition(gridPosition);
        OnHealAction?.Invoke(this, EventArgs.Empty);
        targetUnit.HealUp();
    }

    public override int GetActionPointsCost()
    {
        return actionCost;
    }
}
