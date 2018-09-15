using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour {
    [SerializeField]
    private Text scoreText, timeCountText;
    [SerializeField]
    private Slider helathBar;
    [SerializeField]
    private StageManeger stageManeger;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score : " + stageManeger.GetScore().ToString();
        timeCountText.text = "Time : " + ((int)stageManeger.GetTimeLimit()).ToString();
        helathBar.value = stageManeger.GetMissCount();
	}
}
