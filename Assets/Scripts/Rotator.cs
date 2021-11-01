using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    private Vector3 angle = new Vector3 (15, 30, 45);

    void Update () {
        transform.Rotate (angle * Time.deltaTime);
    }
}