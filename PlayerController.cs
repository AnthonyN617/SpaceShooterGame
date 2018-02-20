using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public bool hasLaser = false;
    public bool hasMissile = false;
    

    Vector2 mousePos;
    public Camera camera;
    Rigidbody2D rb;
    public float thrust = 200f;
    bool firing;
    public GameObject bullet;
    public float ROF = 0.2f;
    public GameObject missile;
    Laser laserScript;

    public LifeHUD lifeHud;
    public ShieldHUD shieldHud;

    public bool shieldCharge  = false;
    public GameObject shieldObj;


    //public GameObject PromptLaser;
    //public GameObject PromptMissile;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        GameObject laserObj = GameObject.Find("Laser");
        laserScript = laserObj.GetComponent <Laser>();
	}

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        //rotate player to face cursor
        rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg - 90);



        if (Input.GetKey("space"))
        {
            rb.AddForce(transform.up * thrust);
        }

        if (Input.GetMouseButton(0))
            StartCoroutine("Fire");
            
        
        if (hasLaser && Input.GetMouseButton(1))
            laserScript.laserFiring = true;

        else laserScript.laserFiring = false;

        if (hasMissile && Input.GetKeyDown("e"))
            Instantiate(missile, transform.position, transform.rotation);

        
            

    }
        IEnumerator Fire()
        {
            if (!firing)
            {
                firing = true;
                {
                Instantiate(bullet, transform.position, transform.rotation);
                }
                
                yield return new WaitForSeconds(ROF);
                firing = false;
            }
        }
        
    public void Hit ()
    {

        lifeHud.TakeDamage();
    }

    public void ShieldOn()
    {
        shieldObj.SetActive(true);
        shieldHud.ShieldDamage();
        
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger && other.gameObject.tag.Equals("Pickup"))
        {
            Destroy(other.gameObject);

            PowerUp powerUp = other.gameObject.GetComponent<PowerUp>();

            if (powerUp.type == PowerUp.Type.Laser)
            {

                hasLaser = true;

            }

            else if (powerUp.type == PowerUp.Type.Missile)
            {

                hasMissile = true;

            }

            if (powerUp.type == PowerUp.Type.Shield)
            {
                shieldCharge = true;
                
            }

        }
    }

}
