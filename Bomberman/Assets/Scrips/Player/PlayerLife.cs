using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, Interface
{
    [SerializeField] private GameObject LoseMenu;
    [SerializeField] private Button inmune;
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
        StartCoroutine(StopCollision());
    }

    IEnumerator StopCollision()
    {
        inmune.gameObject.SetActive(true);
        gameObject.layer = LayerMask.NameToLayer("Ignore collision");
        yield return new WaitForSeconds(3);
        gameObject.layer = LayerMask.NameToLayer("Player");
        inmune.gameObject.SetActive(false);

    }
}
