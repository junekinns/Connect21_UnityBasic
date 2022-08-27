using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public float damping = 5f;

    private Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - followTarget.position;
    }

    // Update is called once per frame
    void LateUpdate(){
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = followTarget.position + distance;
        
        transform.position = Vector3.Lerp(currentPosition,targetPosition, damping * Time.deltaTime);
    }
}
