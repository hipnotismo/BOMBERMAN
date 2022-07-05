using System.Collections;
using UnityEngine;
using System;

namespace bomberman
{
    public class PlayerLife : MonoBehaviour, IDamageable//separar el control de las vidas del control de la UI
    {

        public static Action<int> OnLifeUpdate;
        public static Action OnPlayerDeath;
        public static Action OnPlayerDamage;
        public static Action OnPlayerInmunityEnd;

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
            OnLifeUpdate?.Invoke(Life);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Enemy")
            {
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
                OnPlayerDeath?.Invoke();
                return;
            }
            PlayerPrefs.SetInt("PlayerLife", Life);
            gameObject.layer = LayerMask.NameToLayer("Ignore collision");
            transform.gameObject.tag = "InmunePlayer";
            OnPlayerDamage?.Invoke();
            StartCoroutine(StopCollision());
        }

        IEnumerator StopCollision()
        {      
            yield return new WaitForSeconds(3);
            gameObject.layer = LayerMask.NameToLayer("Player");
            transform.gameObject.tag = "Player";
            OnPlayerInmunityEnd?.Invoke();
        }
    }
}