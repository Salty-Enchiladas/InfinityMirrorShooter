using UnityEngine;

public class SpawnFromPool : MonoBehaviour
{
    public ObjectPooling objectPool;

	public void SpawnObjectFromPool()
    {
        GameObject obj = objectPool.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
