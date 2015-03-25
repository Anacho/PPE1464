using UnityEngine;
using System.Collections;

public abstract class Game : MonoBehaviour {

	public static bool done = false;
	bool gui = false;
	void OnGUI() {
		if (gui) {
			// creation menu for tower
			int width = 200;
			int height = 40;
			Rect r = new Rect(Screen.width/2 - width / 2, Screen.height/2 - height / 2, width, height);
			if(Castle.health==0){
				GUI.contentColor = (Color.red);
				GUI.Box(r,"Game Over!");
			}
			else if(Castle.enemyHealth==0){
				GUI.contentColor = (Color.green);
				GUI.Box(r,"Victory!");
			}
		}
		if(done){
			gui=true;
		}
	}
}
