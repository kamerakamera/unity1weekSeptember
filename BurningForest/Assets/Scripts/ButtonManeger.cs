using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManeger : MonoBehaviour {
    [SerializeField]
    private GameObject descriptionPanel,startPanel,page1,page2;
    [SerializeField]
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        descriptionPanel.SetActive(false);
        startPanel.SetActive(true);
        page1.SetActive(false);
        page2.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickLoadScene(string sceneName) {
        audioSource.Play();
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickDescription() {
        audioSource.Play();
        descriptionPanel.SetActive(true);
        startPanel.SetActive(false);
        page1.SetActive(true);
        page2.SetActive(false);
    }

    public void OnClickStart() {
        audioSource.Play();
        descriptionPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    public void OnClickNextPage() {
        audioSource.Play();
        page1.SetActive(false);
        page2.SetActive(true);
    }

}
