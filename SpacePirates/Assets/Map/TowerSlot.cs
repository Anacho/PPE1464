using UnityEngine;
using System.Collections;

public class TowerSlot : MonoBehaviour {

	bool gui = false;

	public bool enemy = false;

	
	// Tower prefab
	public Tower towerPrefab = null;
	
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
				GUI.contentColor = (Castle.enemyGold >= towerPrefab.buildPrice ? Color.green : Color.red);
			}
			else {
				GUI.contentColor = (Castle.gold >= towerPrefab.buildPrice ? Color.green : Color.red);
			}
			GUI.Box(r, "Build " + towerPrefab.name + "(" + towerPrefab.buildPrice + " gold)");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    r.Contains(Event.current.mousePosition)){
			    if(Castle.enemyGold >= towerPrefab.buildPrice && enemy) {
					// decrease gold
					Castle.enemyGold -= towerPrefab.buildPrice;
					Vector3 rot = towerPrefab.transform.eulerAngles;
					Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z); 
					// instantiate
					Tower tower = (Tower)Instantiate(towerPrefab, pos, Quaternion.Euler(rot.x, rot.y , rot.z));
					tower.enemy=true;
					// disable gameobject
					gameObject.SetActive(false);
				}
				else if(Castle.gold >= towerPrefab.buildPrice && !enemy) {
					Castle.gold -= towerPrefab.buildPrice;
					Vector3 rot = towerPrefab.transform.eulerAngles;
					Vector3 pos = new Vector3(transform.position.x,transform.position.y,transform.position.z); 
					// instantiate
					Instantiate(towerPrefab, pos, Quaternion.Euler(rot.x, rot.y , rot.z));
					
					// disable gameobject
					gameObject.SetActive(false);
				}
			}
		}
	}
	
	public void OnMouseDown() {
		if (!Game.done) {
			gui = true;
		}
	}
	
	
	public void OnMouseUp() {
		gui = false;
	}
}
