using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public enum EPlayerState{
        Idle = 0, 
        Move = 1
    }

    public float moveSpeed = 5f;
    public Animator myAnimator;
    public EPlayerState currentState = EPlayerState.Idle;

    void Update()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(xValue, 0f, zValue);
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        if (xValue == 0f && zValue == 0f){
            currentState = EPlayerState.Idle;
        }
        else{
            currentState = EPlayerState.Move;
        }
        myAnimator.SetInteger("State", (int)currentState);
    }
}
