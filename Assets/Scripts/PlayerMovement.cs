using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject PlayerBullet;
    public GameObject BulletPosition;

    float speed = 5f;

    void Start() { }
    void Update()
    {


        if (Input.GetButtonDown("Jump"))
        {
            GameObject bullet = (GameObject)Instantiate(PlayerBullet);
            bullet.transform.position = BulletPosition.transform.position;


            // For Touch Code
            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);
            //    Vector3 touchdirection = Camera.main.ScreenToWorldPoint(touch.position);
            //    touchdirection.z = 0f;
            //    transform.position = touchdirection;
            //}

        }


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);

        //Vector2 direction = transform.position;
        //direction.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        //direction.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.position = direction;    }    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;


    }
}
