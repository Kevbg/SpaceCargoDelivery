using UnityEngine;
using System.Collections;

public class BGScroller : MonoBehaviour {
    public static BGScroller current;
    public float scrollSpeed;

    private float BGpos;

    public void Scroll() {
        // UP
        BGpos += scrollSpeed;
    
       if (BGpos > 1.0f) {
            BGpos -= 1.0f;
       }

       GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, BGpos);
    }

    void Update() {
        Scroll();
    }
}
