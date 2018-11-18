using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "NotRibenaFruit" || target.tag == "RibenaFruit")
        {
            target.gameObject.SetActive(false);
        }
    }
}
