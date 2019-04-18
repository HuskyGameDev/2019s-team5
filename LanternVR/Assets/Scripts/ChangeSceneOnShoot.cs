using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnShoot : MonoBehaviour {

    public string sceneName;

    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "SnapBullet")
            SceneManager.LoadScene(sceneName);
    }
}
