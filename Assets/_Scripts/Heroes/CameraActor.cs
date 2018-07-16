using UnityEngine;
using UnityEngine.AI;

public class CameraActor : MonoBehaviour {

	private NavMeshAgent _agent;
	
	void Awake () {
		_agent = GetComponent<NavMeshAgent>();
	}
	
	public void Move(Vector3 worldPosition) {
		_agent.SetDestination(worldPosition);
	}
}

