using UnityEngine;
using TouchScript;

public class InputPosition : MonoBehaviour {

    void OnEnable() {
        if (TouchManager.Instance != null)
            TouchManager.Instance.TouchesMoved += TouchesMovedHandler;
    }

    void OnDisable() {
        if (TouchManager.Instance != null)
            TouchManager.Instance.TouchesMoved -= TouchesMovedHandler;
    }

    void TouchesMovedHandler(object s,TouchEventArgs e) {
        int count = e.Touches.Count;
        for (int i = 0 ; i < count ; i++) {
            TouchPoint touch = e.Touches[i];
            print(touch.Position);
        }
    }
}

