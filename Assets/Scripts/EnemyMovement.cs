using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementPerTick;

    Transform myCamera;

    private void Start()
    {
        myCamera = Camera.main.transform;
    }

    private void OnEnable()
    {
        TickManager.OnTick += Move;
    }

    private void OnDisable()
    {
        TickManager.OnTick -= Move;
    }

    void Move()
    {
        //transform.LookAt(myCamera);
        // transform.position = -transform.forward * movementPerTick;

        transform.position -= new Vector3(0, 0, movementPerTick);
    }
}
