using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public Button btnPlay;
    public Text txtError;
	
	void Start ()
    {
        //check internet Connection
        if (ApiHelper.HasInternetConnection())
        {
            btnPlay.gameObject.SetActive(true);
            txtError.gameObject.SetActive(false);
        }
        else
        {
            btnPlay.gameObject.SetActive(false);
            txtError.gameObject.SetActive(true);
        }
        
	}
    public void LoadScene(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {            
            SceneManager.LoadScene(name);
        }
    }
	
	
}
