using UnityEngine;

public class Item : MonoBehaviour
{
    public Transform myTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(30f, 45f, 60f) * Time.deltaTime;
        myTransform.Rotate(rotation);
    }
}