using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {


	public bool enemy = false;
	
	/*bool gui = false;
	void OnGUI() {
		if (gui) {
			GUI.skin = skin;
			// creation menu for tower
			int width = 200;
			int height = 40;
			Rect r = new Rect(Screen.width/2 - width / 2, Screen.height/2 - height / 2, width, height);
			GUI.contentColor = (Color.green);
			GUI.Box(r,"Victory!");
		}
	}*/


	// spawn a new teddy each ... seconds
	public float interval = 3.0f;
	float timeLeft = 0.0f;
	public int count = 10;



	// gameobject to be spawned
	public Unite robot = null;

	// destination (where all spawned objects run to)
	public Transform destination = null;
	
	// Update is called once per frame
	void Update () {
		if (!Game.done) {
			/*if (count == 0) {
				
				Unite[] unites = (Unite[])FindObjectsOfType(typeof(Unite));
				
				
				if(unites.Length==0){
					//gui=true;
					Game.done=true;
				}
			}*/
			// time to spawn the next one?
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0.0f) {
					// spawn

					if (count > 0)  {
						count--;
						Unite unite = (Unite)Instantiate (robot, transform.position, Quaternion.identity);
						// get access to the navmesh agent component
						NavMeshAgent n = unite.GetComponentInParent<NavMeshAgent> ();
						n.destination = destination.position;
						if(!enemy){
							unite.enemy=true;
						}
						
					}
					

					// reset time
					timeLeft = interval;

			}
		}
	}
}
