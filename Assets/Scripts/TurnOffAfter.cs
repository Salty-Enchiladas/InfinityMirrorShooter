using UnityEngine;

public class TurnOffAfter : MonoBehaviour {

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}