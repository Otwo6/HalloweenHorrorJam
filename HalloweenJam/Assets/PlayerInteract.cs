using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public OpenMinigameScript interactable;
    public GameObject mainCam;

    private void Update()
    {
        if(Input.GetButtonDown("Interact"))
        {
            if(interactable != null)
            {
                print(interactable);
                mainCam.SetActive(false);
                interactable.Open();
            }
        }
    }
}
