using UnityEngine;
using System.Collections;

public class FruitSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] fruits;

    private BoxCollider2D col;
    private bool paused = false;
    float timeLeft = 30.0f;

    float x1, x2;

    // Use this for initialization
    void Awake()
    {
        col = GetComponent<BoxCollider2D>();

        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;
    }

    void Start()
    {
        StartCoroutine(SpawnFruit(1f));
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Time.timeScale = 0;
            StopAllCoroutines();
        }
    }
    public void Pause()
    {
        paused = true;
    }

    public void Resume()
    {
        paused = false;
        StartCoroutine(SpawnFruit(1f));
    }

    IEnumerator SpawnFruit(float time)
    {
        if(paused == false)
        {
            yield return new WaitForSecondsRealtime(time);


            Vector3 temp = transform.position;
            temp.x = Random.Range(x1, x2);

            Instantiate(fruits[Random.Range(0, fruits.Length)], temp, Quaternion.identity);
            StartCoroutine(SpawnFruit(Random.Range(1f, 2f)));
        }
        
    }
}
