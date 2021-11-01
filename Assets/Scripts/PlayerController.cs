using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;

    private int count;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        speed = 10;
        SetText ();
        winText.text = "";
        count = 0;
    }

    // Update is called once per frame
    void Update () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        rb.AddForce (movement * speed);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Pick Up")) {
            other.gameObject.SetActive (false);
            count++;
            SetText ();
        }
    }

    private void SetText () {
        countText.text = "count : " + count.ToString ();
        if (count >= 12) {
            winText.text = "YOU WIN!";
        }
    }

}