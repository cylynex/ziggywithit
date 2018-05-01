using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour {

	public Transform cubePrefab;

	int counter = 0;

	void Start() {
		InvokeRepeating("CreateNewCube",3f, 1f);

		Invoke("CreateNewCube", 5f);
	}

	public void CreateNewCube() {
		Instantiate(cubePrefab, new Vector3(-10 + counter * 3.0f, 0,0), Quaternion.identity);
		counter++;

		if (counter >= 5) { 
			CancelInvoke();
		}
	}

}
