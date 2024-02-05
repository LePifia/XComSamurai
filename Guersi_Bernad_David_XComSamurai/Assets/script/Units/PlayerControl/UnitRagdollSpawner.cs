using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRagdollSpawner : MonoBehaviour
{
    [SerializeField] Transform originalRagdollRootBone;
    [SerializeField] Transform ragdollPrefab;

    private Health healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<Health>();

        healthSystem.OnDead += Health_OnDead;
    }

    private void Health_OnDead(object sender, EventArgs e)
    {
        Transform ragdollTransform = Instantiate(ragdollPrefab, transform.position, transform.rotation);
        UnitRagdoll unitRagdoll = ragdollTransform.GetComponent<UnitRagdoll>();

        unitRagdoll.Setup(originalRagdollRootBone);
    }
}
