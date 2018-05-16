using UnityEngine;

public class CloneSpawner : MonoBehaviour {

    public ObjectPooling objectPool;

    public enum SpawnTarget{ Mouse, GameObject }
    public SpawnTarget spawnTarget;

    Camera mainCam;

    private void OnEnable()
    {
        TickManager.OnTick += SpawnObjectFromPool;
    }

    private void OnDisable()
    {
        TickManager.OnTick -= SpawnObjectFromPool;
    }

    private void Start()
    {
        mainCam = Camera.main;
    }

    public void SpawnObjectFromPool()
    {
        GameObject obj = objectPool.GetPooledObject();

        if(obj == null)
        {
            return;
        }

        if(spawnTarget == SpawnTarget.Mouse)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5);
            obj.transform.position = mainCam.ScreenToWorldPoint(mousePos);
            obj.transform.rotation = Quaternion.identity;
        }
        else
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
        }

        obj.SetActive(true);
    }
}