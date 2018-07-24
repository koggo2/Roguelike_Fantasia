using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class HeroActor : MonoBehaviour {

	private Animator _animator;
	private NavMeshAgent _agent;
	
	public int CharacterIndex { get; set; }

	private IEnumerator _checkDistanceAction;
	private Vector3 _destination;
	
	private GameObject sphere;

	private void Awake() {
		_animator = GetComponentInChildren<Animator>(true);
		_agent = GetComponent<NavMeshAgent>();

		var spherePrefab = Resources.Load<GameObject>("Prefabs/ETC/Sphere");
		sphere = Instantiate(spherePrefab);
		sphere.GetComponent<MeshRenderer>().material.color = Color.red;
		sphere.SetActive(false);
	}

	public void Move(Vector3 worldPosition) {
		_destination = worldPosition + CharacterPositioning.GetPosition(CharacterIndex);
		_agent.SetDestination(_destination);
		_animator.SetBool("Moving", true);

		sphere.transform.position = _destination;
		sphere.SetActive(true);
		
		StartCoroutine(CheckingMovingEnd());
	}

	private IEnumerator CheckingMovingEnd() {
		while (_agent.remainingDistance > float.Epsilon) {
			yield return new WaitForEndOfFrame();
		}

		_animator.SetBool("Moving", false);
		sphere.SetActive(false);
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

	public void CheckCondition() {
		
	}
}
