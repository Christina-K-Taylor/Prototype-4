using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject thingy = collision.gameObject;
        if (thingy.name == "Meteor")
        {
            thingy.GetComponent<meteor>().Split();
        }
        if(GameObject.Find("Meteor") == null)
        {
            SceneManager.LoadScene("WinScene");
        }
        Destroy(this.gameObject);
    }
}
