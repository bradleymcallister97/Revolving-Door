using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


    public void click()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScreen");
    }

    // Update is called once per frame
    void Update() {
    }

}
