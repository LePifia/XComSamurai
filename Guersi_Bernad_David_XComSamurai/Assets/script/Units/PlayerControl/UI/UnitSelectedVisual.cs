using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] Unit unit;

    private MeshRenderer meshRenderer;

    

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.instance.OnSelectedUnitChange += UnitActionSystem_OnSelectedUnitChange;

        UpdateVisual();
    }

    private void UnitActionSystem_OnSelectedUnitChange(object sender, EventArgs empty)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (UnitActionSystem.instance.GetSelectedUnit() == unit)
        {
            meshRenderer.enabled = true;
            
        }
        else
        {
            meshRenderer.enabled = false;
           
        }
    }

    private void OnDestroy()
    {
        UnitActionSystem.instance.OnSelectedUnitChange -= UnitActionSystem_OnSelectedUnitChange;
    }
}
