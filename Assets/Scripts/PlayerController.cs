using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;
    public Text timeText;
    public float time;
    private int count;
    private bool isClear;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        speed = 10;
        SetText ();
        winText.text = "";
        count = 0;
        time = 0.0f;
        isClear = false;
    }

    // Update is called once per frame
    void Update () {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        rb.AddForce (movement * speed);
        if (!isClear) {
            time += Time.deltaTime;
            timeText.text = time.ToString ("F2") + "s"; //F2で小数点第2位までを表示
        }
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
            isClear = true;
            timeText.text = "";
            string clearTime = time.ToString ("F2");
            winText.text = $"ClearTime:{clearTime}s";
        }
    }

    public void Replay () {
        transform.position = new Vector3 (0.0f, 0.5f, 0.0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        time = 0.0f;
        count = 0;
    }
}