using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShieldHUD : MonoBehaviour
{
    public GameObject Shield;
    //GameObject player;

    public Sprite shield1;
    public Sprite shield2;
    public Sprite shield3;
    public Sprite shield4;

    int shieldHP = 4;
    Image shieldIcon;

    public PlayerController playerScript;
    public LifeHUD healthScript;
    

    // Use this for initialization
    void Start()
    {
        
        shieldIcon = GetComponent<Image>();
        shieldIcon.enabled = (false);
        Shield = GetComponent<GameObject>();
        Shield.SetActive(false);
    }




    public void ShieldDamage()
    {
        if (playerScript.shieldCharge = true)
        {

            shieldIcon.enabled = (true);
            Shield.SetActive(true);

            shieldHP--;

            switch (shieldHP)
            {
                case 1:
                    shieldIcon.sprite = shield1;
                    break;
                case 2:
                    shieldIcon.sprite = shield2;
                    break;
                case 3:
                    shieldIcon.sprite = shield3;
                    break;
                case 4:
                    shieldIcon.sprite = shield4;
                    break;
                default:
                    shieldIcon.enabled = (false);
                    //StartCoroutine("shieldBreak");
                    break;
            }

        }

        else
        {
            healthScript.TakeDamage();
        }
    }

    /*IEnumerator shieldBreak()
        {

            Object.Destroy(Shield);
            
        }*/
    }




       
	
