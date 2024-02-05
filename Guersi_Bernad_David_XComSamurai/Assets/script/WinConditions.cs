using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    [Header("DefeatAllEnemies")]
    [SerializeField] bool defeatAllEnemies = false;
    [SerializeField] GameObject youWinObject;

    [Header("DefeatAllEnemies")]
    [SerializeField] bool teamDefeated = false;

    void Update()
    {
        CheckIfEnemiesAreDead();

        if (defeatAllEnemies == true)
        {
            youWinObject.SetActive(true);
        }
    }

    private void CheckIfEnemiesAreDead()
    {
         List<Unit> enemiesRemaining = UnitManager.Instance.GetEnemyUnitList();

        if (enemiesRemaining.Count == 0)
        {
            defeatAllEnemies = true;
        }
    }

    private void CheckIfYourTeamIsDead()
    {
        List<Unit> teamRemaining = UnitManager.Instance.GetFriendlyUnitList();

        if (teamRemaining.Count == 0)
        {
            teamDefeated = true;
        }
    }
}
