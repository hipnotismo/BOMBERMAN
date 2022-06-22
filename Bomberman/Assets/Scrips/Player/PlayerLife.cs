using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, IDamageable//separar el control de las vidas del control de la UI
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
            takeDamage();
            StartCoroutine(StopCollision());
        }
    }
    public void takeDamage()
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
