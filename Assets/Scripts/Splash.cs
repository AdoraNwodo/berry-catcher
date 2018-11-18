using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

    public Sprite splashq;

    void OnTriggerEnter2D(Collider2D target)
    {
        StartCoroutine(CatchFruits(target));
    }

    IEnumerator CatchFruits(Collider2D target)
    {
        if (target.tag == "RibenaFruit")
        {
            target.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            target.gameObject.GetComponent<SpriteRenderer>().sprite = splashq;
            yield return new WaitForSecondsRealtime(0.4f);
            target.gameObject.SetActive(false);

        }
    }
}
