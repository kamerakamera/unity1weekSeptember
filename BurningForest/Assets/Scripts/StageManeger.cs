using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManeger : MonoBehaviour {
    public static float score;
    public int maxTree = 10, maxEnemy = 10;
    private float missCount,maxMissCount = 4;
    private float timeLimitCount, maxTimeLimit = 60;
    private int[] treePositionX = new int[10], treePositionZ = new int[10];
    private GameObject[] tree = new GameObject[10];
    [SerializeField]
    private GameObject treePrefab, enemyPrefab;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        score = 0;
        missCount = 0;
        timeLimitCount = 0;

        GetTreePosition();
        for(int i = 0;i < 7; i++) {
            CreateTree();
        }
        for(int j = 0;j < 3; j++) {
            CreateEnemy();
        }
	}
	
	// Update is called once per frame
	void Update () {
        TimeCount();
	}

    public void CreateTree() {
        Instantiate(treePrefab, CreatePosition(), Quaternion.identity);
    }

    public void CreateEnemy() {
        Instantiate(enemyPrefab, CreatePosition(), Quaternion.identity);
    }

    public void AddMissCount() {
        missCount++;
        audioSource.Play();
        if(missCount >= maxMissCount) {
            GameEnd();
        }
        //Debug.Log(missCount);
    }

    public void AddScore() {
        score += 10;
    }

    void TimeCount() {
        timeLimitCount += Time.deltaTime;
        if(timeLimitCount >= maxTimeLimit) {
            GameEnd();
        }
    }

    void GameEnd() {
        SceneManager.LoadScene("ResultScene");
    }

    void GetTreePosition() {
        tree = GameObject.FindGameObjectsWithTag("Tree");
        for (int k = 0; k < tree.Length && k < 10; k++) {
            if(tree[k] == null) {
                treePositionX[k] = 0;
                treePositionZ[k] = 0;
                continue;
            }
            treePositionX[k] = (int)tree[k].gameObject.transform.position.x;
            treePositionZ[k] = (int)tree[k].gameObject.transform.position.z;
        }

        if(tree.Length < 10) {
            for(int l = tree.Length;l < 10; l++) {
                treePositionX[l] = 0;
                treePositionZ[l] = 0;
            }
        }
    }

    Vector3 CreatePosition() {
        int posx, posz;
        bool onceRoop = true;
        GetTreePosition();
        do {
            posx = (int)Random.Range(3.0f, 27.0f);
            foreach(int checkPositionX in treePositionX) {
                if(checkPositionX == posx) {
                    onceRoop = true;
                    break;
                } else {
                    onceRoop = false;
                }
            }
            if ((int)playerTransform.position.x == posx) {
                onceRoop = true;
            }
        }
        while(onceRoop == true);

        onceRoop = true;
        do {
            posz = (int)Random.Range(3.0f, 27.0f);
            foreach (int checkPositionZ in treePositionZ) {
                if (checkPositionZ == posz) {
                    onceRoop = true;
                    break;
                } else {
                    onceRoop = false;
                }
            }
            if((int)playerTransform.position.z == posz) {
                onceRoop = true;
            }
        }
        while (onceRoop == true);

        return new Vector3(posx,0, posz);
    }

    public float GetTimeLimit() {
        return maxTimeLimit - timeLimitCount;
    }

    public float GetScore() {
        return score;
    }

    public float GetMissCount() {
        return 1.0f - missCount / maxMissCount;
    }

}
