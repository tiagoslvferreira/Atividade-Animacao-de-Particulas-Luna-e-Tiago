using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviPlat : MonoBehaviour
{
float dirX, moveSpeed = 0.5f;
public float maxPos, minPos;
bool moveRight = true;

// Update is called once per frame
void Update () {
if (transform.position.x > maxPos)
moveRight = false;
if (transform.position.x < minPos)
moveRight = true;

if (moveRight)
transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
else
transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
}
}
