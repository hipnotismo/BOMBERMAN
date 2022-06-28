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
            OnPlayerDamage?.Invoke();
            yield return new WaitForSeconds(3);
            gameObject.layer = LayerMask.NameToLayer("Player");
            OnPlayerInmunityEnd?.Invoke();
        }
    }
}