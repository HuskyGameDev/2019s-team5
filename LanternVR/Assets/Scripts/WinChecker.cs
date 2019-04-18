using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinChecker : MonoBehaviour {

    int clueCounter;
    public int numberOfClues;
    public string sceneToLoad;

    // Use this for initialization
    void Start () {
        clueCounter = 0;
	}

    public void ClueFound()
    {
        clueCounter++;
        if (clueCounter >= numberOfClues)
            SceneManager.LoadScene(sceneToLoad);
    }
}
