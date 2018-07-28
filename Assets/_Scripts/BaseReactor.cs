using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseReactor : MonoBehaviour {

	private void OnMouseDown() {
		OnClick();
	}

	private void OnMouseUp() {
		
	}

	protected virtual void OnClick() {
		
	}
}
