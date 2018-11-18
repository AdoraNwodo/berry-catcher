using UnityEngine;
using System.Collections;

public class PlayerBounds : MonoBehaviour
{

    private float minX, maxX, minY;

    // Use this for initialization
    void Start()
    {
        Vector3 coor = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -coor.x + 2f;
        //minX = -1.17f;
        //maxX = 1.17f;
        maxX = coor.x - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        if (temp.x < minX)
        {
            temp.x = minX;
        }
        transform.position = temp;
    }
}
