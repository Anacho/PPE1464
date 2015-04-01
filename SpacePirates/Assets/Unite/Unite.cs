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
			if(Controller.stepCountOpponent == stepMove)
			{
				Vector3 tmp = new Vector3(0,0,-27.5F);
				tmp.y = Controller.MapOpponent[Controller.ArrayCoordOpponent [Controller.stepCountOpponent-1].x, Controller.ArrayCoordOpponent [Controller.stepCountOpponent-1].y].transform.position.y;
				tmp.x = Controller.MapOpponent[Controller.ArrayCoordOpponent [Controller.stepCountOpponent-1].x, Controller.ArrayCoordOpponent [Controller.stepCountOpponent-1].y].transform.position.x;
				GetComponent<NavMeshAgent> ().destination = tmp;
			}
			else if (Vector3.Distance(Controller.MapOpponent [Controller.ArrayCoordOpponent [stepMove].x, Controller.ArrayCoordOpponent [stepMove].y].transform.position, transform.position) <= 3) {
				stepMove++;
				if(Controller.stepCountOpponent != stepMove)
					GetComponent<NavMeshAgent> ().destination = Controller.MapOpponent [Controller.ArrayCoordOpponent [stepMove].x, Controller.ArrayCoordOpponent [stepMove].y].transform.position;
			}
		} else if (enemy) {
			// teste les coordonnées de l'unité avec celle de la map
			if(Controller.stepCount == stepMove)
			{
				Vector3 tmp = new Vector3(0,0,-27.5F);
				tmp.y = Controller.Map[Controller.ArrayCoord [Controller.stepCount-1].x, Controller.ArrayCoord [Controller.stepCount-1].y].transform.position.y;
				tmp.x = Controller.Map[Controller.ArrayCoord [Controller.stepCount-1].x, Controller.ArrayCoord [Controller.stepCount-1].y].transform.position.x;
				GetComponent<NavMeshAgent> ().destination = tmp;
			}
			else if (Vector3.Distance(Controller.Map [Controller.ArrayCoord [stepMove].x, Controller.ArrayCoord [stepMove].y].transform.position, transform.position) <= 3) {
				stepMove++;
				if(Controller.stepCount != stepMove)
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
