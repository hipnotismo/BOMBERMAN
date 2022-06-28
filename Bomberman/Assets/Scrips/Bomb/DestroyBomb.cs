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
        List<Vector3> directions = new List<Vector3>();
        [SerializeField] private LayerMask layer;
        [SerializeField] private GameObject particles;

        private bool isDamage = true;
        public AudioSource explosion;

        private void Awake()
        {
            directions.Add(transform.forward);
            directions.Add(-transform.forward);
            directions.Add(transform.right);
            directions.Add(-transform.right);
            explosion.volume = PlayerPrefs.GetFloat("FXvolume");
            explosion.Pause();
        }

        private void Update()
        {
            destroTimer += 1 * Time.deltaTime;
            explosion.volume = 1;

            Debug.DrawRay(transform.position, directions[0], Color.red);
            Debug.DrawRay(transform.position, directions[1], Color.green);
            Debug.DrawRay(transform.position, directions[2], Color.blue);
            Debug.DrawRay(transform.position, directions[3], Color.cyan);

        }

        public void FixedUpdate()
        {
            RaycastHit hit;

            if (destroTimer >= destroyTime)
            {

                for (int i = 0; i < RycastAmount; i++)
                {

                    if (Physics.Raycast(transform.position, directions[i], out hit, range))
                    {

                        IDamageable isHit = hit.collider.GetComponent<IDamageable>();

                        if (isHit != null)
                        {
                            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
                            {
                                isHit.TakeDamage();
                            }
                            else
                            {
                                
                            }

                            if (hit.collider.CompareTag("BrickWall"))
                            {
                                OnBoxDestroyed?.Invoke();
                                isHit.TakeDamage();
                            }
                        }
                    }
                }
                Eliminate();

            }

        }

        void Eliminate()
        {
            explosion.UnPause();
            explosion.volume = PlayerPrefs.GetFloat("FXvolume");
            Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject, explosion.clip.length);
        }

        private void OnTriggerStay(Collider other)
        {
            if (isDamage)
            {
                if (destroTimer >= destroyTime)
                {
                    IDamageable isHit = other.GetComponent<IDamageable>();
                    isHit.TakeDamage();
                    isDamage = !isDamage;
                }
            }
        }
    }
}
