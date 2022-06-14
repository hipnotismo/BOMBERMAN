using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, Iterface
{
    private int _life;
    void Start()
    {
        _life = 3;
    }

    private void Update()
    {
        if (_life <=0)
        {
            Destroy(gameObject);
        }
    }
    public void damageable()
    {
        _life--;
        Debug.Log("player hit " + _life);
    }
}
