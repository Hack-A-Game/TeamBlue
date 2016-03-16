using UnityEngine;
using System.Collections.Generic;
using System;


public class AnimTween {

    private Queue<AnimParams> queue;

    public AnimTween() {
        queue = new Queue<AnimParams>();
    }

    private float accum;
    public float animSeconds = 2;

    private AnimParams activeAnim = null;

    // Returns true if all animations have been processed
    public bool processQueue() {
        float delta = Time.deltaTime;

        // Get new Anim
        if (activeAnim == null && accum >= animSeconds && queue.Count > 0) {
            activeAnim = queue.Dequeue();
            accum = 0;
        }
        else {
            return true;
        }

        // If we get here, we'll always have an activeAnim
        accum += delta;
        float alpha = accum / animSeconds;

        activeAnim.obj.transform.position = Vector3.Lerp(activeAnim.from, activeAnim.to, alpha);
        //activeAnim.progress = alpha;

        // dereference expired anims
        if(accum >= animSeconds) {
            activeAnim = null;
        }

        return false;
    }

    public void addToQueue(GameObject o, Vector3 from, Vector3 to) {
        AnimParams newAnim = new AnimParams();
        newAnim.obj = o;
        newAnim.from = from;
        newAnim.to = to;
        //newAnim.progress = 0;

        queue.Enqueue(newAnim);
    }


    class AnimParams {
        public GameObject obj;
        public Vector3 from;
        public Vector3 to;
        //public float progress;
    }
}

