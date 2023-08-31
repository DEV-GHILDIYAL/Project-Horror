using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    public NavMeshAgent agent;

    public GameManager gameManager;

    


    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
        }
        

        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            if(gameObject.tag == "NormalChicken")
            {
                gameManager.numberOfNormalChickenText.text = gameManager.noOfNormalChicken.ToString();
                gameManager.noOfNormalChicken += 1;
            }
            else if(gameObject.tag == "CursedChicken")
            {
                gameManager.numberOfCursedChickenText.text = gameManager.noOfCursedChicken.ToString();
                gameManager.noOfCursedChicken += 1;
            }
            Invoke(nameof(DestroyEnemy), 0.1f);
        }

    }
}
