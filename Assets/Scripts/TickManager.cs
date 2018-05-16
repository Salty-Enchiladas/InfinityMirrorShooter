using System.Collections;
using UnityEngine;

public class TickManager : MonoBehaviour {

    public delegate void Tick();
    public static event Tick OnTick;

    public float tickRate;
    WaitForSeconds waitForTick;

	IEnumerator Start ()
    {
        waitForTick = new WaitForSeconds(tickRate);

        for(; ; )
        {
            if(OnTick != null)
                OnTick();
            yield return waitForTick;
        }
	}
}