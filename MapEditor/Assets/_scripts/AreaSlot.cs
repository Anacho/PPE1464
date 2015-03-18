using UnityEngine;
using System.Collections;

public class AreaSlot : MonoBehaviour {
	public GUISkin skin = null;
	
	bool gui = false;
	
	// Piece prefab
	public Transform RoadStraight;
	public Transform RoadCurve;
	public int coordX;
	public int coordY;

	void OnGUI() {

		if (gui) {

			// get 3d position on screen        
			Vector3 v = Camera.main.WorldToScreenPoint(transform.position);
			
			// convert to gui coordinates
			v = new Vector2(v.x, Screen.height - v.y); 
			
			// creation menu for tower
			int width = 30;
			int height = 25;
			Rect rNE = new Rect(v.x - width / 2 + 35, v.y - height / 2 - 35, width, height);
			GUI.Box (rNE, "NE");

			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    rNE.Contains(Event.current.mousePosition)) {

				// instantiate
				Instantiate(RoadCurve, transform.position, Quaternion.Euler (0,180,0));
				int i = (int)(gameObject.transform.position.x+22.5f)/5;
				int j = (int)(gameObject.transform.position.z+22.5f)/5;
				Controller.MapArray[i,j] = "1";
				
				// disable gameobject
				Destroy(gameObject);
			}

			Rect rNW = new Rect(v.x - width / 2 - 35, v.y - height / 2 - 35, width, height);
			GUI.Box (rNW, "NW");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    rNW.Contains(Event.current.mousePosition)) {
				
				// instantiate
				Instantiate(RoadCurve, transform.position, Quaternion.Euler (0,90,0));
				int i = (int)(gameObject.transform.position.x+22.5f)/5;
				int j = (int)(gameObject.transform.position.z+22.5f)/5;
				Controller.MapArray[i,j] = "3";
				
				// disable gameobject
				Destroy(gameObject);
			}

			Rect rSW = new Rect(v.x - width / 2 - 35, v.y - height / 2 + 35, width, height);
			GUI.Box (rSW, "SW");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    rSW.Contains(Event.current.mousePosition)) {
				
				// instantiate
				Instantiate(RoadCurve, transform.position, Quaternion.Euler (0,0,0));
				int i = (int)(gameObject.transform.position.x+22.5f)/5;
				int j = (int)(gameObject.transform.position.z+22.5f)/5;
				Controller.MapArray[i,j] = "5";
				
				// disable gameobject
				Destroy(gameObject);
			}

			Rect rSE = new Rect(v.x - width / 2 + 35, v.y - height / 2 + 35, width, height);
			GUI.Box (rSE, "SE");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    rSE.Contains(Event.current.mousePosition)) {
				
				// instantiate
				Instantiate(RoadCurve, transform.position, Quaternion.Euler (0,270,0));
				int i = (int)(gameObject.transform.position.x+22.5f)/5;
				int j = (int)(gameObject.transform.position.z+22.5f)/5;
				Controller.MapArray[i,j] = "4";
				
				// disable gameobject
				Destroy(gameObject);
			}

			Rect rWE = new Rect(v.x - width / 2 + 50, v.y - height / 2, width, height);
			GUI.Box (rWE, "WE");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    rWE.Contains(Event.current.mousePosition)) {
				
				// instantiate
				Instantiate(RoadStraight, transform.position, Quaternion.Euler (0,90,0));
				int i = (int)(gameObject.transform.position.x+22.5f)/5;
				int j = (int)(gameObject.transform.position.z+22.5f)/5;
				Controller.MapArray[i,j] = "6";
				
				// disable gameobject
				Destroy(gameObject);
			}

			Rect rNS = new Rect(v.x - width / 2 - 50, v.y - height / 2, width, height);
			GUI.Box (rNS, "NS");
			
			// mouse not down anymore and mouse over the box? then build the tower                
			if (Event.current.type == EventType.MouseUp && 
			    rNS.Contains(Event.current.mousePosition)) {
				
				// instantiate
				Instantiate(RoadStraight, transform.position, Quaternion.Euler (0,0,0));
				int i = (int)(gameObject.transform.position.x+22.5f)/5;
				int j = (int)(gameObject.transform.position.z+22.5f)/5;
				Controller.MapArray[i,j] = "2";
				
				// disable gameobject
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
