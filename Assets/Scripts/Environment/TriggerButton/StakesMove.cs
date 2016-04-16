using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StakesMove : MonoBehaviour, ITriggerable
{
    public float speed = 0.1f;
    private float reloadTimer = 0f;
    public float reloadCooldown = 0.1f;

    public Transform _stakes;
    private Transform[] _arrayStakes;
    private bool stakesUp = false;
    private int num = 0;

    void Start()
    {
        _arrayStakes = new Transform[_stakes.transform.childCount];
        int i = 0;
        foreach (Transform t in _stakes)
            _arrayStakes[i++] = t;
    }

    void Update()
    {
        if (reloadTimer > 0)
            reloadTimer -= Time.deltaTime;

        if (reloadTimer <= 0)
        {
            if (stakesUp)
            {
                if (_arrayStakes[num].transform.position.y <= (transform.position.y + _arrayStakes[num].GetComponent<Renderer>().bounds.size.y / 2))
                    _arrayStakes[num].transform.position = new Vector3(_arrayStakes[num].transform.position.x, _arrayStakes[num].transform.position.y + speed, _arrayStakes[num].transform.position.z);
                else
                    num += (num < _stakes.transform.childCount - 1) ? 1 : 0;
            }
            else
            {
                if (_arrayStakes[num].transform.position.y >= (transform.position.y - _arrayStakes[num].GetComponent<Renderer>().bounds.size.y / 3))
                    _arrayStakes[num].transform.position = new Vector3(_arrayStakes[num].transform.position.x, _arrayStakes[num].transform.position.y - speed, _arrayStakes[num].transform.position.z);
                else
                    num += (num > 0) ? -1 : 0;
            }
            reloadTimer = reloadCooldown;
        }

    }

    public void OnTriggerEnter()
    {
        stakesUp = true;
    }

    public void OnTriggerExit()
    {
        stakesUp = false;
    }
}

