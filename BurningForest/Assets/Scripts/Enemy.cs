using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tree {
    private bool isCamera = false,isBurning = false;
    [SerializeField]
    private Transform playerPosition;
    private Vector3 moveDirection;


    // Use this for initialization
    protected override void Start () {
        base.Start();
        rb = GetComponent<Rigidbody>();
        playerPosition = GameObject.Find("Player").transform;
        isBurning = false;
	}

    // Update is called once per frame
    private void Update () {
        Move();
    }

    private void Move() {
        if (!isCamera) {
            //Debug.Log("うつってないよ");
            moveDirection = (playerPosition.position - transform.position).normalized;
            moveDirection.y = 0;
            rb.velocity = moveDirection * 2.0f;
        } else if (isCamera) {
            //Debug.Log("うつったよ");
            moveDirection = Vector3.zero;
            rb.velocity = Vector3.zero;
            isCamera = false;
        }
    }

    private void OnWillRenderObject() {
        if (Camera.current.tag == "MainCamera") {
            isCamera = true;
        }
    }

    protected override void OnTriggerEnter(Collider other) {
        if (other.tag == "Fire" && isBurning == false) {
            foreach (GameObject obj in burningObj) {
                obj.SetActive(true);
            }
            isBurning = true;
            StartCoroutine("EnemyBurning");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player" && !isBurning) {
            stageManeger.AddMissCount();
            //Debug.Log("miss!");
            Destroy(this.gameObject);
            stageManeger.CreateEnemy();
        }
    }

    private IEnumerator EnemyBurning() {
        yield return new WaitForSeconds(burningTime);
        stageManeger.AddMissCount();
        Destroy(this.gameObject);
        stageManeger.CreateEnemy();
        yield break;
    }
}
