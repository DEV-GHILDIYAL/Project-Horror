using UnityEngine;

public class Knife : MonoBehaviour
{
    public float interactDistance;
    public GameObject lastHit;
    public GameObject attackPoint;

    // public Chicken chicken;
    public int damage;
    public void Attack()
    {
        // Debug.Log("Attack");
        Ray ray = new Ray(attackPoint.transform.position, attackPoint.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("NormalChicken") || hit.collider.CompareTag("CursedChicken"))
            {
                lastHit = hit.transform.gameObject;
                lastHit.GetComponent<Chicken>().TakeDamage(damage);

                // chicken.TakeDamage(damage);
                
            }
        }
    }
}
