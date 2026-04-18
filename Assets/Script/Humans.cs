using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humans : MonoBehaviour
{
    public float speed = 1.2f;
    int moveDir = 1;
    Vector2 facingDir;
    float facingAngle;

    float timer = 18f;
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        moveDir = MoveDirReturner();
    }
    private void Update()
    {
        if (timer < 0)
        {
            timer = 18f;
            moveDir = MoveDirReturner();
        }
        else
            timer -= Time.deltaTime;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        facingDir = (Vector2)transform.position.normalized;
        facingAngle = Mathf.Atan2(facingDir.y, facingDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, facingAngle - 90f);
        transform.RotateAround(Vector2.zero, new Vector3(0, 0, moveDir), -speed * Time.deltaTime);
    }
    int MoveDirReturner()
    {
        float randomValue = Random.Range(0, 10f);
        if (randomValue <= 5)
        {
            render.flipX = false;
            return 1;

        }
        else
        {
            render.flipX = true;
            return -1;
        }
    }
}
