using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceBoxAction : BaseAction
{

    [Header("PlaceBoxActionData")]
    [Space]

    [SerializeField] Sprite boxIcon;
    private int maxBoxDistance = 1;
    [SerializeField] GameObject box;
    [SerializeField] bool isBoss = false;
    private float timer = 0;
    [SerializeField] string actionName;
    [SerializeField] string actionDescription;
    [SerializeField] int actionCost = 1;


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


    public override Sprite ActionImage => boxIcon;

    public override string ActionName => actionName;

    public override string ActionDescription => actionDescription;

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        if (isBoss == false)
        {
            return new EnemyAIAction
            {
                gridPosition = gridPosition,
                actionValue = 0,
            };
        }

        else
        {
            return new EnemyAIAction
            {
                gridPosition = gridPosition,
                actionValue = 300,
            };
        }
        
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for (int x = -maxBoxDistance; x <= maxBoxDistance; x++)
        {
            for (int z = -maxBoxDistance; z <= maxBoxDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z, 0);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

               

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        if (box != null)
        {
            Vector3 position = LevelGrid.instance.GetWorldPosition(gridPosition);
            Instantiate(box, position, Quaternion.identity);
            timer = 2;

            ActionStart(onActionComplete);
        }
        else
        {
            Debug.LogError("Box not assigned");
        }
    }

    public int GetBoxDistance()
    {
        return maxBoxDistance;
    }

    public override int GetActionPointsCost()
    {
        return actionCost;
    }
}
