using UnityEngine;
using System.Collections;

public class AgentRobot : MonoBehaviour {

	NavMeshAgent agent = null;



	void Start ()
	{

		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = true;


	}
	/*void Update() {
		float speed = agent.desiredVelocity.magnitude;
		Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;
		float angle = Mathf.Atan2(velocity.x, velocity.z) * ONEEIGHTY_PI ;
		var rotate = Quaternion.AngleAxis(angle,Vector3.up);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime*1+.0f);

	}*/
}
