using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	public bool enemy = false;

	// bullet
	public Bullet bulletPrefab = null;

	// upgrad tower
	public Tower upgradeTowerPrefab = null;
	
	// interval
	public float interval = 0.8f;
	float timeLeft = 0.0f;
	
	// attack range
	public float range = 30.0f;
	
	// price to build the tower
	public int buildPrice = 1;
	
	// rotation 
	public float rotationSpeed = 10;
	
	Unite findClosestTarget() {
		Unite closest = null;
		Vector3 pos = transform.position;
		Castle castle = null;
		// find all unites
		Unite[] unites = (Unite[])FindObjectsOfType(typeof(Unite));
		Castle[] castles = (Castle[])FindObjectsOfType(typeof(Castle));

		if(enemy){
			for(int i=0;i<castles.Length;i++){
				if(castles[i].enemy){	
					castle = castles[i];
				}
			}
			if (unites != null) {
				if (unites.Length > 0) {
					for (int i = 0; i < unites.Length; ++i) {
						if(!unites[i].enemy){
							if(closest==null){
								closest=unites[i];
							}
							float cur = Vector3.Distance(castle.transform.position, unites[i].transform.position);
							float old = Vector3.Distance(castle.transform.position, closest.transform.position);
							
							if (cur < old && Vector3.Distance(pos, unites[i].transform.position) <= range) {
								closest = unites[i];
							}
						}

					}
				}
			}
		}
		else {
			for(int i=0;i<castles.Length;i++){
				if(!castles[i].enemy){	
					castle = castles[i];
				}
			}
			if (unites != null) {
				if (unites.Length > 0) {
					for (int i = 0; i < unites.Length; ++i) {
						if(unites[i].enemy){
							if(closest==null){
								closest=unites[i];
							}
							float cur = Vector3.Distance(castle.transform.position, unites[i].transform.position);
							float old = Vector3.Distance(castle.transform.position, closest.transform.position);
							
							if (cur < old && Vector3.Distance(pos, unites[i].transform.position) <= range) {
								closest = unites[i];
							}
						}
					}
				}
			}
		}
		return closest;
	}
	
	void Update() {
		if (!Game.done) {
			Unite target = findClosestTarget ();
			timeLeft -= Time.deltaTime;
			// find the closest target (if any)
			if (target != null) {        
				// is it close enough?
				if (Vector3.Distance (transform.position, target.transform.position) <= range) {
						//rotate
					var rotate = Quaternion.LookRotation (target.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotate, Time.deltaTime * rotationSpeed);
					// shoot next bullet?
					if (timeLeft <= 0.0f) {
						// spawn bullet
						GameObject g = (GameObject)Instantiate (bulletPrefab.gameObject, transform.position, Quaternion.identity);

						// get access to bullet component
						Bullet b = g.GetComponent<Bullet> ();

						// set destination        
						b.setDestination (target.transform);



						// reset time
						timeLeft = interval;
					}
				}
			}
		}

	}


	bool gui = false;
	// price to upgrade the tower
	public int upgradePrice = 5;
	void OnGUI() {

		if (gui) {

			// get 3d position on screen        
			Vector3 v = Camera.main.WorldToScreenPoint(transform.position);
			
			// convert to gui coordinates
			v = new Vector2(v.x, Screen.height - v.y); 
			
			// creation menu for tower
			int width = 200;
			int height = 40;
			Rect r = new Rect(v.x - width / 2, v.y - height / 2, width, height);
			if(enemy){
				GUI.contentColor = (Castle.enemyGold >= upgradePrice ? Color.green : Color.red);
			}
			else {
				GUI.contentColor = (Castle.gold >= upgradePrice ? Color.green : Color.red);
			}
			GUI.Box(r, "Upgrade this tower (" + upgradePrice + " gold)");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    r.Contains(Event.current.mousePosition)){
			    if(Castle.gold >= upgradePrice&&!enemy) {
					// decrease gold
					Castle.gold -= upgradePrice;
					
					Vector3 rot = upgradeTowerPrefab.transform.eulerAngles;
					Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z); 
					// instantiate
					Instantiate(upgradeTowerPrefab, pos, Quaternion.Euler(rot.x, rot.y , rot.z));
					// destroy tower
					Destroy(gameObject);
				}
				else if(Castle.enemyGold >= upgradePrice&&enemy){
					// decrease gold
					Castle.enemyGold -= upgradePrice;
					
					Vector3 rot = upgradeTowerPrefab.transform.eulerAngles;
					Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z); 
					// instantiate
					Instantiate(upgradeTowerPrefab, pos, Quaternion.Euler(rot.x, rot.y , rot.z));
					// destroy tower
					Destroy(gameObject);
				}
			}
		}
	}
	
	public void OnMouseDown() {
		if (upgradeTowerPrefab != null || !Game.done) {
						gui = true;
				}
	}
	
	
	public void OnMouseUp() {
		gui = false;
	}
}