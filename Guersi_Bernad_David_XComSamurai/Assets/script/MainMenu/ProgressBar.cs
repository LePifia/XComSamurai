using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("GameObject/UI/LinearProgressBar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("ProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

#endif

    [Header("Progress Bar")]
    [Space]
    [SerializeField] int minimun;
    [SerializeField] int maxNum;
    [SerializeField] int currentNum;
    [SerializeField] Image mask;
    [SerializeField] Image fill;
    [SerializeField] Color color;
    [SerializeField] bool eventProgresBar;




    private void Update()
    {
        if (Time.frameCount  % 30 == 0)
        {
            GetCurrentFill();
        }
    }

    void GetCurrentFill()
    {
        float currentOffset = currentNum - minimun;
        float maxOffset = maxNum - minimun;
        float fillAmount = currentOffset / maxOffset;
       mask.fillAmount = fillAmount;

        fill.color = color;
    }

    public void SetCurrentNum()
    {
        if (eventProgresBar)
        {
            currentNum -= 1;
        }
        
    }

    

}
