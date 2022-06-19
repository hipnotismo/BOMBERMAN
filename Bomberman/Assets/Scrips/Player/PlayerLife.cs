using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, Iterface
{
    [SerializeField] private GameObject LoseMenu;

    [SerializeField] private int life;

    void Start()
    {
        PlayerPrefs.SetInt("PlayerLife",life);
        Debug.Log(PlayerPrefs.GetInt("PlayerLife"));
    }

    private void Update()
    {
        if (life <=0)
        {
            LoseMenu.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("player hit " + life);
        }
    }

    private void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit");
            damageable();
            StartCoroutine(StopCollision());
        }
    }
    public void damageable()
    {        
        life--;
        Debug.Log("player hit " + life);
        PlayerPrefs.SetInt("PlayerLife", life);              
    }

    IEnumerator StopCollision()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore collision");

        yield return new WaitForSeconds(3);
        gameObject.layer = LayerMask.NameToLayer("Player");

    }
}
