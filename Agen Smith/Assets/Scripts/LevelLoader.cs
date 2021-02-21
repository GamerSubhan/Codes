using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadScreen;
    public Slider slider;
    public Text progressText;
    public void LoadLevel (int sceneIndex){
        
        LoadAsynchronously(sceneIndex);
    }

    IEnumerator LoadAsynchronously (int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadScreen.SetActive(true);

        while (!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(operation.progress);

            slider.value = progress;
            progressText.text = progress + 100f + "%";

            yield return null;
        }
    }
    
}
