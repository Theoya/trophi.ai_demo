using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        // Reset game on escape button
        if (Input.GetKeyDown("escape")){
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
