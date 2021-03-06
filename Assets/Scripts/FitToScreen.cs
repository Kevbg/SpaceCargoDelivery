﻿using UnityEngine;
using System.Collections;

public class FitToScreen : MonoBehaviour {

    void Update() {
        if (GetComponent<FitToScreen>().isActiveAndEnabled) {
            float aspectRatio = (float)Screen.width / (float)Screen.height;
            transform.localScale = new Vector3((Camera.main.orthographicSize * 2) * aspectRatio,
                                                Camera.main.orthographicSize * 2, transform.localScale.z);
        }
    }
}
