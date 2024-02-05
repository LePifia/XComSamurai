using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform shootPointTransform;
    [SerializeField] private Transform rifleTransform;
    [SerializeField] private Transform swordTransform;


    private float stateTimer;
    private float initialStateTimer = 1;
    private float randomNumber = 1;

    private void Awake()
    {
        if (TryGetComponent<MoveAction>(out MoveAction moveAction))
        {
            moveAction.OnStartMoving += MoveAction_OnStartMoving;
            moveAction.OnStopMoving += MoveAction_OnStopMoving;
            moveAction.OnChangedFloorsStarted += MoveAction_OnChangedFloorsStarted;
        }

        if (TryGetComponent<ShootAction>(out ShootAction shootAction))
        {
            shootAction.OnShoot += ShootAction_OnShoot;
        }

        if (TryGetComponent<SwordAction>(out SwordAction swordAction))
        {
            swordAction.OnSwordActionStarted += SwordAction_OnSwordActionStarted;
            swordAction.OnSwordActionCompleted += SwordAction_OnSwordActionCompleted;
        }

    }

    private void Start()
    {
        EquipRifle();
    }

    private void Update()
    {
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            animator.SetFloat("Random", UnityEngine.Random.Range(0, randomNumber));
            stateTimer = initialStateTimer;
        }

    }

    private void MoveAction_OnStartMoving(object sender, EventArgs e)
    {
        int randomNumber = UnityEngine.Random.Range(0,2);

        if(randomNumber == 0)
        {
            animator.SetBool("isWalking", true);
        }
        if (randomNumber == 1)
        {
            animator.SetBool("isRunning", true);
        }


    }

    private void MoveAction_OnChangedFloorsStarted(object sender, MoveAction.OnChangeFloorsStartedEventArgs e)
    {
        if (e.targetGridPosition.floor > e.unitGridPosition.floor)
        {
            // Jump
            animator.SetTrigger("JumpUp");
        }
        else
        {
            // Drop
            animator.SetTrigger("JumpDown");
        }
    }


    private void SwordAction_OnSwordActionCompleted(object sender, EventArgs e)
    {
        EquipRifle();
    }

    private void SwordAction_OnSwordActionStarted(object sender, EventArgs e)
    {
        EquipSword();
        int randomNumber = UnityEngine.Random.Range(0, 3);

        if (randomNumber == 0)
        {
            animator.SetTrigger("SwordSlash");
        }
        if (randomNumber == 1)
        {
            animator.SetTrigger("SwordSlash1");
        }
        if (randomNumber == 2)
        {
            animator.SetTrigger("SwordSlash2");
        }
        
    }


    private void MoveAction_OnStopMoving(object sender, EventArgs e)
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isRunning", false);
    }

    private void ShootAction_OnShoot(object sender, ShootAction.OnShootEventArgs e)
    {
        animator.SetTrigger("shoot");

        Transform bulletProjectileTransform = Instantiate(bulletPrefab, shootPointTransform.position, Quaternion.identity);

        bulletProjectile bulletProjectile = bulletProjectileTransform.GetComponent<bulletProjectile>();

        Vector3 targetUnitShootAtPosition = e.targetUnit.GetWorldPosition();

        float unitShoulderHeight = 1.7f;
        targetUnitShootAtPosition.y += unitShoulderHeight;


        bulletProjectile.Setup(targetUnitShootAtPosition);

    }

    private void EquipSword()
    {
        swordTransform.gameObject.SetActive(true);
        rifleTransform.gameObject.SetActive(false);
    }

    private void EquipRifle()
    {
        swordTransform.gameObject.SetActive(false);
        rifleTransform.gameObject.SetActive(true);
    }


}
