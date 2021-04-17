using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float moveSpeed;
    public Rigidbody2D rb;
    public Transform t;
    Vector2 movment = new Vector2(2f, 2f);

    void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");

    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * moveSpeed * Time.fixedDeltaTime);
        if (movment.x != 0 || movment.y != 0)
        {
            t.Rotate(new Vector3(0, 0, (Mathf.Sin(Time.time)*10f)));
        }
    }
}
