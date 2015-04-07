using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour {

	public static int gold = 3; // start gold
	public static int enemyGold = 3;
	
	public static int health = 30;
	public static int enemyHealth = 30;

	public bool enemy = false;

	void OnGUI() {
		if(!Controller.bMapEditor)
		{
			if(enemy){
				GUI.Label(new Rect(Screen.width-400, 0, 400, 200), "Gold: " + enemyGold);
				GUI.Label(new Rect(Screen.width-400, 40, 400, 200), "Castle Health: " + enemyHealth);
			}
			else{
				GUI.Label(new Rect(0, 0, 400, 200), "Gold: " + gold);
				GUI.Label(new Rect(0, 40, 400, 200), "Castle Health: " + health);
			}
		}
	

	}
	void Update() {
		// find all unites
		Unite[] unites = (Unite[])FindObjectsOfType(typeof(Unite));
		if (unites != null) {
			// find all unites that are close to the castle
			for (int i = 0; i < unites.Length; ++i) {
				float range = Mathf.Max(GetComponent<Collider>().bounds.size.x, GetComponent<Collider>().bounds.size.y);
				//if (Vector3.Distance(transform.position, unites[i].transform.position) <= range) { 
				if(unites[i].transform.position.z <= (-22.5F)) {
					if(!enemy){
						// decrease castle health
						health = health - 1;
					}

					// destroy unite
					Destroy(unites[i].gameObject);
				} 
			}
		}
		if (health == 0||enemyHealth==0) {
			Game.done=true;
		}

	}
}