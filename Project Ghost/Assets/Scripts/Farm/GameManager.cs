using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public FirstPersonController pm;
    public GameObject gameOverUI;

    public TextMeshProUGUI numberOfNormalChickenText;
    public TextMeshProUGUI numberOfCursedChickenText;

    public byte noOfNormalChicken = 0;
    public byte noOfCursedChicken = 0;

    public EnemyAi enemyAi;

    GameObject winAnim;

    private void Start()
    {
        pm.enabled = true;
        gameOverUI.SetActive(false);
    }
    private void LateUpdate()
    {
        numberOfCursedChickenText.text = noOfCursedChicken.ToString();
        numberOfNormalChickenText.text = noOfNormalChicken.ToString();
    }
    public void EndGame()
    {
        if(enemyAi.win == true)
        {
            winAnim.SetActive(true);
        }
        pm.enabled = false;
        gameOverUI.SetActive(true);
        Destroy(GameObject.FindWithTag("CursedChicken"));
        Destroy(GameObject.FindWithTag("NormalChicken"));
        Invoke(nameof(DestroyEnvironment), 5f);
        Debug.Log("End Game...");
    }

    void DestroyEnvironment()
    {
        Destroy(GameObject.FindWithTag("Environment"));
    }
}
