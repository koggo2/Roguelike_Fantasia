using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroActor : MonoBehaviour {

	private Animator _animator;
	private NavMeshAgent _agent;

	private void Awake() {
		_animator = GetComponentInChildren<Animator>(true);
		_agent = GetComponent<NavMeshAgent>();
	}

	public void Move(Vector3 worldPosition) {
		_agent.SetDestination(worldPosition);
		_animator.SetBool("Moving", true);
	}

	public void Attack() {
		
	}

	public void Stay() {
		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckCondition() {
		
	}
}
