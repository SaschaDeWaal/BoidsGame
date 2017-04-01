using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpeed : MonoBehaviour {

    private Animator animator;
    private Vector3  oldPosition;

    private void Start () {
        animator    = GetComponent<Animator>();
        oldPosition = transform.parent.position;
    }

    private void Update () {
        animator.speed = Vector3.Distance(transform.parent.position, oldPosition) * 5f;
        oldPosition    = transform.parent.position;
    }
}
