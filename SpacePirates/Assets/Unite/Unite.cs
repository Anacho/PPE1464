using UnityEngine;
using System.Collections;

public class Unite : MonoBehaviour {

	public bool enemy = false;
	public int health;
	private int stepMove = 0;
	// Update is called once per frame
	void Update () {
		if (Game.done) {
			NavMeshAgent n = GetComponent<NavMeshAgent> ();
			n.destination = transform.position;
		} else if (!enemy) {
			// teste les coordonnées de l'unité avec celle de la map
			if (Vector3.Distance(Controller.MapOpponent [Controller.ArrayCoordOpponent [stepMove].x, Controller.ArrayCoordOpponent [stepMove].y].transform.position, transform.position) <= 1) {
				stepMove++;
				GetComponent<NavMeshAgent> ().destination = Controller.MapOpponent [Controller.ArrayCoordOpponent [stepMove].x, Controller.ArrayCoordOpponent [stepMove].y].transform.position;
			}
		} else if (enemy) {
			// teste les coordonnées de l'unité avec celle de la map
			if (Vector3.Distance(Controller.Map [Controller.ArrayCoord [stepMove].x, Controller.ArrayCoord [stepMove].y].transform.position, transform.position) <= 1) {
				stepMove++;
				GetComponent<NavMeshAgent> ().destination = Controller.Map [Controller.ArrayCoord [stepMove].x, Controller.ArrayCoord [stepMove].y].transform.position;
			}
		}
	}
	
	public void onDeath() {  
		if(enemy){
			// increase player gold
			Castle.gold = Castle.gold + 1;
		}
		else {
			//increase enemy gold
			Castle.enemyGold = Castle.enemyGold+1;
		}
		
		// destroy
		Destroy(gameObject); 
	}

	public void setEnemy(){
		enemy = true;
	}
}
