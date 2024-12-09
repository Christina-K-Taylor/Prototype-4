using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float velocity = .01f;
    [SerializeField] float shotVelocity = 100f;
    [SerializeField] float Rotspeed = 100f;
    [SerializeField] KeyCode Shoot = KeyCode.Mouse0;
    [SerializeField] float cooldown = .3f;
    [SerializeField] GameObject blast;
    [SerializeField] AudioSource blaster;
    bool ready = true;
    void Start()
    {
        blaster = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float hozin = Input.GetAxisRaw("Horizontal");
        float verin = Input.GetAxisRaw("Vertical");
        //this.transform.position = new Vector3(this.transform.position.x + velocity * hozin, this.transform.position.y + verin * velocity, this.transform.position.z);
        Vector3 thisposition = Camera.main.WorldToScreenPoint(this.transform.position);
        float zangl = Mathf.Atan2(Input.mousePosition.y - thisposition.y, Input.mousePosition.x - thisposition.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, zangl - 90));
        if (Input.GetKey(Shoot) && ready)
        {
            
            GameObject shot = Instantiate(blast);
            shot.transform.position = this.transform.position + new Vector3(Mathf.Cos(((this.transform.eulerAngles.z + 90) * Mathf.Deg2Rad)), Mathf.Sin(((this.transform.eulerAngles.z + 90) * Mathf.Deg2Rad)),0);
            shot.transform.rotation = this.transform.rotation;
            shot.transform.localScale = new Vector3(4, 4, 0);
            Vector2 ShotVelocity =new Vector2(Mathf.Cos(((this.transform.eulerAngles.z + 90) * Mathf.Deg2Rad)), Mathf.Sin(((this.transform.eulerAngles.z + 90) * Mathf.Deg2Rad)));
            blaster.Play();
            //ShotVelocity = Vector3.RotateTowards(ShotVelocity, new Vector3(Mathf.Cos(shot.transform.rotation.z), Mathf.Sin(shot.transform.rotation.z), 0), 90000, 900000);
            shot.transform.GetComponent<Rigidbody2D>().velocity = ShotVelocity * shotVelocity * Time.deltaTime;
            ready = false;
            Invoke(nameof(ResetBlaser), cooldown);

        }
        Vector2 NormMove = new Vector2(hozin, verin);
        //this.transform.GetComponent<Rigidbody2D>().AddForce(NormMove.normalized * velocity, ForceMode2D.Force);
        this.transform.GetComponent<Rigidbody2D>().velocity = NormMove.normalized * velocity * Time.deltaTime;
    }

    private void ResetBlaser()
    {
        ready = true;
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
