using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameManager gameManager;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log(hit.gameObject.name);
        if(hit.gameObject.tag == "Enemy")
        {
            Debug.Log("Game Over...");
            gameManager.EndGame();
        }
    }
}
