using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public ObjectPooling enemy;
    public float spawnDistance;

    List<GameObject> enemies = new List<GameObject>();

    float movementTickRate;
    Transform myCamera;

    private void Start()
    {
        myCamera = Camera.main.transform;
        GameObject obj = enemy.GetPooledObject();
        movementTickRate = obj.GetComponent<EnemyMovement>().movementPerTick;

        enemies.Add(obj);

        if (obj == null)
        {
            return;
        }

        obj.transform.position = new Vector3(0, 0, spawnDistance);
        obj.transform.rotation = transform.rotation;

        obj.transform.SetParent(myCamera);
        obj.SetActive(true);
    }

    private void OnEnable()
    {
        TickManager.OnTick += Spawn;
    }

    private void OnDisable()
    {
        TickManager.OnTick -= Spawn;
    }

    void Spawn()
    {
        GameObject obj = enemy.GetPooledObject();
        enemies.Add(obj);

        if (obj == null)
        {
            return;
        }

        obj.transform.position = enemies[enemies.Count - 1].transform.position + new Vector3(0, 0, -movementTickRate);
        obj.transform.rotation = enemies[enemies.Count - 1].transform.rotation;

        obj.transform.SetParent(myCamera);
        obj.SetActive(true);
    }
}
