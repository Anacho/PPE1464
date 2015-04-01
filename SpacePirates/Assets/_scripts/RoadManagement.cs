using UnityEngine;
using System.Collections;

public class RoadManagement : MonoBehaviour {

	public Transform AreaSlot;

	bool gui = false;

	void OnGUI() {    

		if (gui && Controller.bMapEditor) {
			// get 3d position on screen        
			Vector3 v = Camera.main.WorldToScreenPoint(transform.position);
			
			// convert to gui coordinates
			v = new Vector2(v.x, Screen.height - v.y); 
			
			// creation menu for tower
			int width = 50;
			int height = 25;
			Rect r = new Rect(v.x - width / 2, v.y - height / 2 - 25, width, height);
			GUI.Box (r, "Delete?");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    r.Contains(Event.current.mousePosition)) {

				Instantiate(AreaSlot, transform.position, Quaternion.identity);
				int i = (int)(gameObject.transform.position.x+22.5f)/5;
				int j = (int)(gameObject.transform.position.z+22.5f)/5;
				Controller.MapArray[i,j] = "0";
				Destroy(gameObject);
			}
		}
	}
	
	public void OnMouseDown() {
		gui = true;
	}
	
	
	public void OnMouseUp() {
		gui = false;
	}
	

}
