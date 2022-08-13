using UnityEngine;

public class RunInBackground : MonoBehaviour {

	void Awake() {
        Application.runInBackground = true;
    }
}
