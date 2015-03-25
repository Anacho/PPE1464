using UnityEngine;
using System.Collections;
using System.IO;

public class Controller : MonoBehaviour {
	public static int MapSizeX = 11;
	public static int MapSizeY = 11;
	public static string[,] MapArray = new string[MapSizeX,MapSizeY];
	public static string[,] MapArrayOpponent = new string[MapSizeX,MapSizeY];
	public static bool bLoading = false;
	public static bool bMapEditor = true;
	public static string map = "";
	public GameObject AreaSpot;
	public GameObject RoadCurve;
	public GameObject RoadStraight;
	public GameObject NoRoad;
	public GameObject RoadStart;
	public GameObject RoadEnd;

	/* int = 0 ; NULL
	 * int = 1 ; NE
	 * int = 2 ; NS
	 * int = 3 ; NW
	 * int = 4 ; SE
	 * int = 5 ; SW
	 * int = 6 ; WE
	 * int = -2 ; END
	 * int = -1 ; START
	 */

	
	// Use this for initialization
	void Start ()
	{

		readSettings ();
		MapArray[(MapSizeX-1)/2, 0] = "-2";
		MapArray[(MapSizeX-1)/2, MapSizeY-1] = "-1";
		if (!bMapEditor)
		{
			read ();
			loadingMap(true);
		}
		else if (!bLoading)
		{
			for (int i = 0; i<MapSizeX; i++)
			{
				for (int j = 0; j < MapSizeY; j++)
				{
					MapArray [i, j] = "0";
				}
			}
			MapArray[(MapSizeX-1)/2, 0] = "-2";
			MapArray[(MapSizeX-1)/2, MapSizeY-1] = "-1";

		}
		else
			read ();
		loadingMap (false);

	}
	 
	void saving()
	{
		TextWriter writer;
		string fileName = map + ".txt";
		writer = new StreamWriter(fileName);
		int count = 0;
		string[] save = new string[MapSizeX*MapSizeY];
		for (int i = 0; i < MapSizeX; i++)
		{
			for (int j = 0; j < MapSizeY; j++)
			{
				save[count] = MapArray[i,j];
				writer.WriteLine (save [count]);
				count++;
			}
		}
		writer.Close();     
	}

	void read ()
	{
		string fileName = map + ".txt";
		TextReader reader;
		reader = new  StreamReader(fileName);
		for (int i = 0; i < MapSizeX; i++)
		{
			for (int j = 0; j < MapSizeY; j++)
			{
				MapArray[i,j] = reader.ReadLine();
			}
		}
		reader.Close();
	}

