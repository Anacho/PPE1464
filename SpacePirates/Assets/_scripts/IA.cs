using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.IO;

public class IA : MonoBehaviour {

	private List<Controller.Coord> listCoords = new List<Controller.Coord>(Controller.ArrayCoordOpponent);
	private List<Controller.Coord> listToBuild = new List<Controller.Coord>();
	


	// Use this for initialization
	void Start () 
	{

		bool duplicate;

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
						if(!listToBuild.Contains(tempCoord)) listToBuild.Add (tempCoord);
					}
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Castle.enemyGold>0) 
		{
			int rnd;
			rnd = (int)(Random.Range(0, listToBuild.Count));
			
		}
	}
}
