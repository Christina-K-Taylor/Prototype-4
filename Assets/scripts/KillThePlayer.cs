using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject thingy = collision.gameObject;
        if(thingy.name == "player")
        {
            thingy.GetComponent<player>().Die();
        }
    }
}
