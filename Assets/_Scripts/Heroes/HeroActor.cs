using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroActor : MonoBehaviour {

	private Animator _animator;
	private NavMeshAgent _agent;
	
	public int CharacterIndex { get; set; }

	private void Awake() {
		_animator = GetComponentInChildren<Animator>(true);
		_agent = GetComponent<NavMeshAgent>();
	}

	public void Move(Vector3 worldPosition) {
		_agent.SetDestination(worldPosition + CharacterPositioning.GetPosition(CharacterIndex));
		_animator.SetBool("Moving", true);
	}

	[ContextMenu("Attack")]
	public void Attack() {
		_animator.SetTrigger("Attack1Trigger");
		var animationTime = _animator.GetCurrentAnimatorClipInfo(0).Length;

//		StartCoroutine(
//			DelayedAction(() => { _animator.gameObject.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity); }, animationTime)
//		);
	}

	private IEnumerator DelayedAction(Action action, float delayTime) {
		yield return new WaitForSeconds(delayTime);
		
		action.Invoke();
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
