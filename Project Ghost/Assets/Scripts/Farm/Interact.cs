using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public byte interactDistance = 3;
    public LayerMask interactLayer;

    byte NoOfKniefStore = 0;
    byte NoOfFlashlightStore = 0;

    public Image interactIcon;

    public bool isInteracting;

    public bool nowCanInteract;
    public GameObject interactObj;
    public GameObject interactButton;

    public GameObject knifeButton;
    public GameObject flashlightButton;
    public FirstPersonController fps;

    private void Start()
    {
        fps.armKnief.SetActive(false);
        nowCanInteract = false;
        isInteracting = false;

        knifeButton.SetActive(false);
        flashlightButton.SetActive(false);

        if(interactIcon != null)
        {
            interactIcon.enabled = false;
        }
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            if(isInteracting == false)
            {
                if (interactIcon != null)
                {
                    interactIcon.enabled = true;
                }

                nowCanInteract = true;
                interactButton.SetActive(true);

                interactObj = hit.collider.gameObject;
            }
        }
        else
        {
            nowCanInteract = false;
            interactIcon.enabled = false;
            interactButton.SetActive(false);
        }
    }

    public void DoInteract()
    {
        if(nowCanInteract)
        {
            if(interactObj.tag == "Knief")
            {
                if (NoOfKniefStore < 1)
                {
                    Debug.Log("Knief");
                    knifeButton.SetActive(true);
                    Destroy(interactObj);
                    NoOfKniefStore += 1;
                    fps.armKnief.SetActive(true);
                }
            }
            if (interactObj.tag == "Flashlight")
            {
                if(NoOfFlashlightStore < 1)
                {
                    Debug.Log("FlashLight");
                    flashlightButton.SetActive(true);
                    Destroy(interactObj);
                    NoOfFlashlightStore += 1;
                }
            }
        }
    }
}
