using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public int SceneNum;

    public void GoNextScene()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
