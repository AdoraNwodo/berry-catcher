using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private float speed = 10f;

    private Rigidbody2D myBody;

    // Use this for initialization
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vel = myBody.velocity;
        vel.x = Input.GetAxis("Horizontal") * speed;
        myBody.velocity = vel;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            double halfScreen = Screen.width / 2.0;

            //Check if it is left or right?
            if (touchPosition.x < halfScreen)
            {
                gameObject.transform.Translate(Vector3.left * 5 * Time.deltaTime);
            }
            else if (touchPosition.x > halfScreen)
            {
                gameObject.transform.Translate(Vector3.right * 5 * Time.deltaTime);
            }

        }
    }
}
