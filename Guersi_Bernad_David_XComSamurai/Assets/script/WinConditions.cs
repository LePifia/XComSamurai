using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinConditions : MonoBehaviour
{
    [Header("DefeatAllEnemies")]
    [Space]
    [SerializeField] bool defeatAllEnemiesPhase = false;
    bool defeatAllEnemies = false;
    [SerializeField] GameObject youWinObject;
    [Space]

    [Header("TeamDefeated")]
    [Space]
    bool teamDefeated = false;
    [SerializeField] GameObject youLooseItem;
    [Space]

    [Header("DefeatEnemyBoss")]
    [Space]
    [SerializeField] bool defeatBossPhase = false;
    bool enemyLeaderDefeated = false;
    [SerializeField] GameObject enemyLeader;

    [SerializeField] UnityEvent onLevelVictory;

    void Update()
    {

        //Victory Conditions

        if (defeatAllEnemiesPhase == true)
        {
            if (Time.frameCount > 15)
            {
                CheckIfEnemiesAreDead();

                if (defeatAllEnemies == true)
                {
                    youWinObject.SetActive(true);

                    if(onLevelVictory != null)
                    {
                        onLevelVictory.Invoke();
                    }
                }
            }

        }

        if (defeatBossPhase == true)
        {
            if (Time.frameCount > 15)
            {
                CheckIfEnemyLeaderIsDefeated();

                if (enemyLeaderDefeated == true)
                {  
                    youWinObject.SetActive(true);

                    if (onLevelVictory != null)
                    {
                        onLevelVictory.Invoke();
                    }
                }
            }
        }



        //DefeatConditions


        if (Time.frameCount > 15)
        {
            CheckIfYourTeamIsDead();
            if (teamDefeated == true)
            {
                youLooseItem.SetActive(true);
            }
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

    private void CheckIfEnemyLeaderIsDefeated()
    {
        if (enemyLeader == null)
        {
            enemyLeaderDefeated = true;
        }
    }
}
