using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    AsyncOperation loadingOperation;

    [SerializeField]
    private Slider loadingSlider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsync());

    }

    private void Update()
    {
       
        
    }
    IEnumerator LoadAsync()
    {

        loadingOperation = SceneManager.LoadSceneAsync(LoadingData.sceneToLoad);
        while (!loadingOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadingOperation.progress / .9f);
            Debug.Log(loadingOperation.progress);
            loadingSlider.value = progress;

            yield return null;  
        }
    }

    // Update is called once per frame

}
