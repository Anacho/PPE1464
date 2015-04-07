using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {


	public bool enemy = false;
	static int nbRobot=0;
	int prixRobot=1;
	int vague = 0;
	bool newVague=true;
	string text="Unité\n\nUnités de base : 5 robots\nAjout d'unités : ";
	
	protected bool gui = false;
	bool guiButton=true;

	void OnGUI() {
		if(!enemy && !Controller.bMapEditor){
			GUI.Label(new Rect(200,0,100,100),"Vague "+vague);
			GUI.skin.button.fontSize = (int)(0.08*Screen.height);
			if(guiButton){
				if (GUI.Button(new Rect(0,(float)(Screen.height-0.1*Screen.height),(float)(0.12*Screen.width),(float)(0.1*Screen.height)),"Unité")){
					guiButton=false;
					gui=true;
				}
			}
			
			if (gui) {
				Rect r = new Rect( 0, 0, Screen.width, Screen.height);
				GUI.Box(r, text + nbRobot);
				
				GUI.Label(new Rect(80,150,100,100),"Robot(s) : "+nbRobot);
				GUI.Label(new Rect(80,170,100,100),"Prix : "+prixRobot);
				
				if (GUI.Button(new Rect(50,200,50,50),"-")){
					if(nbRobot>0){
						nbRobot--;
						Castle.gold+=prixRobot;
					}
				}
				
				if (GUI.Button(new Rect(120,200,50,50),"+")){
					if(Castle.gold>=+prixRobot){
						nbRobot++;
						Castle.gold-=prixRobot;
					}
				}
				
				
				if (GUI.Button(new Rect(200,(float)(Screen.height-0.1*Screen.height),(float)(0.12*Screen.width),(float)(0.1*Screen.height)),"Retour")){
					guiButton=true;
					gui=false;
				}
			}
		}
	}



	// spawn a new teddy each ... seconds
	public float interval = 3.0f;
	public float intervalVague=10.0f;
	float timeLeftVague = 0.0f;
	float timeLeft = 0.0f;
	public int count = 0;



	// gameobject to be spawned
	public Unite robot = null;

	// destination (where all spawned objects run to)
	public Transform destination = null;
	
	// Update is called once per frame
	void Update () {
		if (!Game.done && !Controller.bMapEditor) {

			// time to spawn the next one?
			timeLeft -= Time.deltaTime;
			if (timeLeft <= 0.0f) {
					// spawn
				Vector3 SpawnPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
					if (count > 0)  {
						count--;
						Unite unite = (Unite)Instantiate (robot, SpawnPosition, Quaternion.identity);
						// get access to the navmesh agent component
						NavMeshAgent n = unite.GetComponentInParent<NavMeshAgent> ();
						if(enemy)
							n.destination = Controller.MapOpponent [Controller.ArrayCoordOpponent [0].x, Controller.ArrayCoordOpponent [0].y].transform.position;
						else
							n.destination = Controller.Map [Controller.ArrayCoord [0].x, Controller.ArrayCoord [0].y].transform.position;
						if(!enemy){
							unite.enemy=true;
						}
						
					}
					

					// reset time
					timeLeft = interval;

			}


			if(count==0){
				timeLeftVague-=Time.deltaTime;
				if(timeLeftVague <= 0.0f){
					count=5+nbRobot;
					nbRobot=0;
					vague++;
					timeLeftVague=intervalVague;
				}
			}
		}
	}
}
