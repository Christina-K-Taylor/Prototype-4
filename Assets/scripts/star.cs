using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.GetComponent<Rigidbody2D>().angularVelocity = 90f;
    }

    // Update is called once per frame
}
