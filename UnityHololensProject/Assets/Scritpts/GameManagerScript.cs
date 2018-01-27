using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public RectTransform gameOverPanel;
    public RectTransform gameWonPanel;

    public bool IsGameOver { get; set; }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        IsGameOver = true;
    }


    public void GameWon()
    {
        gameWonPanel.gameObject.SetActive(true);
        Debug.Log("Game Won.");
        IsGameOver = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
