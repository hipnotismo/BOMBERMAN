using System.Collections.Generic;
using UnityEngine;
using System;

namespace bomberman
{
    public class DestroyBomb : MonoBehaviour
    {

        public static Action OnBoxDestroyed;

        [SerializeField] private int destroyTime = 3;
        float destroTimer = 0;
        float range = 1f;
        int RycastAmount = 4;
        float shakeInstensity = 1f;
        float shakeInsTime = 0.2f;
        List<Vector3> directions = new List<Vector3>();
        List<Vector3> availableDirections = new List<Vector3>();

        [SerializeField] private LayerMask layer;
        [SerializeField] private GameObject particles;
        [SerializeField] private ParticleSystem particles2;

        private bool isDamage = true;
        [SerializeField] AudioSource explosion;

        private void Awake()
        {
            directions.Add(transform.forward);
            directions.Add(-transform.forward);
            directions.Add(transform.right);
            directions.Add(-transform.right);
            explosion.volume = PlayerPrefs.GetFloat("FXvolume");
            Debug.Log(PlayerPrefs.GetFloat("FXvolume"));
            explosion.Pause();
        }

        private void Update()
        {
            destroTimer += 1 * Time.deltaTime;

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
                                availableDirections.Add(directions[i]);
                            }
                          
                            if (hit.collider.CompareTag("BrickWall"))
                            {
                                OnBoxDestroyed?.Invoke();
                                isHit.TakeDamage();
                                availableDirections.Add(directions[i]);
                            }
                        }
                    }
                    else
                    {
                        availableDirections.Add(directions[i]);
                    }
                }

                for (int i = 0; i < availableDirections.Count; i++)
                {
                    if (Physics.BoxCast(transform.position, transform.lossyScale / 2, availableDirections[i], out hit, Quaternion.identity, range))
                    {

                        IDamageable isHit = hit.collider.GetComponent<IDamageable>();

                        if (isHit != null)
                        {
                            if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
                            {
                                isHit.TakeDamage();
                            }

                            if (hit.collider.CompareTag("BrickWall"))
                            {
                                OnBoxDestroyed?.Invoke();
                                isHit.TakeDamage();
                            }
                        }
                    }              
                }

                if (Physics.BoxCast(transform.position, transform.lossyScale / 2, availableDirections[0], out hit, Quaternion.identity, 0f))
                {

                    IDamageable isHit = hit.collider.GetComponent<IDamageable>();

                    if (isHit != null)
                    {
                        if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("Enemy"))
                        {
                            isHit.TakeDamage();
                        }

                        if (hit.collider.CompareTag("BrickWall"))
                        {
                            OnBoxDestroyed?.Invoke();
                            isHit.TakeDamage();
                        }
                    }
                }

                Eliminate();
            }

        }

        void Eliminate()
        {
            explosion.UnPause();
            //Instantiate(particles, transform.position, transform.rotation);
            Instantiate(particles2, transform.position, Quaternion.identity, gameObject.transform);//se instancia las particulas
            //Instantiate(particles2, transform.position, transform.rotation);
            //Instantiate(particles2, transform.position, transform.rotation);
            //Instantiate(particles2, transform.position, transform.rotation);
            CameraShake.Instace.ShakeCamera(shakeInstensity, shakeInsTime);
            Destroy(gameObject, explosion.clip.length);
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log(other);
            if (isDamage)
            {
                if (destroTimer >= destroyTime)
                {
                    IDamageable isHit = other.GetComponent<IDamageable>();
                    isHit.TakeDamage();
                    isDamage = !isDamage;
                    Debug.Log("Istaking damage: " + isDamage);
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;

            for (int i = 0; i < availableDirections.Count; i++)
            {
                Gizmos.DrawRay(transform.position, availableDirections[i] * range);
                //Draw a cube at the maximum distance
                Gizmos.DrawWireCube(transform.position + availableDirections[i] * range, transform.localScale);
            }         
        }

    }
}
