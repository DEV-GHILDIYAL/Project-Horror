using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject cam;


    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
