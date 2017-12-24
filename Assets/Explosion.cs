using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float animationTime = 1f;

    private void Start()
    {
        DestroyObjectDelayed();
    }
    void DestroyObjectDelayed()
    {
        Destroy(gameObject, animationTime);
    }
}
