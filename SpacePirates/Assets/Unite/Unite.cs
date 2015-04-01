using UnityEngine;
using System.Collections;

public class Unite : MonoBehaviour {

	public bool enemy = false;
	public int health;
	// Update is called once per frame
	void Update () {
		if (Game.done) {
			NavMeshAgent n = GetComponent<NavMeshAgent> ();
			n.destination = transform.position;
		}
		else if(true) {

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
