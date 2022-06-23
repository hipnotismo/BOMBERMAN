using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace bomberman
{
    public class DestroyBomb : MonoBehaviour
    {

        public static Action OnBoxDestroyed;

        int destroyTime = 1;
        float destroTimer = 0;
        float range = 1f;
        int RycastAmount = 4;
        float sphereRadius = 0.5f;
        bool once = true;
        List<Vector3> directions = new List<Vector3>();
        [SerializeField] private LayerMask layer;

        public AudioSource explosion;

        private void Awake()
        {
            directions.Add(transform.forward);
            directions.Add(-transform.forward);
            directions.Add(transform.right);
            directions.Add(-transform.right);
            //explosion.volume = PlayerPrefs.GetFloat("FXVolume");
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


            if (destroTimer >= destroyTime)
            {
                Debug.Log(destroTimer);

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
                                isHit.takeDamage();

                            }

                        }

                        if (Physics.SphereCast(transform.position, sphereRadius, new Vector3(0, 0, 0), out hit, 0.1f, layer, QueryTriggerInteraction.UseGlobal))
                        {
                            Debug.Log("Sphere raycast:" + hit.collider.name);
                            IDamageable isHit = hit.collider.GetComponent<IDamageable>();
                            if (isHit != null)
                            {
                                isHit.takeDamage();
                                OnBoxDestroyed?.Invoke();
                            }
                        }

                        //if (Physics.SphereCast(transform.position, sphereRadius, directions[i], out hit, 0.5f, layer, QueryTriggerInteraction.UseGlobal))
                        //{
                        //    Debug.Log(hit.collider.name);
                        //    Iterface isHit = hit.collider.GetComponent<Iterface>();                
                        //    if (isHit != null)
                        //    {
                        //        isHit.damageable();
                        //        OnBoxDestroyed?.Invoke();
                        //    }
                        //}
                        once = false;
                    }
                }

                Eliminate();

            }

        }

        void Eliminate()
        {
            explosion.UnPause();
            Destroy(gameObject, 0.7f);
        }

        private void OnDrawGizmosSelected()
        {
            for (int i = 0; i < directions.Count; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(directions[i], sphereRadius);
            }

        }

    }
}
