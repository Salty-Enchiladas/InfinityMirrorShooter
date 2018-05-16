using UnityEngine;

public class CloneMovement : MonoBehaviour {


    public float movementPerTick;

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
        transform.position += new Vector3(0, 0, movementPerTick);
    }
}