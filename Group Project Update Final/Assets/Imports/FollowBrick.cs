using TouchScript;
using UnityEngine;

public class FollowBrick : MonoBehaviour {

    private void OnEnable() {
        if (TouchManager.Instance != null) {
            TouchManager.Instance.TouchesMoved += touchesMovedHandler;
        }
    }

    void OnDisable() {
        if (TouchManager.Instance != null) {
            TouchManager.Instance.TouchesMoved -= touchesMovedHandler;
        }
    }

    private void touchesMovedHandler(object sender,TouchEventArgs e) {
        int count = e.Touches.Count;
        for (int i = 0 ; i < count ; i++) {
            TouchPoint touch = e.Touches[i];
            if (touch.Tags.HasTag("brick")) {
                float y = touch.Position.y;
                float x = touch.Position.x;

                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,5));

                float f = (float) touch.Properties["Angle"];
                transform.rotation = Quaternion.Euler(0,0,(f / 6.25f) * 360f);
            }
        }
    }
}