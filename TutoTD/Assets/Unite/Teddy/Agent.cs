using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {    
    // Cache
	NavMeshAgent agent = null;
	Animator animator = null;
	Locomotion locomotion = null;
	Object particleClone = null;
    const float ONEEIGHTY_PI = 180.0f / 3.14159f;

	void Awake() {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;

		animator = GetComponent<Animator>();
		locomotion = new Locomotion(animator);
	}
    
	void SetupAgentLocomotion() {
		if (AgentDone()) {
			locomotion.Do(0, 0);
			if (particleClone != null) {
				GameObject.Destroy(particleClone);
				particleClone = null;
			}
		} else {
			float speed = agent.desiredVelocity.magnitude;
			Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;
			float angle = Mathf.Atan2(velocity.x, velocity.z) * ONEEIGHTY_PI;
			locomotion.Do(speed, angle);
		}
	}

    void OnAnimatorMove() {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
		transform.rotation = animator.rootRotation;
    }

	bool AgentDone() {
		return !agent.pathPending && AgentStopping();
	}

	bool AgentStopping() {
		return agent.remainingDistance <= agent.stoppingDistance;
	}

	// Update is called once per frame
	void Update() {
		SetupAgentLocomotion();
	}
}
