using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    float pollingTime = 1f;
    float time;
    int frameCount;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime) {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
