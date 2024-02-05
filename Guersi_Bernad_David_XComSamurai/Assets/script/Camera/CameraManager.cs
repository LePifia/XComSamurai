using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] private GameObject actionCameraGameObject;

    Vector3 cameraCharacterHeight;
    Vector3 cameraCharacterWidht;
    Vector3 shootDir;
    float shoulderOffsetAmount;
    Vector3 shoulderOffset;
    Vector3 actionCameraPosition;

    private void Start()
    {
        BaseAction.OnAnyActionStarted += BaseAction_OnAnyActionStarted;
        BaseAction.OnAnyActionCompleted += BaseAction_OnAnyActionCompleted;

        HideActionCamera();
    }

    private void ShowActionCamera()
    {
        actionCameraGameObject.SetActive(true);
    }

    private void HideActionCamera()
    {
        actionCameraGameObject.SetActive(false);
    }

    private void BaseAction_OnAnyActionStarted(object sender, EventArgs e)
    {
        switch (sender)
        {
            case ShootAction shootAction:
                Unit shooterUnit = shootAction.GetUnit();
                Unit targetUnit = shootAction.GetTargetUnit();

                cameraCharacterHeight = Vector3.up * 1.45f;


                shootDir = (targetUnit.GetWorldPosition() - shooterUnit.GetWorldPosition()).normalized;

                shoulderOffsetAmount = 0.5f;
                shoulderOffset = Quaternion.Euler(0, 90, 0) * shootDir * shoulderOffsetAmount;

                actionCameraPosition =
                    shooterUnit.GetWorldPosition() +
                    cameraCharacterHeight +
                    shoulderOffset +
                    (shootDir * -1);

                actionCameraGameObject.transform.position = actionCameraPosition;
                actionCameraGameObject.transform.LookAt(targetUnit.GetWorldPosition() + cameraCharacterHeight);

                ShowActionCamera();
                break;

            case SwordAction swordAction:
                Unit swordUnit = swordAction.GetUnit();
                Unit targetUnitSword = swordAction.GetTargetUnitSword();

                cameraCharacterHeight = Vector3.up * 1.45f;
                cameraCharacterWidht = Vector3.left * 5f;

                shootDir = (targetUnitSword.GetWorldPosition() - swordUnit.GetWorldPosition()).normalized;

                shoulderOffsetAmount = 0.5f;
                shoulderOffset = Quaternion.Euler(0, 90, 90) * shootDir * shoulderOffsetAmount;

                actionCameraPosition =
                    swordUnit.GetWorldPosition() +
                    cameraCharacterHeight +
                    cameraCharacterWidht +
                    shoulderOffset +
                    (shootDir * -1);

                actionCameraGameObject.transform.position = actionCameraPosition;
                actionCameraGameObject.transform.LookAt(targetUnitSword.GetWorldPosition() + cameraCharacterHeight);

                ShowActionCamera();
                break;
        }
    }

    private void BaseAction_OnAnyActionCompleted(object sender, EventArgs e)
    {
        switch (sender)
        {
            case ShootAction shootAction:
                HideActionCamera();
                break;
            case SwordAction swordAction:
                HideActionCamera();
                break;
        }
    }
}

