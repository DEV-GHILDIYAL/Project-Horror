using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour {

    [Header("Loading Screen")]
    public GameObject loadingScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI TipsText;
    public string[] tip;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        byte RandomNum =(byte) Random.Range(1, 10);
        byte randomTipNum = (byte)Random.Range(0, tip.Length);

        loadingScreen.SetActive(true);
        

        while(!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            TipsText.text = tip[randomTipNum];

            slider.value = progress;
            progressText.text = Mathf.RoundToInt(progress) * 100f + "%";
            Debug.Log(progressText.text);

            // Debug.Load(operation.progress);

            yield return null;
        }
        
    }


}