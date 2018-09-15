using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ResultScene : MonoBehaviour {
    [SerializeField]
    Text scoreText;
    [SerializeField]
    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        scoreText.text = "Score : " + StageManeger.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick() {
        audioSource.Play();
        SceneManager.LoadScene("StartScene");
    }
}
