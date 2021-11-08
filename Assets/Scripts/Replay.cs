using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour {
    public PlayerController Player;
    public void Onclick () {
        Rigidbody rb = Player.GetComponent<Rigidbody> ();
        Player.transform.position = new Vector3 (0.0f, 0.5f, 0.0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}