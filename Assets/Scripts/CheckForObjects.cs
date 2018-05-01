using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForObjects : MonoBehaviour {
    

	void Update () {
        RaycastHit hit;

        /*
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100f)) {
            print("It's a hit at: "+hit.distance +" - "+hit.transform.position);
        } else {
            print("no collision"); 
        }
        */

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100)) {
            print("hit something: "+hit.collider.gameObject.name); 
        }


	}
}
