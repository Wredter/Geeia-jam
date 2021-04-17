using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BG_change : MonoBehaviour
{
    // Start is called before the first frame update
    
    // public int next_scene;
    public string next_scene;
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            print("triger");
            SceneManager.LoadScene(next_scene, LoadSceneMode.Single);
        }
        
    }
}
