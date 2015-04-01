using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.IO;

public class IA : MonoBehaviour {

	private List<Controller.Coord> listCoords = Controller.ArrayCoordOpponent;
	private List<Controller.Coord> listToBuild = new List<Controller.Coord>();
	
	public Tower towerPrefab = null;

	float timeLeft = 0.0f;
	float interval = 0.8f;

	// Use this for initialization
	void Start () 
	{
		Debug.Log("Début de l'initialisation");
		foreach(Controller.Coord coord in listCoords) 
		{
			Controller.Coord[] coords = new Controller.Coord[4];
			coords[0].x=coord.x+1;
			coords[0].y=coord.y;
			coords[1].x=coord.x-1;
			coords[1].y=coord.y;
			coords[2].x=coord.x;
			coords[2].y=coord.y+1;
			coords[3].x=coord.x;
			coords[3].y=coord.y-1;

			foreach(Controller.Coord tempCoord in coords)
			{

				if(tempCoord.x<Controller.MapSizeX && tempCoord.x>=0 && tempCoord.y<Controller.MapSizeY && tempCoord.y>=0)
				{
					if(!listCoords.Contains(tempCoord))
					{
						if(!listToBuild.Contains(tempCoord)) 
						{
							if(!(tempCoord.x==((Controller.MapSizeX-1)/2)&&(tempCoord.x==((Controller.MapSizeX-1)/2))))
							{
								listToBuild.Add (tempCoord);
							}
						}
					}
				}
			}
			foreach(Controller.Coord coordonnees in listToBuild)
			{
				//Debug.Log("x: "+coordonnees.x + " y: "+coordonnees.y);
			}

		}


	}
	
	// Update is called once per frame
	void Update () 
	{
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0.0f) 
		{
			if(listToBuild.Count>0)
			{
				if (Castle.enemyGold > 0) {
					int rnd;
					rnd = (int)(Random.Range (0, listToBuild.Count));
					Debug.Log("x: "+listToBuild[rnd].x + " y: "+listToBuild[rnd].y);
					BuildTurret (listToBuild [rnd], true);
					listToBuild.RemoveAt(rnd);
					Castle.enemyGold--;
				}
			}
			timeLeft=interval;
		}

	}

	void BuildTurret(Controller.Coord coord, bool enemy)
	{
		Tower tower = (Tower) Instantiate (towerPrefab, Controller.MapOpponent[coord.x, coord.y].transform.position, new Quaternion ());
		tower.enemy = enemy;
	}
}
