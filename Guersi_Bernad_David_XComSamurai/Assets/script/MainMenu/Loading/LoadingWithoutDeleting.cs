using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingWithoutDeleting : MonoBehaviour
{
    [Header("Loading WIthout Deleting")]
    [Space]
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image loadingImage;

    public void LoadScene(int sceneId)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Additive);

        while (!operation.isDone)
        {

            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            loadingImage.fillAmount = progressValue;

            yield return null;
        }
    }
}
