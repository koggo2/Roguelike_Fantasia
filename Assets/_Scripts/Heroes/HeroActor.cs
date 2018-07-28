using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public partial class HeroActor : MonoBehaviour {

	private Animator _animator;
	private NavMeshAgent _agent;
	
	public int CharacterIndex { get; set; }

	private IEnumerator _checkDistanceAction;
	private Vector3 _destination;
	private Vector3 _endRotation;
	
	private GameObject sphere;

	private void Awake() {
		_animator = GetComponentInChildren<Animator>(true);
		_agent = GetComponent<NavMeshAgent>();

		var spherePrefab = Resources.Load<GameObject>("Prefabs/ETC/Sphere");
		sphere = Instantiate(spherePrefab);
		sphere.GetComponent<MeshRenderer>().material.color = Color.red;
		sphere.SetActive(false);
	}

	private void Update() {
		if (!_agent.isStopped) {
			if (_agent.remainingDistance <= _agent.stoppingDistance) {
				var rotationVector = Vector3.RotateTowards(transform.forward, _endRotation, 1f, 0f);
				transform.rotation = Quaternion.LookRotation(rotationVector);
				
				_animator.SetBool("Moving", false);
				sphere.SetActive(false);
				_agent.Stop();
			}
		}
	}

	public void Move(Vector3 worldPosition, Vector3 lookAt) {
		_destination = worldPosition;// + CharacterPositioning.GetPosition(CharacterIndex);
		_endRotation = lookAt;
		
		_agent.Resume();
		_agent.SetDestination(_destination);
		_animator.SetBool("Moving", true);
		sphere.transform.position = _destination;
		sphere.SetActive(true);
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
