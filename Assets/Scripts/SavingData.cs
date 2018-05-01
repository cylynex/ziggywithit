using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingData : MonoBehaviour {

	public int number = 0;

	void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            number++;
            if (number > getNumber()) {
                setNumber();
                Debug.Log(number);
            }
        }

        if (Input.GetKeyDown("t")) {
            Debug.Log("Preferense myNumber is set to: " + getNumber());
        }

	}

    int getNumber() {
        int outNumber = PlayerPrefs.GetInt("myNumber");
        return outNumber;
    }

    void setNumber() {
        PlayerPrefs.SetInt("myNumber", number);
    }

}
