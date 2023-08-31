using UnityEngine;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [Header("Information")]
    public TextMeshProUGUI version;

    [Header("Panels")]
    [SerializeField] GameObject MainGamePanel;
    [SerializeField] GameObject HostPanel;
    [SerializeField] GameObject JoinPanel;
    [SerializeField] GameObject SinglePlayerPanel;
    [SerializeField] GameObject OptionPanel;
    [SerializeField] GameObject AboutPanel;
    [SerializeField] GameObject QuitGamePanel;
    // Start is called before the first frame update
    void Start()
    {
        version.text = "version : " + Application.version;
        MainGamePanel.SetActive(true);
        QuitGamePanel.SetActive(false);
        HostPanel.SetActive(false);
        JoinPanel.SetActive(false);
        OptionPanel.SetActive(false);
        AboutPanel.SetActive(false);
        SinglePlayerPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
