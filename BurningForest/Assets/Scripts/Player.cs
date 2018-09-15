using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    private Rigidbody rb;
    private bool forward, back,rightSpin,leftSpin,fire;
    public float movePower;
    [SerializeField]
    private GameObject firePrefab;
    private GameObject fireObj;
    private float fireCoolTimeCount,coolTime = 2;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerInput();
        Fire();
	}

    private void FixedUpdate() {
        Move();
    }

    void PlayerInput() {
        if (Input.GetKey("w")) {
            forward = true;
        } else {
            forward = false;
        }

        if (Input.GetKey("s")) {
            back = true;
        } else {
            back = false;
        }

        if (Input.GetKey("d")) {
            rightSpin = true;
        } else {
            rightSpin = false;
        }

        if (Input.GetKey("a")) {
            leftSpin= true;
        } else {
            leftSpin = false;
        }
    }

    void Move() {
        if (forward) {
            rb.velocity = new Vector3(transform.forward.normalized.x * movePower,rb.velocity.y, transform.forward.normalized.z * movePower);
        }

        if (back) {
            rb.velocity = new Vector3(transform.forward.normalized.x * -movePower, rb.velocity.y, transform.forward.normalized.z * -movePower);
        }

        if (rightSpin) {
            transform.Rotate(new Vector3(0, 3, 0));
        }

        if (leftSpin) {
            transform.Rotate(new Vector3(0, -3, 0));
        }
    }

    void Fire() {
        if (Input.GetKey(KeyCode.Space) && !fire) {
            fire = true;
            fireObj = Instantiate(firePrefab, transform.position + transform.forward.normalized * 0.3f, transform.rotation.normalized);
            fireObj.transform.parent = transform;
        }

        if (fire) {
            fireCoolTimeCount += Time.deltaTime;
            if(fireCoolTimeCount >= coolTime) {
                fireCoolTimeCount = 0;
                fire = false;
                Destroy(fireObj);
            }
        }

    }

}
