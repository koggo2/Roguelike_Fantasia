using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterPositioning {

	private static Vector3[] _positions = new Vector3[]{
		new Vector3(-1.5f, 0f, 0f),
		new Vector3(0f, 0f, 0f),
		new Vector3(1.5f, 0f, 0f),
		new Vector3(-1.5f, 0f, -1.5f),
		new Vector3(0f, 0f, -1.5f),
		new Vector3(1.5f, 0f, -1.5f),
		new Vector3(-1.5f, 0f, -3f),
		new Vector3(0f, 0f, -3f),
		new Vector3(1.5f, 0f, -3f),
	};
	
	public static Vector3 GetPosition(int index) {

		if (index > 8)
			return _positions[1];
		
		return _positions[index];
	}
}
