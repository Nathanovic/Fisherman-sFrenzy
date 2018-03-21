using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class LazyCollDeleter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Collider[] colls = GetComponents<Collider> ();
		for (int i = 0; i < colls.Length; i++) {
			DestroyImmediate (colls [i]);
		}
	}
}
