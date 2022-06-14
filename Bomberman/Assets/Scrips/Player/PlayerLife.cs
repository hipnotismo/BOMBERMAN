using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour, Iterface
{
    [SerializeField] private GameObject LoseMenu;

    private int _life;
    void Start()
    {
        _life = 3;
    }

    private void Update()
    {
        if (_life <=0)
        {
            LoseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void damageable()
    {
        _life--;
        Debug.Log("player hit " + _life);
    }
}
