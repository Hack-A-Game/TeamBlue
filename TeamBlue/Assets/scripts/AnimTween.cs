using UnityEngine;
using System.Collections.Generic;
using System;


public class AnimTween {

    public GameObject obj;
    public Vector3 from;
    public Vector3 to;
    public float progress;

    public AnimTween() {
        
    }

    public void processQueue() {

    }

    public void addToQueue(GameObject o, Vector3 from, Vector3 to) {
        AnimParams newAnim;
        newAnim.obj = o;
        newAnim.from = from;
        newAnim.to = to;
    }


    struct AnimParams {
        public GameObject obj;
        public Vector3 from;
        public Vector3 to;
        public float progress;
    }
}

