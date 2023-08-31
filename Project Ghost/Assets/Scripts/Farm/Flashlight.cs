using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashLight;
    public AudioSource audioSource;

    public AudioClip soundFlashlightOn;
    public AudioClip soundFlashlightOff;

    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        flashLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FLashlightOnAndOff()
    {
        if(!isActive)
        {
            flashLight.enabled = true;
            isActive = true;

            audioSource.PlayOneShot(soundFlashlightOn);
        }
        else if(isActive) {
            flashLight.enabled=false;
            isActive = false;

            audioSource.PlayOneShot(soundFlashlightOff);
        }
    }
}
