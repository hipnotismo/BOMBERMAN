using System.Collections.Generic;
using UnityEngine;
using System;

namespace bomberman
{
    public class DestroyBomb : MonoBehaviour
    {

        public static Action OnBoxDestroyed;

        int destroyTime = 3;
        float destroTimer = 0;
        float range = 1f;
        int RycastAmount = 4;
        bool once = true;
        List<Vector3> directions = new List<Vector3>();
        [SerializeField] private LayerMask layer;
        [SerializeField] private GameObject particles;

        public AudioSource explosion;

        private void Awake()
        {
            directions.Add(transform.forward);
            directions.Add(-transform.forward);
            directions.Add(transform.right);
            directions.Add(-transform.right);
            explosion.volume = PlayerPrefs.GetFloat("FXvolume");
            Debug.Log("Volume is: " + PlayerPrefs.GetFloat("FXvolume"));
            explosion.Pause();
        }

        private void Update()
        {
            destroTimer += 1 * Time.deltaTime;
            explosion.volume = 1;
        }

        public void FixedUpdate()
        {
            RaycastHit hit;

            Debug.Log("Volume is: " + PlayerPrefs.GetFloat("FXvolume"));

            if (destroTimer >= destroyTime)
            {
                if (once == true)
                {
                    for (int i = 0; i < RycastAmount; i++)
                    {

                        if (Physics.Raycast(transform.position, directions[i], out hit, range))
                        {
                            Debug.Log("Normal raycast: " + hit.collider.name);
                           IDamageable isHit = hit.collider.GetComponent<IDamageable>();

                            if (isHit != null)
                            {
                                if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
                                {

                                }
                                else
                                {
                                    OnBoxDestroyed?.Invoke();

                                }

                                isHit.TakeDamage();

                            }                        
                        }
                        once = false;
                    }
                }

                Eliminate();

            }

        }

        void Eliminate()
        {
            Debug.Log(explosion.volume);
            explosion.UnPause();
            explosion.volume = PlayerPrefs.GetFloat("FXvolume");
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject, explosion.clip.length);
        }     

        private void OnTriggerEnter(Collider other)
        {
            //Debug.Log("Normal raycast: " + hit.collider.name);
            IDamageable isHit = other.GetComponent<IDamageable>();
            OnBoxDestroyed?.Invoke();
        }
       
    }
}
