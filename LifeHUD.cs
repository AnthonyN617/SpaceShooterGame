using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LifeHUD : MonoBehaviour {
    public Sprite life1;
    public Sprite life2;
    public Sprite life3;
    public Sprite life4;
    public GameObject explosion;
    GameObject player;    
    int hitPoints = 5;
    Image lifeImage;

        
    

	// Use this for initialization
	void Start () {
        lifeImage = GetComponent<Image>();        
        
        player = GameObject.Find("Player");
        
        
        
	}



    public void TakeDamage() {
        
        
        hitPoints--;

        switch (hitPoints)
        {
            case 1:
                lifeImage.sprite = life1;
                break;
            case 2:
                lifeImage.sprite = life2;
                break;
            case 3:
                lifeImage.sprite = life3;
                break;
            case 4:
                lifeImage.sprite = life4;
                break;
            default:
                lifeImage.enabled = false;
                StartCoroutine("Die");
                break;
        }
    }

   
   

        IEnumerator Die()
        {
            Instantiate(explosion, player.transform.position, Quaternion.identity);
            Destroy(player);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("SpaceShooter(CS)");
        }
	}

