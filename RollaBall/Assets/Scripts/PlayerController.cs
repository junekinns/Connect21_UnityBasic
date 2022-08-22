using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform myTransform;
    public GameManager gameManager;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);

        myTransform.position = myTransform.position + moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Item") == false){
            Debug.Log("Item!");
            return;
        }
        Destroy(other.gameObject);
        gameManager.AddScore();
    }
}