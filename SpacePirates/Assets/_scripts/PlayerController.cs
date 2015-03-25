using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0);
		transform.Translate(movement);
	}
}
