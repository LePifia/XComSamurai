using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject popUpParent;
    [SerializeField] GameObject[] popUps;

    [SerializeField] int popUpIndex = 0;
    [SerializeField] MoveAction moveAction;
    [SerializeField] ShootAction shootAction;
    [SerializeField] GrenadeAction grenadeAction;
    [SerializeField] SwordAction swordAction;



    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChange += Instance_OnSelectedUnitChange;
        moveAction.OnStartMoving += MoveAction_OnStartMoving;
        shootAction.OnShoot += ShootAction_OnShoot;
        grenadeAction.OnGrenadeLaunch += GrenadeAction_OnGrenadeLaunch;
        swordAction.OnSwordActionStarted += SwordAction_OnSwordActionStarted;
        TurnSystem.Instance.OnTurnChanged += Instance_OnTurnChanged;

        popUpIndex = 0;
        Debug.Log("IndexTutorial changed to " + popUpIndex);
        popUps[popUpIndex].SetActive(true);
    }

    

    private void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
   
            }
        }

    }

    private void Instance_OnSelectedUnitChange(object sender, System.EventArgs e)
    {
        if (popUpIndex == 0)
        {
            popUpIndex++;
            Debug.Log("IndexTutorial changed to " + popUpIndex);

        }

        

    }

    private void MoveAction_OnStartMoving(object sender, System.EventArgs e)
    {
        if (popUpIndex == 1)
        {
            popUpIndex++;
            Debug.Log("IndexTutorial changed to " + popUpIndex);

        }
    }

    private void ShootAction_OnShoot(object sender, ShootAction.OnShootEventArgs e)
    {
        if (popUpIndex == 2)
        {
            popUpIndex++;
            Debug.Log("IndexTutorial changed to " + popUpIndex);

        }
    }

    private void GrenadeAction_OnGrenadeLaunch(object sender, System.EventArgs e)
    {
        if (popUpIndex == 3)
        {
            popUpIndex++;
            Debug.Log("IndexTutorial changed to " + popUpIndex);

        }
    }

    private void SwordAction_OnSwordActionStarted(object sender, System.EventArgs e)
    {
        if (popUpIndex == 4)
        {
            popUpIndex++;
            Debug.Log("IndexTutorial changed to " + popUpIndex);

        }

        
    }

    private void Instance_OnTurnChanged(object sender, System.EventArgs e)
    {

        if (popUpIndex == 5)
        {
            popUpIndex++;
            Debug.Log("IndexTutorial changed to " + popUpIndex);

        }
        if (popUpIndex == 6)
        {
            Debug.Log("IndexTutorial changed to " + popUpIndex);
            Invoke(nameof(DisablePopUpParent), 10);

        }
    }


    private void DisablePopUpParent()
    {
        popUpParent.SetActive(false);
    }

}
