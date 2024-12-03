using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Prefab;
    [SerializeField] AudioSource blaster;
    void Start()
    {
        this.transform.GetComponent<Rigidbody2D>().angularVelocity = 20f;
        //this.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(.5f,.5f);
        this.name = "Meteor";
    }

    // Update is called once per frame
    public void Split()
    {
        if (this.transform.localScale.x > 2)
        {
            GameObject thingyone = Instantiate(Prefab);
            thingyone.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(1.25f * this.transform.GetComponent<Rigidbody2D>().velocity.x + .09f, 1.25f * this.transform.GetComponent<Rigidbody2D>().velocity.y + .09f);
            print(thingyone.transform.GetComponent<Rigidbody2D>().velocity);
            thingyone.transform.position = new Vector3(this.transform.position.x - .1f * this.transform.localScale.x, this.transform.position.y + 2 * Random.Range(-1f, 1f), this.transform.position.z);
            thingyone.transform.localScale = new Vector3(.5f * this.transform.localScale.x, .5f * this.transform.localScale.y, .5f * this.transform.localScale.z);
            GameObject thingytwo = Instantiate(Prefab);
            thingytwo.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.25f * this.transform.GetComponent<Rigidbody2D>().velocity.x + .09f, 1.25f * this.transform.GetComponent<Rigidbody2D>().velocity.y + .09f);
            thingytwo.transform.localScale = new Vector3(.5f * this.transform.localScale.x, .5f * this.transform.localScale.y, .5f * this.transform.localScale.z);
            thingytwo.transform.position = new Vector3(this.transform.position.x + .1f * this.transform.localScale.x, this.transform.position.y - 2 * Random.Range(-1f, 1f), this.transform.position.z);
        }
        blaster.Play();
        Destroy(this.gameObject);
    }
}