	void loadingMap (bool opponent)
	{
		float BaseX = -22.5F;
		float BaseY = -22.5F;

		if(!bMapEditor)
		{
			BaseX = -50F;
		}
		if(opponent == true)
		{
			BaseX = 10F;
		}

		for (int i = 0; i < MapSizeX; i++)
		{
			for(int j = 0; j < MapSizeY; j++)
			{
				switch (MapArray[i,j]) {
				case "0":
					if(!bMapEditor)
						Instantiate(NoRoad, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler(180,0,0));
					else
						Instantiate(AreaSpot, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler(0,0,0));
					break;
				case "1":
					Instantiate(RoadCurve, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,180,0));
					break;
				case "2":
					Instantiate(RoadStraight, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,0,0));
					break;
				case "3":
					Instantiate(RoadCurve, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,90,0));
					break;
				case "4":
					Instantiate(RoadCurve, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,270,0));
					break;
				case "5":
					Instantiate(RoadCurve, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,0,0));
					break;
				case "6":
					Instantiate(RoadStraight, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,90,0));
					break;
				case "-2":
					Instantiate(RoadEnd, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,0,0));
					break;
				case "-1":
		            Instantiate(RoadStart, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.Euler (0,0,0));
					break;
				default:
					Instantiate(AreaSpot, new Vector3(BaseX + 5*i, 0, BaseY + 5*j), Quaternion.identity);
					break;
				}
				
			}
		}
	}

	// Update is called once per frame
	void OnGUI ()
	{
		if (bMapEditor)
		{
			if (GUI.Button (new Rect (10, 10, 100, 100), "Saving"))
			{
				if (getPath ())
					saving ();
			}

			GUI.Box (new Rect (380, 10, 50, 25), "Start");
			GUI.Box (new Rect (380, 310, 50, 25), "End");
		}
		else
		{
			GUI.Box (new Rect (240, 10, 50, 25), "Start");
			GUI.Box (new Rect (240, 310, 50, 25), "End");

			GUI.Box (new Rect (540, 10, 50, 25), "Start");
			GUI.Box (new Rect (540, 310, 50, 25), "End");

		}
	}

	bool getPath()
	{
		int x = (MapSizeX-1)/2;
		int y = MapSizeY-1;
		char Direction = 'S';
		bool end = false;
		bool correct = false;

		Debug.Log (x + " " + y);

		while (end == false)
		{
			switch (MapArray [x, y]) {
			case "0":
				Debug.Log ("Erreur Path");
				return correct;
			case "1": //NE
				if (Direction == 'S') {
					Direction = 'E';
					x++;
				} else if (Direction == 'W') {
					Direction = 'N';
					y++;
				} else {
					Debug.Log ("Erreur Path");
					return correct;
				}
				break;
			case "2": //NS
				if (Direction == 'S') {
					Direction = 'S';
					y--;
				} else if (Direction == 'N') {
					Direction = 'N';
					y++;
				} else {
					Debug.Log ("Erreur Path");
					return correct;
				}
				break;
			case "3": // NW
				if (Direction == 'S') {
					Direction = 'W';
					x--;
				} else if (Direction == 'E') {
					Direction = 'N';
					y++;
				} else {
					Debug.Log ("Erreur Path");
					return correct;
				}
				break;
			case "4": //SE
				if (Direction == 'N') {
					Direction = 'E';
					x++;
				} else if (Direction == 'W') {
					Direction = 'S';
					y--;
				} else {
					Debug.Log ("Erreur Path");
					return correct;
				}
				break;
			case "5": //SW
				if (Direction == 'N') {
					Direction = 'W';
					x--;
				} else if (Direction == 'E') {
					Direction = 'S';
					y--;
				} else {
					Debug.Log ("Erreur Path");
					return correct;
				}
				break;
			case "6": //WE
				if (Direction == 'E') {
					Direction = 'E';
					x++;
				} else if (Direction == 'W') {
					Direction = 'W';
					x--;
				} else {
					Debug.Log ("Erreur Path");
					return correct;
				}
				break;
			case "-2": //END
				end = true;
				break;
			case "-1": //START
				Direction = 'S';
				y--;
				break;
			default:
				Debug.Log("Erreur Path");
				return correct;
			}
			Debug.Log (x + " " + y);
			if(x >= MapSizeX || x < 0 || y >= MapSizeY || y < 0)
			{
				Debug.Log ("Erreur Path");
				return correct;
			}
		}
		correct = true;
		return correct;
	}


	void readSettings()
	{
		string sLoading = "";
		string fileName = "settings.txt";
		TextReader reader;
		reader = new  StreamReader(fileName);

		map = reader.ReadLine ();
		sLoading = reader.ReadLine ();
		if (sLoading == "True") {
			bLoading = true;
		} else
			bLoading = false;

		reader.Close();
	}

}


/*public class SouthWestDirectionCommand : IChangeDirectionCommand{

	public SouthWestDirectionCommand(int x, int y){

	}

	public string Execute(string directionIn){

	}

	public bool IsValid(string inp){

		return inp == "5";
	}
}
	
public interface IChangeDirectionCommand{
	string Execute(string directionIn);
	bool IsValid(string s);
}*/
