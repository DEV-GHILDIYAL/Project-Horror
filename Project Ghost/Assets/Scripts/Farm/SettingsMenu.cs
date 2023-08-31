using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI fps;

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void ShowFPS(bool isShowFPS)
    {
        fps.enabled = isShowFPS;
    }
}
