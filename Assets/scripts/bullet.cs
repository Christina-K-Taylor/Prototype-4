using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    int count = 3;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject thingy = collision.gameObject;
        if (thingy.name == "Meteor")
        {
            thingy.GetComponent<meteor>().Split();
            Destroy(this.gameObject);
        }
        if(GameObject.Find("Meteor") == null)
        {
            SceneManager.LoadScene("WinScene");
        }
        count -= 1;
        if ( count == 0) {
            Destroy(this.gameObject);
        }
        
    }
}
