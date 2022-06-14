using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, Iterface
{
    int RycastAmount = 4;
    List<Vector3> directions = new List<Vector3>();
    List<Vector3> AvailableDirections = new List<Vector3>();
    int ListRandom;
    private float m_Speed = 5f;

    Rigidbody m_Rigidbody;

    float range = 1f;

    private void Awake()
    {
        directions.Add(transform.forward);
        directions.Add(-transform.forward);
        directions.Add(transform.right);
        directions.Add(-transform.right);

        m_Rigidbody = GetComponent<Rigidbody>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1;

        Debug.DrawRay(transform.position, forward, Color.green);

        for (int i = 0; i < RycastAmount; i++)
        {

            if (Physics.Raycast(transform.position, directions[i], out hit, range))
            {
                
            }
            else
            {
                AvailableDirections.Add(directions[i]);
            }

        }
        ListRandom = Random.Range(0, AvailableDirections.Count);

        m_Rigidbody.MovePosition(transform.position + AvailableDirections[ListRandom] * Time.deltaTime * m_Speed);
    }

    public void damageable()
    {
        Destroy(gameObject);
    }
}
