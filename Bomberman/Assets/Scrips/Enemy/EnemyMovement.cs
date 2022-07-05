using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace bomberman
{
    public class EnemyMovement : MonoBehaviour, IDamageable
    {
        private int RycastAmount = 4;
        private List<Vector3> directions = new List<Vector3>();
        private List<Vector3> availableDirections = new List<Vector3>();
        private int listRandom;
        private int directionIs;

        [SerializeField] private float m_Speed;

        private Rigidbody m_Rigidbody;

        private int truncatedDistance;
        private float range = 1f;
        private float megaRange = 40f;
        private float distance;
        private float redutionZ = 1f;
        private float redutionX = 1f;
        private bool destiny;

        private Vector3 TargetPos;

        private void Awake()
        {
            //4 direcciones a las que se tiran raycast
            directions.Add(Vector3.forward);
            directions.Add(Vector3.back);
            directions.Add(Vector3.right);
            directions.Add(Vector3.left);

            m_Rigidbody = GetComponent<Rigidbody>();
            destiny = false;
        }

        void Update()
        {
            int layerMask = LayerMask.GetMask("Enemy","Bomb","Player");

            // si no tengo un destino
            if (!destiny)
            {
                availableDirections.Clear();
                RaycastHit hit;
                //se tiran los 4 rayos, los que no tocan ningun bloqeu se guardan en una lsita
                for (int i = 0; i < RycastAmount; i++)
                {
                    if (!Physics.Raycast(transform.position, directions[i], out hit, range, layerMask))
                    {
                        availableDirections.Add(directions[i]);
                    }
                }

                //se elegi un elemento random de esa lista
                listRandom = Random.Range(0, availableDirections.Count);

                destiny = true;

                if (listRandom < 0)
                {
                    Debug.Log("hate");
                }
                //raycast mas largo para saber a cuanta distancia esta el proximo bloque
                if (Physics.Raycast(transform.position, availableDirections[listRandom], out hit, Mathf.Infinity))
                {
                    distance = Vector3.Distance(hit.transform.position, gameObject.transform.position);
                    truncatedDistance = (int)distance;
                }

                TargetPos = transform.position + (truncatedDistance * availableDirections[listRandom]);

                if (availableDirections[listRandom] == directions[0])
                {
                    directionIs = 0;
                }

                for (int i = 0; i < RycastAmount; i++)
                {
                    if (availableDirections[listRandom] == directions[i])
                    {
                        directionIs = i;
                    }
                }

                //bool a negativo para que el proceso solo se haga un vez hasta que el jugador llegue al destino
                destiny = true;
            }
            else
            {
                switch (directionIs)
                {
                    case 0:
                        if (transform.position.z >= TargetPos.z - redutionZ)
                        {
                            destiny = false;
                        }
                        else
                        {
                             m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                          
                        }
                        break;
                    case 1:
                        if (transform.position.z <= TargetPos.z + redutionZ)
                        {
                            destiny = false;
                        }
                        else
                        {
                            m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                         
                        }
                        break;
                    case 2:
                        if (transform.position.x >= TargetPos.x - redutionX)
                        {
                            destiny = false;
                        }
                        else
                        {
                            m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                           
                        }
                        break;
                    case 3:
                        if (transform.position.x <= TargetPos.x + redutionX)
                        {
                            destiny = false;
                        }
                        else
                        {
                            m_Rigidbody.MovePosition(transform.position + availableDirections[listRandom] * Time.deltaTime * m_Speed);
                           
                        }
                        break;
                }

            }

            Debug.DrawRay(transform.position, directions[0], Color.red);
            Debug.DrawRay(transform.position, directions[1], Color.green);
            Debug.DrawRay(transform.position, directions[2], Color.blue);
            Debug.DrawRay(transform.position, directions[3], Color.cyan);
            Debug.DrawRay(transform.position, availableDirections[listRandom] * megaRange, Color.red);
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }
    }
}
