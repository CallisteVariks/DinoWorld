using System;
using TouchScript.Gestures;
using UnityEngine;

public class Clickable : MonoBehaviour {

    void OnEnable() {
        GetComponent<PressGesture>().Pressed += OnPress;
    }

    void OnPress(object s, EventArgs e) {
        Debug.Log("clicked");
    }
    
}
