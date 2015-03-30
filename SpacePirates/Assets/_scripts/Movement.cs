using UnityEngine;
using System.Collections;



public class Movement : MonoBehaviour {

	Transform Step1 = null;
	Castle Step2 = null;
	Transform Thing = null;

	IEnumerator Start()
	{
		Vector3 pointB = Step1.position ();
		var pointA = Thing.position;
		while (true) {
			yield return StartCoroutine(MoveObject(Thing, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(Thing, pointB, pointA, 3.0f));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
	}
}
