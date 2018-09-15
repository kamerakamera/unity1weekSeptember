using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Tree : MonoBehaviour {
    protected Rigidbody rb;
    [SerializeField]
    protected GameObject[] burningObj;
    [SerializeField]
    protected float burningTime = 3;
    [SerializeField]
    protected StageManeger stageManeger;

    // Use this for initialization
    protected virtual void Start () {
        stageManeger = GameObject.Find("StageManeger").GetComponent<StageManeger>();
	}

    // Update is called once per frame
    private void Update () {
        
	}

    protected virtual void OnTriggerEnter(Collider other) {
        if(other.tag == "Fire") {
            foreach (GameObject obj in burningObj) {
                obj.SetActive(true);
            }
            StartCoroutine("TreeBurning");
            stageManeger.AddScore();
        }
    }

    private IEnumerator TreeBurning() {
        yield return new WaitForSeconds(burningTime);
        Destroy(this.gameObject);
        stageManeger.CreateTree();
        yield break;
    }
}
