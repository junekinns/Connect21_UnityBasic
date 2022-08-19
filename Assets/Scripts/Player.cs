using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
        moveDirection *= (moveSpeed * Time.deltaTime);
        transform.position = transform.position + moveDirection;
    }
}
