using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystemUI : MonoBehaviour
{
    [SerializeField] Button endTurnButton;
    [SerializeField] TextMeshProUGUI turnNumberText;

    [SerializeField] GameObject enemyVisualGameObject;

    private void Start()
    {
        endTurnButton.onClick.AddListener(() =>    
        {
            TurnSystem.instance.NextTurn();
        });

        TurnSystem.instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        UpdateTurnText();
        UpdateEnemyTurnVisual();
        UpdateEndTurnButtonVisibility();
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e )
    {
        UpdateTurnText();
        UpdateEnemyTurnVisual();
        UpdateEndTurnButtonVisibility();
    }
    private void UpdateTurnText()
    {

        turnNumberText.text = "Turn: " + TurnSystem.instance.GetTurnNumber();
    }

    private void UpdateEnemyTurnVisual()
    {
        enemyVisualGameObject.SetActive(!TurnSystem.instance.IsPlayerTurn());
    }

    private void UpdateEndTurnButtonVisibility()
    {
        endTurnButton.gameObject.SetActive(TurnSystem.instance.IsPlayerTurn());
    }
}
