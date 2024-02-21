using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRepeat : MonoBehaviour
{
    public float speed = 30f;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < 200f)
        {
            transform.position = new Vector3(960 + 750, 540, 0);
        }
    }
}
