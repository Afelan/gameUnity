using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    private bool hasPlayer;
    public string nameScene;
    public string playerTag;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
         Debug.Log("Other");
         Debug.Log(other.tag);
        if (other.tag == playerTag)
        {
            hasPlayer = true;
             Debug.Log("Hero");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == playerTag)
        {
         Debug.Log("Hero Exit");
         hasPlayer = false;
        }
    }
       private void Update() {
        if (hasPlayer && Input.GetKeyDown("e")) {
            SceneManager.LoadScene(nameScene);
        }
    }
}
