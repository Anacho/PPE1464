using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	// fly speed
	public float speed = 10.0f;
	
	// destination set by Tower when creating the bullet
	Transform destination;    
	
	// Update is called once per frame
	void Update () {
		// destroy bullet if destination does not exist anymore
		if (destination == null) {
			Destroy(gameObject);
			return;
		}
		if (!Game.done) {

			// fly towards the destination
			float stepSize = Time.deltaTime * speed;
			transform.position = Vector3.MoveTowards (transform.position, destination.position, stepSize);

			// reached?
			if (transform.position.Equals (destination.position)) {
					// decrease unite health
					Unite t = destination.GetComponent<Unite> ();
					t.health = t.health - 1;

					// call Unite's onDead if died
					if (t.health <= 0)         
							t.onDeath ();            

					// destroy bullet
					Destroy (gameObject);
			}
		}
	}
	
	public void setDestination(Transform v) {
		destination = v;
	}
}