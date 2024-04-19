using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuFade : MonoBehaviour
{
    [Header("Menu Fade")]
    [Space]
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject menu;

    bool isFaded = true;

    private void Update()
    {
        if (InputManager.Instance.IsMButtonDownThisFrame())
        {
            Fader();
            
        }
    }

    public void Fader()
    {
        isFaded = !isFaded;

        if (isFaded)
        {
            canvasGroup.DOFade(1, 1);
            StartCoroutine(CoroutineMenu());
            
            
        }
        else
        {
            canvasGroup.DOFade(0, 1);
            StartCoroutine(CoroutineMenu());
        }
    }

    IEnumerator CoroutineMenu()
    {
        yield return new WaitForSeconds (2f);
        menu.SetActive(isFaded);

    }

}
