using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
	[SerializeField] private float offsetX;
	[SerializeField] private float offsetY;
	[SerializeField] private bool moveY;
	[SerializeField] private float multiplier = 50f;

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mouseScreenPosition = new Vector3(multiplier * Input.mousePosition.x, multiplier * Input.mousePosition.y, cam.nearClipPlane);
        
        // Convert to world coordinates
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mouseScreenPosition);
        
        // Update the position of the GameObject
		if(moveY)
		{
			transform.position = new Vector3(mouseWorldPosition.x + offsetX, mouseWorldPosition.y + offsetY, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(mouseWorldPosition.x + offsetX, transform.position.y, transform.position.z);
		}
    }
}
