using System.Collections;
using UnityEngine;
using System;

namespace bomberman
{
    public class PlayerLife : MonoBehaviour, IDamageable//separar el control de las vidas del control de la UI
    {
        public static Action<int> OnLifeUpdate;
        public static Action OnPlayerDeath;

        [SerializeField] private int life;

        private int Life 
        {
            get 
            {
                return life;
            } 
            set 
            { 
                life = value; 
                OnLifeUpdate?.Invoke(life); 
            }
        }

        void Start()
        {
            PlayerPrefs.SetInt("PlayerLife", Life);
            Debug.Log(PlayerPrefs.GetInt("PlayerLife"));
            Debug.Log("Life here");
            OnLifeUpdate?.Invoke(Life);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("hit");
                TakeDamage();
                StartCoroutine(StopCollision());
            }
        }

        public void TakeDamage()
        {
            Life--;
            OnLifeUpdate?.Invoke(Life);
            if (Life <= 0)
            {
                //LoseMenu.SetActive(true);
                //Time.timeScale = 0f;
                OnPlayerDeath?.Invoke();
                return;
            }
            Debug.Log("player hit " + Life);
            PlayerPrefs.SetInt("PlayerLife", Life);
            StartCoroutine(StopCollision());
        }

        IEnumerator StopCollision()
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore collision");
            yield return new WaitForSeconds(3);
            gameObject.layer = LayerMask.NameToLayer("Player");

        }
    }
}