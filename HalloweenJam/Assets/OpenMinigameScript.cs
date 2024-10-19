using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMinigameScript : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject miniGame;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("Player in");
            PlayerInteract player = col.gameObject.GetComponent<PlayerInteract>();
            player.interactable = this;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("Player in");
            PlayerInteract player = col.gameObject.GetComponent<PlayerInteract>();
            player.interactable = null;
        }
    }

    public void Open()
    {
        cam.SetActive(true);
    }
}
